using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using FMOD;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class SoundManager : IDisposable
	{
		private readonly log4net.ILog _log;
		private readonly FMOD.System _system;
		private Channel _channel;
		private readonly MODE _soundMode;

		private readonly List<Sound> _sounds;

		internal SoundManager(FMOD.System system, bool hardware = true)
		{
			_log = Logging.LogManager.GetLogger(this);
			_log.Info("Initializing SoundManager...");
			_system = system;
			_sounds = new List<Sound>();
			_soundMode = hardware ? MODE.HARDWARE : MODE.SOFTWARE;
			_log.DebugFormat("Sound Mode == {0}", _soundMode);
			_log.Debug("SoundManager initialized!");
		}

		public void Dispose()
		{
			_log.Info("Unloading SoundManager...");

			UnloadSounds();

			_log.Debug("SoundManager unloaded!");
		}

		public bool HasSound(string name)
		{
			return _sounds.Any(s => s.Name == name);
		}

		public Sound LoadSound(string file, string name, float volume = 1.0f)
		{
			Sound sound = _sounds.FirstOrDefault(s => s.File == file || s.Name == name);
			if (sound != null)
			{
				_log.WarnFormat("Attempted to load already loaded sound file: {0} [{1}]. Returning existing sound object. Please notify a programmer!", name, file);
				return sound;
			}

			if (!File.Exists(file))
			{
				string msg = string.Format("Unable to load {0}: File does not exist!", file);
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			FMOD.Sound fmodSound = null;
			RESULT result = _system.createSound(file, _soundMode, ref fmodSound);
			ErrCheck(result);
			sound = new Sound(fmodSound, file, name, volume);
			_sounds.Add(sound);
			_log.InfoFormat("Loaded sound: {0} ({1})", name, file);
			return sound;
		}

		public Sound GetSound(string name)
		{
			Sound sound = _sounds.FirstOrDefault(s => s.Name == name);
			
			if (sound == null)
			{
				string msg = string.Format("ERROR: Tried to load NULL sound: {0}! Pleaes notify a programmer.", name);
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			return sound;
		}

		internal void UnloadSounds()
		{
			_log.Info("Unloading sounds...");

			for (int i = 1; i < _sounds.Count; i++)
			{
				if (_sounds[i] != null)
				{
					var name = _sounds[i].Name;
					_log.DebugFormat("Unloading sound [{0}]: {1}", i, name);
					_sounds[i].Dispose();
					_sounds[i] = null;
					_log.DebugFormat("Sound [{0}] {1} has been unloaded!", i, name);
				}
			}

			_log.Debug("Sounds unloaded!");
		}

		public void Play(Sound sound)
		{
			_log.Debug("Play(): Calling FMOD.System.playSound...");
			RESULT result = _system.playSound(CHANNELINDEX.FREE, sound.FMODSound, false, ref _channel);
			ErrCheck(result);
		}

		public void Play(string name)
		{
			if (!HasSound(name))
			{
				string msg = string.Format("Tried to play unloaded sound: {0}!", name);
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			Play(GetSound(name));
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
