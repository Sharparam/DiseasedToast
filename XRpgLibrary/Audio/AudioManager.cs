using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace XRpgLibrary.Audio
{
	public class AudioManager
	{
		#region Fields

		private const int MAX_SFX = 50;

		private static readonly log4net.ILog Log = RpgLibrary.Logging.LogManager.GetLogger(typeof (AudioManager));

		private static readonly SoundInstance[] SoundInstances = new SoundInstance[MAX_SFX];

		private readonly Dictionary<string, Sound> _sounds;
		private readonly Dictionary<string, Song> _songs;

		private FadeType _fade = FadeType.None;
		private TimeSpan _fadeElapsed = TimeSpan.Zero;
		private TimeSpan _fadeDelay = TimeSpan.FromMilliseconds(25);
		private float _fadeModifier = 0.01f;
		private float _fadeTarget = 1.0f;
		private string _fadeSong;
		private bool _fadeNext;
		private float? _fadeNextTarget;

		#endregion

		#region Properties

		public Dictionary<string, Sound> Sounds
		{
			get { return _sounds; }
		}

		public Dictionary<string, Song> Songs
		{
			get { return _songs; }
		}

		public string NowPlaying { get; private set; }

		public bool SongPlaying { get { return NowPlaying != null; } }

		public TimeSpan FadeDelay
		{
			get { return _fadeDelay; }
			set
			{
				if (value.TotalMilliseconds < 10)
					_fadeDelay = TimeSpan.FromMilliseconds(10);
				else if (value.TotalMilliseconds > 100)
					_fadeDelay = TimeSpan.FromMilliseconds(100);
				else
					_fadeDelay = value;
			}
		}

		public float FadeModifier
		{
			get { return _fadeModifier; }
			set { _fadeModifier = MathHelper.Clamp(value, 0.01f, 1.0f); }
		}

		#endregion

		#region Enums

		private enum FadeType
		{
			None,
			FadeIn,
			FadeOut
		}

		#endregion

		#region Constructors

		public AudioManager()
		{
			Log.Info("New AudioManager created.");
			_sounds = new Dictionary<string, Sound>();
			_songs = new Dictionary<string, Song>();
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime)
		{
			for (int i = 0; i < SoundInstances.Length; i++)
			{
				if (SoundInstances[i] != null && (SoundInstances[i].IsDisposed || SoundInstances[i].Instance.State == SoundState.Stopped))
				{
					if (!SoundInstances[i].IsDisposed)
						SoundInstances[i].Dispose();

					SoundInstances[i] = null;
				}
			}

			if (_fade != FadeType.None)
			{
				_fadeElapsed += gameTime.ElapsedGameTime;
				if (MediaPlayer.State != MediaState.Playing)
				{
					_fade = FadeType.None;
					_fadeElapsed = TimeSpan.Zero;
				}
				else if (_fadeElapsed > _fadeDelay)
				{
					switch (_fade)
					{
						case FadeType.FadeOut:
							MediaPlayer.Volume -= _fadeModifier;
							if (MediaPlayer.Volume <= 0.0f)
							{
								_fade = FadeType.None;
								StopSong();
								if (_fadeSong != null)
									if (_fadeNext)
										FadeInSong(_fadeSong, _fadeNextTarget);
									else
										PlaySong(_fadeSong);
							}
							break;
						case FadeType.FadeIn:
							MediaPlayer.Volume += _fadeModifier;
							if (MediaPlayer.Volume >= (_fadeTarget > 1.0f ? 1.0f : _fadeTarget))
								_fade = FadeType.None;
							break;
					}
					_fadeElapsed = TimeSpan.Zero;
				}
			}
			else if (_fadeElapsed > TimeSpan.Zero)
			{
				_fadeElapsed = TimeSpan.Zero;
			}
		}

		private void ResetSongs()
		{
			Log.Info("Resetting songs...");
			MediaPlayer.Stop();
			NowPlaying = null;
		}

		internal static SoundInstance AddSoundInstance(SoundInstance instance)
		{
			for (int i = 0; i < SoundInstances.Length; i++)
			{
				if (SoundInstances[i] == null)
				{
					SoundInstances[i] = instance;
					break;
				}
			}

			return instance;
		}

		public Sound AddSound(Sound sound)
		{
			if (_sounds.ContainsKey(sound.Name))
				throw new Exception("Attempted to load sound \"" + sound.Name + "\" which is already loaded.");

			_sounds.Add(sound.Name, sound);

			Log.Info("Loaded sound: " + sound.Name);

			return sound;
		}

		public Sound GetSound(string name)
		{
			return _sounds[name];
		}

		public void RemoveSound(string name)
		{
			if (!_sounds.ContainsKey(name))
				return;

			_sounds.Remove(name);

			Log.Info("Sound removed: " + name);
		}

		public void StopSounds()
		{
			foreach (var instance in SoundInstances.Where(i => i != null && !i.IsDisposed))
				instance.Instance.Stop();
		}

		public void StopSounds(string name)
		{
			foreach (var instance in SoundInstances.Where(i => i != null && !i.IsDisposed && i.Name == name))
				instance.Instance.Stop();
		}

		public Song AddSong(Song song)
		{
			if (_songs.ContainsKey(song.Name))
				throw new Exception("Attempted to load song \"" + song.Name + "\" which is already loaded.");

			_songs.Add(song.Name, song);

			Log.Info("Song loaded: " + song.Name);

			return song;
		}

		public Song GetSong(string name)
		{
			return _songs[name];
		}

		public void RemoveSong(string name)
		{
			if (!_songs.ContainsKey(name))
				return;

			_songs.Remove(name);

			Log.Info("Song removed: " + name);
		}

		public void PlaySong(string name, float? volume = null)
		{
			if (!_songs.ContainsKey(name))
				throw new Exception("Attempted to play song \"" + name + "\" which is not loaded.");

			ResetSongs();

			//_songs[name].Play(volume.HasValue ? volume.Value : _songs[name].Volume);
			_songs[name].Play(volume ?? _songs[name].Volume);
			NowPlaying = name;

			Log.Info("Playing song: " + NowPlaying + " (" + MediaPlayer.Volume + ")");
		}

		public void StopSong()
		{
			Log.Info("Stopping song...");
			MediaPlayer.Stop();
			NowPlaying = null;
		}

		public void PauseSong()
		{
			if (NowPlaying != null && MediaPlayer.State == MediaState.Playing)
			{
				MediaPlayer.Pause();
				Log.Info("Song paused.");
			}
		}

		public void ResumeSong()
		{
			if (NowPlaying != null && MediaPlayer.State == MediaState.Paused)
			{
				MediaPlayer.Resume();
				Log.Info("Song resumed.");
			}
		}

		public void FadeOutSong(string nextSong = null, bool fadeNext = false, float? fadeTarget = null)
		{
			Log.Debug("Fading out song...");
			if (nextSong != null && _songs.ContainsKey(nextSong))
			{
				Log.Debug("Next song: " + nextSong + " (" + (fadeTarget ?? 1.0f) + ")");
				_fadeSong = nextSong;
			}
			else
				_fadeSong = null;

			_fade = FadeType.FadeOut;
			_fadeNext = fadeNext;
			_fadeNextTarget = fadeTarget;
		}

		public void FadeInSong(string name, float? targetVolume = null)
		{
			if (!_songs.ContainsKey(name))
				throw new Exception(name + " is not loaded.");

			Log.Debug("Fading in song. (" + (targetVolume ?? _songs[name].Volume) + ")");

			_fadeSong = name;
			_fadeTarget = targetVolume ?? _songs[name].Volume;
			_fade = FadeType.FadeIn;
			PlaySong(name, 0.0f);
		}

		#endregion
	}
}
