namespace F16Gaming.Game.RPGLibrary.Entities
{
	public class Attribute
	{
		#region Fields

		private int _current;
		private int _maximum;

		#endregion

		#region Properties

		public int Current
		{
			get { return _current; }
		}

		public int Maximum
		{
			get { return _maximum; }
		}

		public static Attribute Zero
		{
			get { return new Attribute(); }
		}

		#endregion

		#region Constructors

		private Attribute() : this(0, 0)
		{ }

		public Attribute(int maximum) : this(maximum, maximum)
		{ }

		public Attribute(int current, int maximum)
		{
			_current = current;
			_maximum = maximum;
			if (_current > _maximum)
				_current = _maximum;
		}

		#endregion

		#region Methods

		public void Heal(ushort value)
		{
			_current += value;
			if (_current > _maximum)
				_current = _maximum;
		}

		public void Damage(ushort value)
		{
			_current -= value;
			if (_current < 0)
				_current = 0;
		}

		public void SetCurrent(int value)
		{
			_current = value;
			if (_current > _maximum)
				_current = _maximum;
		}

		public void SetMaximum(int value, bool updateCurrent = false)
		{
			_maximum = value;
			if (updateCurrent)
				_current = _maximum;
			else if (_current > _maximum)
				_current = _maximum;
		}

		#endregion
	}
}
