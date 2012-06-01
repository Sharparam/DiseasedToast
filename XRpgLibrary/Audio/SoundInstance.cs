using System;

using Microsoft.Xna.Framework.Audio;

namespace XRpgLibrary.Audio
{
	public class SoundInstance : IDisposable
	{
		public string Name { get; private set; }
		public SoundEffectInstance Instance { get; private set; }

		public bool IsDisposed
		{
			get { return Instance == null || Instance.IsDisposed; }
		}

		internal SoundInstance(string name, SoundEffectInstance instance)
		{
			Name = name;
			Instance = instance;
		}

		public void Dispose()
		{
			Instance.Dispose();
			Instance = null;
		}
	}
}
