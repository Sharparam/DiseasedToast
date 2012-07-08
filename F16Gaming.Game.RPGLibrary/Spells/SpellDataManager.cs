using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Spells
{
	public class SpellDataManager
	{
		#region Fields

		private readonly Dictionary<string, SpellData> _spellData;

		#endregion Fields

		#region Properties

		public Dictionary<string, SpellData> SpellData
		{
			get { return _spellData; }
		}

		#endregion Properties

		#region Constructors

		public SpellDataManager()
		{
			_spellData = new Dictionary<string, SpellData>();
		}

		#endregion Constructors

		#region Methods

		#endregion Methods
	}
}
