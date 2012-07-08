using System.Collections.Generic;
using System.Text;
using F16Gaming.Game.RPGLibrary.Skills;

namespace F16Gaming.Game.RPGLibrary.Items.Data
{
	public class ContainerData
	{
		#region Fields

		private const string ToStringFormat = "{0}: Difficulty = {1}, Trapped = {2}, Locked = {3}, Trap = {4}, Key = {5}, KeyType = {6}, KeysRequired = {7}, MinGold = {8}, MaxGold = {9}{10}";

		public string Name;
		public Difficulty Difficulty;
		public bool IsTrapped;
		public bool IsLocked;
		public string TrapName;
		public string KeyName;
		public string KeyType;
		public int KeysRequired;
		public int MinGold;
		public int MaxGold;
		public Dictionary<string, string> ItemCollection;

		#endregion

		#region Properties

		#endregion

		#region Constructors

		public ContainerData()
		{
			ItemCollection = new Dictionary<string, string>();
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (KeyValuePair<string, string> pair in ItemCollection)
				sb.Append(", " + pair.Key + "<>" + pair.Value);

			string itemString = string.Empty;
			if (sb.Length > 0)
				itemString = "; Items = " + sb.ToString().Substring(2);

			return string.Format(ToStringFormat, Name, Difficulty, IsTrapped, IsLocked, TrapName, KeyName, KeyType, KeysRequired, MinGold, MaxGold, itemString);
		}

		#endregion
	}
}
