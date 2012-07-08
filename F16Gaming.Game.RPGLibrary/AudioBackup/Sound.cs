using Microsoft.Xna.Framework.Audio;

namespace XRpgLibrary.Audio
{
	public class Sound
	{
		#region Fields

		private readonly SoundEffect _sound;

		#endregion

		#region Properties

		public string Name { get; private set; }

		#endregion

		#region Constructors

		public Sound(string name, SoundEffect sound)
		{
			Name = name;
			_sound = sound;
		}

		#endregion

		#region Methods

		public SoundInstance Play(float volume = 1.0f, bool loop = false)
		{
			var instance = new SoundInstance(Name, _sound.CreateInstance()) {Instance = {Volume = volume, IsLooped = loop}};
			instance.Instance.Play();
			return AudioManager.AddSoundInstance(instance);
		}

		#endregion
	}
}
