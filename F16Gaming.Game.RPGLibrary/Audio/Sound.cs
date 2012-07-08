using System;
using System.IO;

using FMOD;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class Sound : IDisposable
	{
		private readonly FMOD.Sound _sound;
		private readonly string _file;
		private readonly string _name;
		private float _volume;

		internal FMOD.Sound FMODSound { get { return _sound; } }

		public string File { get { return _file; } }
		public string FileName { get { return Path.GetFileName(_file); } }
		public string Name { get { return _name; } }

		internal Sound(FMOD.Sound sound, string file, string name, float volume = 1.0f)
		{
			_sound = sound;
			_file = file;
			_name = name;
			_volume = volume;
		}

		public void Dispose()
		{
			if (_sound != null)
			{
				RESULT result = _sound.release();
				ErrCheck(result);
			}
		}

		private void ErrCheck(RESULT result)
		{
			if (result != RESULT.OK)
			{
				string msg = string.Format("FMOD Error! {0} - {1}", result, Error.String(result));
				Logging.LogManager.GetLogger(this).Fatal(msg);
				throw new FMODException(result, msg);
			}
		}
	}
}
