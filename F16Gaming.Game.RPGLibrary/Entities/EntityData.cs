namespace F16Gaming.Game.RPGLibrary.Entities
{
	public class EntityData
	{
		#region Fields

		private const string ToStringFormat = "{0}: STR = {1}, DEX = {2}, CUN = {3}, WILL = {4}, MAG = {5}, CONST = {6}, HP Formula = {7}, STA Formula = {8}, MAG Formula = {9}";

		public string Name;
		public int Strength;
		public int Dexterity;
		public int Cunning;
		public int Willpower;
		public int Magic;
		public int Constitution;
		public string HealthFormula;
		public string StaminaFormula;
		public string MagicFormula;

		#endregion

		#region Constructors

		private EntityData()
		{
			
		}

		public EntityData(
			string name,
			int strength,
			int dexterity,
			int cunning,
			int willpower,
			int magic,
			int constitution,
			string healthFormula,
			string staminaFormula,
			string magicFormula)
		{
			Name = name;
			Strength = strength;
			Dexterity = dexterity;
			Cunning = cunning;
			Willpower = willpower;
			Magic = magic;
			Constitution = constitution;
			HealthFormula = healthFormula;
			StaminaFormula = staminaFormula;
			MagicFormula = magicFormula;
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return string.Format(ToStringFormat, Name, Strength, Dexterity, Cunning, Willpower, Magic, Constitution,
			                     HealthFormula, StaminaFormula, MagicFormula);
		}

		public object Clone()
		{
			var data = new EntityData
			{
				Name = Name,
				Strength = Strength,
				Dexterity = Dexterity,
				Cunning = Cunning,
				Willpower = Willpower,
				Magic = Magic,
				Constitution = Constitution,
				HealthFormula = HealthFormula,
				MagicFormula = MagicFormula
			};

			return data;
		}

		#endregion
	}
}
