using System;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class FadeInfo
	{
		private readonly float _startVolume;
		private readonly float _endVolume;
		private float _currentVolume;
		private readonly float _modifier;
		private readonly TimeSpan _delay;
		private TimeSpan _current;
		private bool _inProgress;

		internal float StartVolume { get { return _startVolume; } }
		internal float CurrentVolume { get { return _currentVolume; } }
		internal float EndVolume { get { return _endVolume; } }
		internal bool InProgress { get { return _inProgress; } }

		public FadeInfo(float start, float end, float modifier = 0.01f, TimeSpan? delay = null)
		{
			_current = TimeSpan.Zero;
			_delay = delay.HasValue ? delay.Value : TimeSpan.FromMilliseconds(25);
			_modifier = modifier;
			_startVolume = start;
			_endVolume = end;
			_currentVolume = _startVolume;
		}

		internal void Start()
		{
			if (_inProgress)
				return;

			_inProgress = true;

			_currentVolume = _startVolume;
			_current = TimeSpan.Zero;
		}

		internal void Stop()
		{
			if (!_inProgress)
				return;

			_inProgress = false;

			_currentVolume = _endVolume;
			_current = TimeSpan.Zero;
		}

		internal void Update(TimeSpan elapsed)
		{
			if (!_inProgress)
				return;

			_current += elapsed;

			if (_current < _delay)
				return;

			_current = TimeSpan.Zero;

			_currentVolume += _modifier;

			if (_modifier < 0 ? _currentVolume <= _endVolume : _currentVolume >= _endVolume)
			{
				_currentVolume = _endVolume;
				_inProgress = false;
			}
		}
	}
}
