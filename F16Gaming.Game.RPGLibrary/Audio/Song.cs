using System.IO;
using System.Diagnostics;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class Song
	{
		private readonly string _file;
		private readonly string _name;

		private float _volume;
		private bool _loop;
		private uint _loopPoint;
		private Song _next;
		private FadeInfo _startFade;
		private FadeInfo _endFade;
		private bool _endFadeRestart;

		internal string File { get { return _file; } }
		internal string FileName { get { return Path.GetFileName(_file); } }

		internal uint LoopPoint { get { return _loopPoint; } }
		internal Song NextSong { get { return _next; } }
		internal FadeInfo StartFade { get { return _startFade; } }
		internal FadeInfo EndFade { get { return _endFade; } }
		internal bool EndFadeRestart { get { return _endFadeRestart; } }

		public string Name { get { return _name; } }
		public float Volume { get { return _volume; } }
		public bool Loop { get { return _loop; } }

		internal Song(string file, string name, float volume = 1.0f, bool loop = true, uint loopPoint = 0)
		{
			_file = file;
			_name = name;
			_volume = volume;
			_loop = loop;
			_loopPoint = loopPoint;
		}

		public void SetVolume(float volume)
		{
			_volume = volume;
		}

		public void SetLoop(bool loop)
		{
			_loop = loop;
		}

		public void SetNext(Song song)
		{
			_next = song;
		}

		public void SetStartFade(FadeInfo info)
		{
			_startFade = info;
		}

		public void SetEndFade(FadeInfo info)
		{
			_endFade = info;
		}

		public void BeginStartFade()
		{
			Debug.Assert(_startFade != null);

			if (_startFade.InProgress || (_endFade != null && _endFade.InProgress))
				return;

			_startFade.Start();
		}

		public void BeginEndFade(bool restart = false)
		{
			Debug.Assert(_endFade != null);

			if (_endFade.InProgress || (_startFade != null && _startFade.InProgress))
				return;

			_endFadeRestart = restart;

			_endFade.Start();
		}
	}
}
