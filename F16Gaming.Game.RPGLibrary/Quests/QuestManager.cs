using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Quests
{
	public class QuestManager
	{
		#region Fields

		private readonly Dictionary<string, Quest> _quests;

		#endregion Fields

		#region Properties

		public Dictionary<string, Quest> Quests
		{
			get { return _quests; }
		}

		#endregion Properties

		#region Constructors

		public QuestManager()
		{
			_quests = new Dictionary<string, Quest>();
		}

		#endregion Constructors

		#region Methods
		#endregion Methods
	}
}
