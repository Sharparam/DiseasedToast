using System.Collections.Generic;

namespace RpgLibrary.Talents
{
	public class TalentDataManager
	{
		#region Fields

		private readonly Dictionary<string, TalentData> _talentData;

		#endregion Fields

		#region Properties

		public Dictionary<string, TalentData> TalentData
		{
			get { return _talentData; }
		}

		#endregion Properties

		#region Constructors

		public TalentDataManager()
		{
			_talentData = new Dictionary<string, TalentData>();
		}

		#endregion Constructors

		#region Methods

		#endregion Methods
	}
}
