using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgLibrary.Utilities
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
