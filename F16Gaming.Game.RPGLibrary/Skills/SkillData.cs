using System.Collections.Generic;
using System.Text;

namespace F16Gaming.Game.RPGLibrary.Skills
{
	public class SkillData
	{
		#region Fields

		private const string ToStringFormat = "{0}: {1}{2}";

		public string Name;
		public string PrimaryAttribute;
		public Dictionary<string, int> ClassModifiers;

		#endregion Fields

		#region Properties
		#endregion Properties

		#region Constructors

		public SkillData()
		{
			ClassModifiers = new Dictionary<string, int>();
		}

		#endregion Constructors

		#region Abstract and Virtual Methods

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach (var key in ClassModifiers.Keys)
				sb.Append(", " + key + "<>" + ClassModifiers[key].ToString());

			string modString = sb.Length > 0 ? "; ClassMods: " + sb.ToString().Substring(2) : "";
			return string.Format(ToStringFormat, Name, PrimaryAttribute, modString);
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
