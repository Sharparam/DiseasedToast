using System.Collections.Generic;

namespace RpgLibrary.Skills
{
	public class RecipeManager
	{
		#region Fields

		private readonly Dictionary<string, Recipe> _recipes;

		#endregion Fields

		#region Properties

		public Dictionary<string, Recipe> Recipes
		{
			get { return _recipes; }
		}

		#endregion Properties

		#region Constructors

		public RecipeManager()
		{
			_recipes = new Dictionary<string, Recipe>();
		}

		#endregion Constructors

		#region Methods
		#endregion Methods
	}
}
