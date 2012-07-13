using System;

using Microsoft.Xna.Framework;

using FMOD;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class AudioManager : IDisposable
	{
		private const int MaxChannels = 256;

		private readonly log4net.ILog _log;
		private readonly FMOD.System _system;

		private readonly SoundManager _soundManager;
		private readonly SongManager _songManager;

		public SoundManager Sound { get { return _soundManager; } }
		public SongManager Song { get { return _songManager; } }

		public AudioManager(bool hardware = true)
		{
			_log = Logging.LogManager.GetLogger(this);
			_log.Info("Initializing AudioManager...");
			_log.Info("Creating FMOD system...");
			uint version = 0;

			RESULT result = Factory.System_Create(ref _system);
			ErrCheck(result);

			_log.Debug("Checking FMOD version...");
			result = _system.getVersion(ref version);
			ErrCheck(result);

			if (version < VERSION.number)
			{
				var msg = string.Format("Error! You are using an old version of FMOD: {0}. This program requires: {1}.",
										version.ToString("X"), VERSION.number.ToString("X"));
				_log.Fatal(msg);
				throw new FMODException(msg);
			}

			result = _system.init(MaxChannels, INITFLAGS.NORMAL, (IntPtr) null);
			ErrCheck(result);

			_soundManager = new SoundManager(_system, hardware);
			_songManager = new SongManager(_system, hardware);

			_log.Info("AudioManager initialized!");
		}

		public void Dispose()
		{
			_log.Info("Unloading AudioManager...");
			_soundManager.Dispose();
			_songManager.Dispose();

			if (_system != null)
			{
				_log.Debug("Disposing FMOD.System...");
				RESULT result = _system.close();
				ErrCheck(result);
				result = _system.release();
				ErrCheck(result);
			}

			_log.Debug("AudioManager unloaded!");
		}

		public void Update(GameTime gameTime)
		{
			_songManager.Update(gameTime);
		}

		private void ErrCheck(RESULT result)
		{
			if (result != RESULT.OK)
			{
				var msg = string.Format("FMOD Error! {0} - {1}", result, Error.String(result));
				_log.FatalFormat(msg);
				throw new FMODException(result, msg);
			}
		}
	}
}
