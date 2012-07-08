namespace F16Gaming.Game.RPGLibrary.Skills
{
	public class Recipe
	{
		#region Fields

		public string Name;
		public Reagent[] Reagents;

		#endregion Fields

		#region Properties
		#endregion Properties

		#region Constructors

		private Recipe()
		{
			
		}

		public Recipe(string name, params Reagent[] reagents)
		{
			Name = name;

			Reagents = new Reagent[reagents.Length];
			for (int i = 0; i < reagents.Length; i++)
				Reagents[i] = reagents[i];
		}

		#endregion Constructors

		#region Methods
		#endregion Methods
	}
}
