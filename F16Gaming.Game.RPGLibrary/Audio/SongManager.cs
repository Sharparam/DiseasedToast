using System.IO;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using FMOD;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class SongManager
	{
		private readonly log4net.ILog _log;
		private readonly FMOD.System _system;
		private Channel _channel;
		private readonly MODE _soundMode;
		private FMOD.Sound _sound;

		private readonly List<Song> _songs;

		private Song _nowPlaying;

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

		internal void UnloadSongs()
		{
			Stop();
			_channel = null;
			_nowPlaying = null;
			_songs.Clear();
		}

		public bool HasSong(string name)
		{
			return _songs.Any(s => s.Name == name);
		}

		public Song LoadSong(string file, string name, float volume = 1.0f, bool loop = true)
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

			song = new Song(file, name, volume, loop);
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
					Song next = _nowPlaying.NextSong;
					Stop();
					if (next != null)
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
				if (!playing && !paused && _nowPlaying.Loop) // Need to restart if loop is enabled
					Play(_nowPlaying, true);
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
			RESULT result = _system.createSound(song.File, _soundMode, ref _sound);
			ErrCheck(result);
			Stop();
			float volume = song.Volume;
			if (!restart && song.StartFade != null && !song.StartFade.InProgress)
			{
				_log.Debug("Calling song.BeginStartFade()");
				song.BeginStartFade();
				volume = song.StartFade.StartVolume;
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
				result = _channel.stop();
				ErrCheck(result);
			}
			_channel = null;
			_nowPlaying = null;
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
