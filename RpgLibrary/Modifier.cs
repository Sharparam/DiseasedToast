using System;

namespace RpgLibrary
{
	public struct Modifier
	{
		#region Fields

		public int Amount;
		public int Duration;
		public TimeSpan TimeLeft;

		#endregion Fields

		#region Properties
		#endregion Properties

		#region Constructors

		public Modifier(int amount, int duration = -1)
		{
			Amount = amount;
			Duration = duration;
			TimeLeft = duration == -1 ? TimeSpan.Zero : TimeSpan.FromSeconds(duration);
		}

		#endregion Constructors

		#region Methods

		public void Update(TimeSpan elapsedTime)
		{
			if (Duration == -1)
				return;

			TimeLeft -= elapsedTime;
			if (TimeLeft.TotalMilliseconds >= 0)
				return;

			TimeLeft = TimeSpan.Zero;
			Amount = 0;
		}

		#endregion Methods
	}
}
