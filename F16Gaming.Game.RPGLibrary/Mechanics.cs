using System;
using System.Linq;
using F16Gaming.Game.RPGLibrary.Entities;
using F16Gaming.Game.RPGLibrary.Skills;

namespace F16Gaming.Game.RPGLibrary
{
	public enum DiceType
	{
		D4 = 4,
		D6 = 6,
		D8 = 8,
		D10 = 10,
		D12 = 12,
		D20 = 20,
		D100 = 100
	}

	public class Mechanics
	{
		#region Fields

		private static readonly Random Rand = new Random();

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Constructors

		#endregion Constructors

		#region Methods

		public static int RollDice(DiceType dice)
		{
			return Rand.Next(0, (int) dice) + 1;
		}

		public static bool UseSkill(Skill skill, Entity entity, Difficulty difficulty)
		{
			int target = skill.Value + (int) difficulty
				+ skill.ClassModifiers.Keys.Where(key => key == entity.Class).Sum(key => skill.ClassModifiers[key])
				+ entity.SkillModifiers.Where(mod => mod.Modifying == skill.Name).Sum(mod => mod.Amount);

			switch(skill.PrimaryAttribute.ToLower())
			{
				case "strength":
					target += Skill.AttributeModifier(entity.Strength);
					break;
				case "dexterity":
					target += Skill.AttributeModifier(entity.Dexterity);
					break;
				case "cunning":
					target += Skill.AttributeModifier(entity.Cunning);
					break;
				case "willpower":
					target += Skill.AttributeModifier(entity.Willpower);
					break;
				case "magic":
					target += Skill.AttributeModifier(entity.Magic);
					break;
				case "constitution":
					target += Skill.AttributeModifier(entity.Constitution);
					break;
			}

			return RollDice(DiceType.D100) <= target;
		}

		#endregion Methods
	}
}
