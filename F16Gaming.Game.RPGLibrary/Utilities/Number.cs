namespace F16Gaming.Game.RPGLibrary.Utilities
{
	public static class Number
	{
		public static bool IsMultiple(int num, int mult = 2)
		{
			while (num > 2)
				num /= mult;

			return num == mult;
		}
	}
}
