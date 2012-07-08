using System;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Skills;
using F16Gaming.Game.RPGLibrary.Spells;
using F16Gaming.Game.RPGLibrary.Talents;

namespace F16Gaming.Game.RPGLibrary.Entities
{
	public enum EntityGender { Male, Female, Unknown }
	public enum EntityType { Character, NPC, Monster, Creature }

	public sealed class Entity
	{
		#region Fields

		//private EntityData _data;

		#endregion

		#region Vital Fields

		public string Name { get; private set; }

		public string Class { get; private set; }

		public EntityType Type { get; private set; }

		public EntityGender Gender { get; private set; }

		#endregion

		#region Basic Attributes and Properties

		private int _strength;
		private int _dexterity;
		private int _cunning;
		private int _willpower;
		private int _magic;
		private int _constitution;

		private int _strengthModifier;
		private int _dexterityModifier;
		private int _cunningModifier;
		private int _willpowerModifier;
		private int _magicModifier;
		private int _constitutionModifier;

		public int Strength
		{
			get { return _strength + _strengthModifier; }
			private set { _strength = value; }
		}

		public int Dexterity
		{
			get { return _dexterity + _dexterityModifier; }
			private set { _dexterity = value; }
		}

		public int Cunning
		{
			get { return _cunning + _cunningModifier; }
			private set { _cunning = value; }
		}

		public int Willpower
		{
			get { return _willpower + _willpowerModifier; }
			private set { _willpower = value; }
		}

		public int Magic
		{
			get { return _magic + _magicModifier; }
			private set { _magic = value; }
		}

		public int Constitution
		{
			get { return _constitution + _constitutionModifier; }
			private set { _constitution = value; }
		}

		#endregion

		#region Calculated Attributes and Properties

		public Attribute Health { get; private set; }

		public Attribute Stamina { get; private set; }

		public Attribute Mana { get; private set; }

		private int _attack;
		private int _damage;
		private int _defense;

		#endregion

		#region Level Fields and Properties

		public int Level { get; private set; }

		public long Experience { get; private set; }

		#endregion

		#region Skill Fields and Properties

		private readonly Dictionary<string, Skill> _skills;
		private readonly List<Modifier> _skillModifiers;
  
		public Dictionary<string, Skill> Skills
		{
			get { return _skills; }
		}

		public List<Modifier> SkillModifiers
		{
			get { return _skillModifiers; }
		}

		#endregion

		#region Spell Fields and Properties

		private readonly Dictionary<string, Spell> _spells;
		private readonly List<Modifier> _spellModifiers;

		public Dictionary<string, Spell> Spells
		{
			get { return _spells; }
		}

		public List<Modifier> SpellModifiers
		{
			get { return _spellModifiers; }
		}

		#endregion

		#region Talent Fields and Properties

		private readonly Dictionary<string, Talent> _talents;
		private readonly List<Modifier> _talentModifiers;
 
		public Dictionary<string, Talent> Talents
		{
			get { return _talents; }
		}

		public List<Modifier> TalentModifiers
		{
			get { return _talentModifiers; }
		}

		#endregion

		#region Constructors

		private Entity()
		{
			Strength = 10;
			Dexterity = 10;
			Cunning = 10;
			Magic = 10;
			Constitution = 10;
			
			Health = new Attribute(0);
			Stamina = new Attribute(0);
			Mana = new Attribute(0);

			_skills = new Dictionary<string, Skill>();
			_spells = new Dictionary<string, Spell>();
			_talents = new Dictionary<string, Talent>();

			_skillModifiers = new List<Modifier>();
			_spellModifiers = new List<Modifier>();
			_talentModifiers = new List<Modifier>();
		}

		public Entity(string name, EntityData data, EntityGender gender, EntityType type) : this()
		{
			Name = name;
			Class = data.Name;
			Gender = gender;
			Type = type;
			Strength = data.Strength;
			Dexterity = data.Dexterity;
			Cunning = data.Cunning;
			Willpower = data.Willpower;
			Magic = data.Magic;
			Constitution = data.Constitution;
		}

		#endregion

		#region Methods

		public void Update(TimeSpan elapsed)
		{
			foreach (var mod in _skillModifiers)
				mod.Update(elapsed);

			foreach (var mod in _spellModifiers)
				mod.Update(elapsed);

			foreach (var mod in _talentModifiers)
				mod.Update(elapsed);
		}

		#endregion
	}
}
