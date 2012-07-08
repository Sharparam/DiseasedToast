using System.Text;

namespace F16Gaming.Game.RPGLibrary.Items
{
	public enum ArmorLocation { Head, Body, Hands, Feet }

	public class Armor : BaseItem
	{
		#region Fields

		private const string ToStringFormat = "{0}, LOC = {1}, DEF = {2}, DEFMOD = {3}{4}";

		#endregion

		#region Properties

		public ArmorLocation Location { get; protected set; }
		public int DefenseValue { get; protected set; }
		public int DefenseModifier { get; protected set; }

		#endregion

		#region Constructors

		public Armor(
				string name,
				string type,
				int price,
				float weight,
				ArmorLocation location,
				int defenseValue = 0,
				int defenseModifier = 0,
				params string[] allowedClasses)
			: base(name, type, price, weight, allowedClasses)
		{
			Location = location;
			DefenseValue = defenseValue;
			DefenseModifier = defenseModifier;
		}

		#endregion

		#region Abstract Methods

		public override object Clone()
		{
			var allowedClasses = new string[AllowedClasses.Length];
			for (int i = 0; i < AllowedClasses.Length; i++)
				allowedClasses[i] = AllowedClasses[i];

			return new Armor(Name, Type, Price, Weight, Location, DefenseValue, DefenseModifier, allowedClasses);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var c in AllowedClasses)
				sb.Append(", " + c);

			var classString = string.Empty;
			if (sb.Length > 0)
				classString = "; Classes: " + sb.ToString().Substring(2);

			return string.Format(ToStringFormat, base.ToString(), Location, DefenseValue, DefenseModifier, classString);
		}

		#endregion
	}
}
