using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Items.Data
{
	public class ItemDataManager
	{
		#region Fields

		private readonly Dictionary<string, ArmorData> _armorData = new Dictionary<string, ArmorData>();
		private readonly Dictionary<string, ShieldData> _shieldData = new Dictionary<string, ShieldData>();
		private readonly Dictionary<string, WeaponData> _weaponData = new Dictionary<string, WeaponData>();
		private readonly Dictionary<string, ReagentData> _reagentData = new Dictionary<string, ReagentData>();
		private readonly Dictionary<string, KeyData> _keyData = new Dictionary<string, KeyData>();
		private readonly Dictionary<string, ContainerData> _containerData = new Dictionary<string, ContainerData>(); 

		#endregion

		#region Properties

		public Dictionary<string, ArmorData> ArmorData
		{
			get { return _armorData; }
		}

		public Dictionary<string, ShieldData> ShieldData
		{
			get { return _shieldData; }
		}

		public Dictionary<string, WeaponData> WeaponData
		{
			get { return _weaponData; }
		}

		public Dictionary<string, ReagentData> ReagentData
		{
			get { return _reagentData; }
		}

		public Dictionary<string, KeyData> KeyData
		{
			get { return _keyData; }
		}

		public Dictionary<string, ContainerData> ContainerData
		{
			get { return _containerData; }
		}

		#endregion

		#region Constructors
		#endregion

		#region Methods
		#endregion
	}
}
