using System.Collections.Generic;

namespace RpgLibrary.Skills
{
	public enum Difficulty
	{
		Master = -25,
		Expert = -10,
		Improved = -5,
		Normal = 0,
		Easy = 10
	}

	public class Skill
	{
		#region Fields

		private const int MinSkillLevel = 0;
		private const int MaxSkillLevel = 100;

		private readonly Dictionary<string, int> _classModifiers;

		#endregion Fields

		#region Properties

		public string Name { get; private set; }
		public int Value { get; private set; }
		public string PrimaryAttribute { get; private set; }
		public Dictionary<string, int> ClassModifiers { get { return _classModifiers; } } 

		#endregion Properties

		#region Constructors

		private Skill()
		{
			Name = "";
			PrimaryAttribute = "";
			_classModifiers = new Dictionary<string, int>();
			Value = 0;
		}

		#endregion Constructors

		#region Methods

		public void Increase(int value = 1)
		{
			Value += value;
			if (Value > MaxSkillLevel)
				Value = MaxSkillLevel;
		}

		public void Decrease(int value = 1)
		{
			Value -= value;
			if (Value < MinSkillLevel)
				Value = MinSkillLevel;
		}

		public static Skill FromSkillData(SkillData data)
		{
			var skill = new Skill
			{
				Name = data.Name,
				Value = 0
			};

			foreach (var key in data.ClassModifiers.Keys)
			{
				skill.ClassModifiers.Add(key, data.ClassModifiers[key]);
			}

			return skill;
		}

		public static int AttributeModifier(int attribute)
		{
			int result = 0;

			if (attribute < 25)
				result = 1;
			else if (attribute < 50)
				result = 2;
			else if (attribute < 75)
				result = 3;
			else if (attribute < 90)
				result = 4;
			else if (attribute < 95)
				result = 5;
			else
				result = 10;

			return result;
		}

		#endregion Methods
	}
}
