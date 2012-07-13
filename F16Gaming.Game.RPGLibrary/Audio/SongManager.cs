using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using FMOD;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class SongManager : IDisposable
	{
		private const uint EndFadeSafetyMargin = 100;

		private readonly log4net.ILog _log;
		private readonly FMOD.System _system;
		private Channel _channel;
		private readonly MODE _soundMode;
		private FMOD.Sound _sound;
		private readonly List<Song> _songs;
		private Song _nowPlaying;
		private uint _endFadeStart;

		public Song NowPlaying { get { return _nowPlaying; } }

		internal SongManager(FMOD.System system, bool hardware = true)
		{
			_log = Logging.LogManager.GetLogger(this);
			_log.Info("Initializing SongManager...");
			_system = system;
			_songs = new List<Song>();

// ReSharper disable BitwiseOperatorOnEnumWihtoutFlags
			if (hardware)
				_soundMode = MODE._2D | MODE.HARDWARE | MODE.CREATESTREAM;
			else
				_soundMode = MODE._2D | MODE.SOFTWARE | MODE.CREATESTREAM;
// ReSharper restore BitwiseOperatorOnEnumWihtoutFlags

			_log.DebugFormat("Sound Mode == {0}", _soundMode);
			_log.Debug("SongManager initialized!");
		}

		public void Dispose()
		{
			_log.Debug("SongManager.Dispose();");
			UnloadSongs();
		}

		internal void UnloadSongs()
		{
			_log.Info("Unloading SongManager...");
			Stop();
			_log.Debug("Setting song channel to NULL...");
			_channel = null;
			_nowPlaying = null;
			_log.Debug("Clearing song list...");
			_songs.Clear();
		}

		public bool HasSong(string name)
		{
			return _songs.Any(s => s.Name == name);
		}

		public Song LoadSong(string file, string name, float volume = 1.0f, bool loop = true, uint loopPoint = 0)
		{
			Song song = _songs.FirstOrDefault(s => s.File == file || s.Name == name);
			if (song != null)
			{
				_log.WarnFormat("Attempted to load already loaded song file: {0} [{1}]. Returning existing song object. Please notify a programmer!", name, file);
				return song;
			}

			if (!File.Exists(file))
			{
				string msg = string.Format("Unable to load {0}: File does not exist!", file);
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			song = new Song(file, name, volume, loop, loopPoint);
			_songs.Add(song);
			_log.InfoFormat("Loaded song: {0} ({1})", name, file);
			return song;
		}

		public Song GetSong(string name)
		{
			Song song = _songs.FirstOrDefault(s => s.Name == name);

			if (song == null)
			{
				string msg = string.Format("ERROR: Tried to load NULL song: {0}! Please notify a programmer.", name);
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			return song;
		}

		internal void Update(GameTime gameTime)
		{
			if (_nowPlaying == null)
				return;

			if (_nowPlaying.StartFade != null && _nowPlaying.StartFade.InProgress)
			{
				_nowPlaying.StartFade.Update(gameTime.ElapsedGameTime);
				if (_nowPlaying.StartFade.InProgress)
				{
					SetVolume(_nowPlaying.StartFade.CurrentVolume);
				}
				else
				{
					_log.DebugFormat("Updating volume to: {0}", _nowPlaying.StartFade.EndVolume);
					SetVolume(_nowPlaying.StartFade.EndVolume);
					_nowPlaying.StartFade.Stop();
				}
			}
			else if (_nowPlaying.EndFade != null && _nowPlaying.EndFade.InProgress)
			{
				_nowPlaying.EndFade.Update(gameTime.ElapsedGameTime);
				if (_nowPlaying.EndFade.InProgress)
				{
					SetVolume(_nowPlaying.EndFade.CurrentVolume);
				}
				else
				{
					SetVolume(_nowPlaying.EndFade.EndVolume);
					_nowPlaying.EndFade.Stop();
					Song curr = _nowPlaying;
					Song next = curr.NextSong;
					Stop();
					if (curr.EndFadeRestart)
					{
						_log.Debug("Song faded with EndFadeRestart TRUE, restarting song!");
						Play(curr);
					}
					else if (next != null)
						Play(next);
				}
			}
			else
			{
				bool playing = false;
				bool paused = false;
				RESULT result = _channel.isPlaying(ref playing);
				ErrCheck(result);
				result = _channel.getPaused(ref paused);
				ErrCheck(result);
				uint currentTime = GetPosition();
				if (playing && !paused && _nowPlaying.Loop && _nowPlaying.LoopPoint > 0 && currentTime >= _nowPlaying.LoopPoint)
				{
					_log.DebugFormat("Loop point {0} reached, restarting song...", _nowPlaying.LoopPoint);
					Play(_nowPlaying, true);
				}
				else if (!playing && !paused && _nowPlaying.Loop) // Need to restart if loop is enabled
					Play(_nowPlaying, true);
				else if (!playing && !paused && _nowPlaying.NextSong != null) // Play the next song if there is one
					Play(_nowPlaying.NextSong);
				else if (_nowPlaying.EndFade != null && currentTime >= _endFadeStart)
				{
					_log.Debug("Begin end fade!");
					_nowPlaying.BeginEndFade(true);
				}
			}
		}

		public void Play()
		{
			if (_channel == null || _nowPlaying == null)
				return;

			bool paused = false;
			RESULT result = _channel.getPaused(ref paused);
			ErrCheck(result);
			if (paused)
			{
				_log.DebugFormat("Unpausing: {0}", _nowPlaying.Name);
				result = _channel.setPaused(false);
				ErrCheck(result);
			}
		}

		public void Play(Song song, bool restart = false)
		{
			if (!restart && _nowPlaying != null && _nowPlaying.EndFade != null && _nowPlaying.EndFade.InProgress && _nowPlaying.NextSong == null)
			{
				_nowPlaying.SetNext(song);
				return;
			}

			_log.Debug("Play(): Creating sound object...");
			//MODE mode = song.Loop ? _soundMode | MODE.LOOP_NORMAL : _soundMode;
			MODE mode = _soundMode;
			RESULT result = _system.createSound(song.File, mode, ref _sound);
			ErrCheck(result);
			Stop();
			float volume = song.Volume;

			if (!restart && song.StartFade != null && !song.StartFade.InProgress)
			{
				_log.Debug("Calling song.BeginStartFade()");
				song.BeginStartFade();
				volume = song.StartFade.StartVolume;
			}

			if (song.EndFade != null)
			{
				// Find out at what position in the song we need to start fading out
				// First get the length of the current song in milliseconds
				uint length = 0;
				result = _sound.getLength(ref length, TIMEUNIT.MS);
				ErrCheck(result);
				// Get the time it takes for the end fade to complete
				float change = song.EndFade.StartVolume > song.EndFade.EndVolume
				               	? Math.Abs(song.EndFade.StartVolume - song.EndFade.EndVolume)  // Reduce volume
				               	: Math.Abs(song.EndFade.EndVolume - song.EndFade.StartVolume); // Increase volume
				float iterate = Math.Abs(change / song.EndFade.Modifier); // How many times does it need to add the amount of modifier to reach target volume?
				if (iterate < 0) // Invert if negative
					iterate = -iterate;
				// Safety margin makes sure there is no way to song will restart prematurely
				var fadeLength = (uint) (iterate * song.EndFade.Delay.TotalMilliseconds) + EndFadeSafetyMargin;
				_endFadeStart = length - fadeLength;
				_log.DebugFormat("Song length: {0}; Change: {1}; Iterate: {2}; FadeLength: {3}; EndFadeStart: {4}", length, change, iterate, fadeLength, _endFadeStart);
			}

			_log.Debug("Play(): Calling FMOD.System.playSound...");
			result = _system.playSound(CHANNELINDEX.REUSE, _sound, true, ref _channel);
			ErrCheck(result);
			_nowPlaying = song;
			SetVolume(volume);
			Play();
		}

		public void Play(string name)
		{
			if (!HasSong(name))
			{
				string msg = string.Format("Tried to play unloaded song: {0}!", name);
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			Play(GetSong(name));
		}

		public void Pause()
		{
			if (_channel == null || _nowPlaying == null)
				return;

			bool paused = false;
			RESULT result = _channel.getPaused(ref paused);
			ErrCheck(result);
			if (!paused)
			{
				result = _channel.setPaused(true);
				ErrCheck(result);
			}
		}

		public void Stop()
		{
			if (_channel == null || _nowPlaying == null)
				return;

			bool playing = false;
			bool paused = false;
			RESULT result = _channel.isPlaying(ref playing);
			ErrCheck(result);
			result = _channel.getPaused(ref paused);
			ErrCheck(result);
			if (playing || paused)
			{
				_log.DebugFormat("Stopping current song: {0}", _nowPlaying.Name);

				result = _channel.stop();
				ErrCheck(result);
				if (_sound != null)
				{
					result = _sound.release();
					ErrCheck(result);
				}
			}

			_channel = null;
			_nowPlaying = null;

			_log.Debug("Song stopped!");
		}

		public float GetVolume()
		{
			float volume = 0.0f;

			if (_channel == null)
				return volume;

			ErrCheck(_channel.getVolume(ref volume));

			return volume;
		}

		public void SetVolume(float volume)
		{
			if (_channel == null)
				return;

			volume = MathHelper.Clamp(volume, 0.0f, 1.0f);
			//_log.DebugFormat("Setting SongManager._channel volume to: {0}", volume);
			RESULT result = _channel.setVolume(volume);
			ErrCheck(result);
		}

		public uint GetLength()
		{
			uint length = 0;

			if (_sound != null)
				ErrCheck(_sound.getLength(ref length, TIMEUNIT.MS));
			
			return length;
		}

		public uint GetPosition()
		{
			uint pos = 0;

			if (_channel != null)
				ErrCheck(_channel.getPosition(ref pos, TIMEUNIT.MS));

			return pos;
		}

		private void ErrCheck(RESULT result)
		{
			if (result != RESULT.OK)
			{
				string msg = string.Format("FMOD Error! {0} - {1}", result, Error.String(result));
				_log.Fatal(msg);
				throw new FMODException(result, msg);
			}
		}
	}
}
