using System.Text;

namespace RpgLibrary.Items.Data
{
	public class WeaponData : BaseItemData
	{
		private const string ToStringFormat = "{0}, Hands = {1}, ATK = {2}, ATKMOD = {3}, DMG = {4}, DMGMOD = {5}{6}";

		public Hands Hands;
		public int AttackValue;
		public int AttackModifier;
		public int DamageValue;
		public int DamageModifier;

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var c in AllowedClasses)
				sb.Append(", " + c);

			var classString = string.Empty;
			if (sb.Length > 0)
				classString = "; Classes: " + sb.ToString().Substring(2);

			return string.Format(ToStringFormat, base.ToString(), Hands, AttackValue, AttackModifier, DamageValue, DamageModifier, classString);
		}
	}
}
