using System;

namespace RpgLibrary
{
	public enum DiceType
	{
		D4 = 4,
		D6 = 6,
		D8 = 8,
		D10 = 10,
		D12 = 12,
		D20 = 20,
		D100 = 100
	}

	public class Mechanics
	{
		#region Fields

		private static readonly Random Rand = new Random();

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		#endregion Constructors

		#region Methods

		public static int RollDice(DiceType dice)
		{
			return Rand.Next(0, (int) dice) + 1;
		}

		#endregion Methods

	}
}
