using System.Text;

namespace RpgLibrary.Items.Data
{
	public class ShieldData : BaseItemData
	{
		private const string ToStringFormat = "{0}, DEF = {1}, DEFMOD = {2}{3}";

		public int DefenseValue;
		public int DefenseModifier;

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var c in AllowedClasses)
				sb.Append(", " + c);

			var classString = string.Empty;
			if (sb.Length > 0)
				classString = "; Classes: " + sb.ToString().Substring(2);

			return string.Format(ToStringFormat, base.ToString(), DefenseValue, DefenseModifier, classString);
		}
	}
}
