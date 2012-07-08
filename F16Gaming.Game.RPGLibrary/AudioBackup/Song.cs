using Microsoft.Xna.Framework.Media;

namespace XRpgLibrary.Audio
{
	public class Song
	{
		#region Fields

		private readonly Microsoft.Xna.Framework.Media.Song _song;

		#endregion

		#region Properties

		public string Name { get; private set; }
		public float Volume { get; private set; }

		#endregion

		#region Constructors

		public Song(string name, Microsoft.Xna.Framework.Media.Song song, float volume = 1.0f)
		{
			Name = name;
			_song = song;
			Volume = volume;
		}

		#endregion

		#region Methods

		internal void Play(float volume = 1.0f)
		{
			if (MediaPlayer.State == MediaState.Playing)
				MediaPlayer.Stop();

			MediaPlayer.Volume = volume;
			MediaPlayer.IsRepeating = true;
			MediaPlayer.Play(_song);
		}

		#endregion
	}
}
