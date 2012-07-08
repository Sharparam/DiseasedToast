using System;
using System.IO;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Entities;
using F16Gaming.Game.RPGLibrary.Items.Data;
using F16Gaming.Game.RPGLibrary.Logging;
using F16Gaming.Game.RPGLibrary.Serializing;
using F16Gaming.Game.RPGLibrary.Skills;

namespace DiseasedToast
{
	internal static class DataManager
	{
		#region Paths

		private static readonly log4net.ILog Log = LogManager.GetLogger(typeof (DataManager));

		private const string GameFolder = "Game";
		private const string ClassFolder = "Classes";
		private const string ItemFolder = "Items";
		private const string ArmorFolder = "Armor";
		private const string WeaponFolder = "Weapons";
		private const string ShieldFolder = "Shields";
		private const string KeyFolder = "Keys";
		private const string ContainerFolder = "Containers";
		private const string SkillFolder = "Skills";

		private static readonly string GamePath = GameFolder;
		private static string ClassPath { get { return Path.Combine(GamePath, ClassFolder); } }
		private static string ItemPath { get { return Path.Combine(GamePath, ItemFolder); } }
		private static string ArmorPath { get { return Path.Combine(ItemPath, ArmorFolder); } }
		private static string WeaponPath { get { return Path.Combine(ItemPath, WeaponFolder); } }
		private static string ShieldPath { get { return Path.Combine(ItemPath, ShieldFolder); } }
		private static string KeyPath { get { return Path.Combine(GamePath, KeyFolder); } }
		private static string ContainerPath { get { return Path.Combine(GamePath, ContainerFolder); }}
		private static string SkillPath { get { return Path.Combine(GamePath, SkillFolder); } }

		#endregion

		#region Fields

		private static readonly Dictionary<string, EntityData> Entities = new Dictionary<string, EntityData>();
		private static readonly Dictionary<string, ArmorData> Armor = new Dictionary<string, ArmorData>();
		private static readonly Dictionary<string, WeaponData> Weapons = new Dictionary<string, WeaponData>();
		private static readonly Dictionary<string, ShieldData> Shields = new Dictionary<string, ShieldData>();
		private static readonly Dictionary<string, KeyData> Keys = new Dictionary<string, KeyData>();
		private static readonly Dictionary<string, ContainerData> Containers = new Dictionary<string, ContainerData>();
		private static readonly Dictionary<string, SkillData> Skills = new Dictionary<string, SkillData>();

		#endregion

		#region Properties

		public static Dictionary<string, EntityData> EntityData
		{
			get { return Entities; }
		}

		public static Dictionary<string, ArmorData> ArmorData
		{
			get { return Armor; }
		}

		public static Dictionary<string, WeaponData> WeaponData
		{
			get { return Weapons; }
		}

		public static Dictionary<string, ShieldData> ShieldData
		{
			get { return Shields; }
		}

		public static Dictionary<string, KeyData> KeyData
		{
			get { return Keys; }
		}

		public static Dictionary<string, ContainerData> ContainerData
		{
			get { return Containers; }
		}

		public static Dictionary<string, SkillData> SkillData
		{
			get { return Skills; }
		}

		#endregion

		#region Read Methods

		public static void ReadAllData()
		{
			Log.Info("Loading game data...");
			ReadEntityData();
			ReadArmorData();
			ReadWeaponData();
			ReadShieldData();
			ReadKeyData();
			ReadContainerData();
			ReadSkillData();
			Log.Debug("Game data loaded.");
		}

		public static void ReadEntityData()
		{
			Log.Info("Loading Entity data...");
			string[] files = Directory.GetFiles(ClassPath, "*.class");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<EntityData>(file);
				EntityData.Add(data.Name, data);
			}
			Log.Debug("Entity Data loaded.");
		}

		public static void ReadArmorData()
		{
			Log.Info("Loading Armor data...");
			string[] files = Directory.GetFiles(ArmorPath, "*.armor");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<ArmorData>(file);
				ArmorData.Add(data.Name, data);
			}
			Log.Debug("Armor data loaded.");
		}

		public static void ReadWeaponData()
		{
			Log.Info("Loading Weapon data...");
			string[] files = Directory.GetFiles(WeaponPath, "*.weapon");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<WeaponData>(file);
				WeaponData.Add(data.Name, data);
			}
			Log.Debug("Weapon data loaded.");
		}

		public static void ReadShieldData()
		{
			Log.Info("Loading Shield data...");
			string[] files = Directory.GetFiles(ShieldPath, "*.shield");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<ShieldData>(file);
				ShieldData.Add(data.Name, data);
			}
			Log.Debug("Shield data loaded.");
		}

		public static void ReadKeyData()
		{
			Log.Info("Loading Key data...");
			string[] files = Directory.GetFiles(KeyPath, "*.key");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<KeyData>(file);
				KeyData.Add(data.Name, data);
			}
			Log.Debug("Key data loaded.");
		}

		public static void ReadContainerData()
		{
			Log.Info("Loading Container data...");
			string[] files = Directory.GetFiles(ContainerPath, "*.container");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<ContainerData>(file);
				ContainerData.Add(data.Name, data);
			}
			Log.Debug("Container data loaded.");
		}

		public static void ReadSkillData()
		{
			Log.Info("Loading Skill data...");
			string[] files = Directory.GetFiles(SkillPath, "*.skill");
			foreach (var file in files)
			{
				var data = Serializer.Deserialize<SkillData>(file);
				SkillData.Add(data.Name, data);
			}
			Log.Debug("Skill data loaded.");
		}

		#endregion
	}
}
