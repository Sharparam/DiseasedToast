using System.Text;

namespace RpgLibrary.Items.Data
{
	public class ArmorData : BaseItemData
	{
		private const string ToStringFormat = "{0}, LOC = {1}, DEF = {2}, DEFMOD = {3}{4}";

		public ArmorLocation ArmorLocation;
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

			return string.Format(ToStringFormat, base.ToString(), ArmorLocation, DefenseValue, DefenseModifier, classString);
		}
	}
}
