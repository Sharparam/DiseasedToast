using System.Collections.Generic;

namespace RpgLibrary.Items
{
	public class ItemManager
	{
		#region Fields

		private Dictionary<string, Weapon> _weapons = new Dictionary<string, Weapon>();
		private Dictionary<string, Armor> _armor = new Dictionary<string, Armor>();
		private Dictionary<string, Shield> _shields = new Dictionary<string, Shield>();

		#endregion

		#region Properties

		public Dictionary<string, Weapon>.KeyCollection WeaponKeys
		{
			get { return _weapons.Keys; }
		}

		public Dictionary<string, Armor>.KeyCollection ArmorKeys
		{
			get { return _armor.Keys; }
		}

		public Dictionary<string, Shield>.KeyCollection ShieldKeys
		{
			get { return _shields.Keys; }
		}

		#endregion

		#region Constructors

		public ItemManager()
		{
			
		}

		#endregion

		#region Weapon Methods

		public void AddWeapon(Weapon weapon)
		{
			if (!_weapons.ContainsKey(weapon.Name))
				_weapons.Add(weapon.Name, weapon);
		}

		public Weapon GetWeapon(string name)
		{
			if (_weapons.ContainsKey(name))
				return (Weapon) _weapons[name].Clone();

			return null;
		}

		public bool ContainsWeapon(string name)
		{
			return _weapons.ContainsKey(name);
		}

		#endregion

		#region Armor Methods

		public void AddArmor(Armor armor)
		{
			if (!_armor.ContainsKey(armor.Name))
				_armor.Add(armor.Name, armor);
		}

		public Armor GetArmor(string name)
		{
			if (_armor.ContainsKey(name))
				return (Armor) _armor[name].Clone();

			return null;
		}

		public bool ContainsArmor(string name)
		{
			return _armor.ContainsKey(name);
		}

		#endregion

		#region Shield Methods

		public void AddShield(Shield shield)
		{
			if (!_shields.ContainsKey(shield.Name))
				_shields.Add(shield.Name, shield);
		}

		public Shield GetShield(string name)
		{
			if (_shields.ContainsKey(name))
				return (Shield) _shields[name].Clone();

			return null;
		}

		public bool ContainsShield(string name)
		{
			return _shields.ContainsKey(name);
		}

		#endregion
	}
}
