using System.Text;

namespace F16Gaming.Game.RPGLibrary.Items
{
	public enum Hands { One, Two }

	public class Weapon : BaseItem
	{
		#region Fields

		private const string ToStringFormat = "{0}, Hands = {1}, ATK = {2}, ATKMOD = {3}, DMG = {4}, DMGMOD = {5}{6}";

		#endregion

		#region Properties

		public Hands Hands { get; protected set; }
		public int AttackValue { get; protected set; }
		public int AttackModifier { get; protected set; }
		public int DamageValue { get; protected set; }
		public int DamageModifier { get; protected set; }

		#endregion

		#region Constructors

		public Weapon(
				string name,
				string type,
				int price = 0,
				float weight = 0.0f,
				Hands hands = Hands.One,
				int attackValue = 0,
				int attackModifier = 0,
				int damageValue = 0,
				int damageModifier = 0,
				params string[] allowedClasses)
			: base(name, type, price, weight, allowedClasses)
		{
			Hands = hands;
			AttackValue = attackValue;
			AttackModifier = attackModifier;
			DamageValue = damageValue;
			DamageModifier = damageModifier;
		}

		#endregion

		#region Abstract Methods

		public override object Clone()
		{
			var allowedClasses = new string[AllowedClasses.Length];

			for (int i = 0; i < AllowedClasses.Length; i++)
				allowedClasses[i] = AllowedClasses[i];

			return new Weapon(Name, Type, Price, Weight, Hands, AttackValue, AttackModifier, DamageValue, DamageModifier, allowedClasses);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var c in AllowedClasses)
				sb.Append(", " + c);

			return string.Format(ToStringFormat, base.ToString(), Hands, AttackValue, AttackModifier, DamageValue, DamageModifier, sb);
		}

		#endregion
	}
}
