namespace F16Gaming.Game.RPGLibrary.Extensions
{
	public static class Number
	{
#region (U)Int*::IsMultiple
		public static bool IsMultiple(this int num, int mult = 2)
		{
			while (num > 2)
				num /= mult;

			return num == mult;
		}

		public static bool IsMultiple(this uint num, uint mult = 2)
		{
			while (num > 2)
				num /= mult;

			return num == mult;
		}

		public static bool IsMultiple(this long num, long mult = 2)
		{
			while (num > 2)
				num /= mult;

			return num == mult;
		}

		public static bool IsMultiple(this ulong num, ulong mult = 2)
		{
			while (num > 2)
				num /= mult;

			return num == mult;
		}
#endregion (U)Int*::IsMultiple
	}
}
