using System.Collections.Generic;

namespace RpgLibrary.Skills
{
	public class SkillDataManager
	{
		#region Fields

		private readonly Dictionary<string, SkillData> _skillData;

		#endregion Fields

		#region Properties

		public Dictionary<string, SkillData> SkillData
		{
			get { return _skillData; }
		}

		#endregion Properties

		#region Constructors

		public SkillDataManager()
		{
			_skillData = new Dictionary<string, SkillData>();
		}

		#endregion Constructors

		#region Methods
		#endregion Methods
	}
}
