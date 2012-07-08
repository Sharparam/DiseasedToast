using System.Text;

namespace F16Gaming.Game.RPGLibrary.Items
{
	public class Shield : BaseItem
	{
		#region Fields

		private const string ToStringFormat = "{0}, DEF = {1}, DEFMOD = {2}{3}";

		#endregion

		#region Properties

		public int DefenseValue { get; protected set; }
		public int DefenseModifier { get; protected set; }

		#endregion

		#region Constructors

		public Shield(
				string name,
				string type,
				int price = 0,
				float weight = 0.0f,
				int defenseValue = 0,
				int defenseModifier = 0,
				params string[] allowedClasses)
			: base(name, type, price, weight, allowedClasses)
		{
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

			return new Shield(Name, Type, Price, Weight, DefenseValue, DefenseModifier, allowedClasses);
		}

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

		#endregion
	}
}
