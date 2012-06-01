using System.IO;
using System.Linq;
using System.Windows.Forms;

using RpgLibrary.Skills;
using RpgLibrary.Entities;
using RpgLibrary.Items.Data;
using RpgLibrary.Serializing;

namespace RpgEditor
{
	public partial class FormDetails : Form
	{
		#region Fields

		#endregion

		#region Properties

		public static ItemDataManager ItemManager { get; private set; }
		public static EntityDataManager EntityManager { get; private set; }
		public static SkillDataManager SkillManager { get; private set; }

		#endregion

		#region Constructors

		protected FormDetails()
		{
			InitializeComponent();

			if (ItemManager == null)
				ItemManager = new ItemDataManager();

			if (EntityManager == null)
				EntityManager = new EntityDataManager();

			if (SkillManager == null)
				SkillManager = new SkillDataManager();
		}

		#endregion

		#region Event Handlers

		private void FormDetailsFormClosing(object sender, FormClosingEventArgs e)
		{
			switch (e.CloseReason)
			{
				case CloseReason.UserClosing:
					e.Cancel = true;
					Hide();
					break;
				default:
					e.Cancel = false;
					Close();
					break;
			}
		}

		#endregion

		#region Methods

		public static void ReadEntityData()
		{
			if (EntityManager == null)
				EntityManager = new EntityDataManager();

			string[] fileNames = Directory.GetFiles(FormMain.ClassPath, "*.class");

			foreach (var file in fileNames)
			{
				var data = Serializer.Deserialize<EntityData>(file);
				EntityManager.EntityData.Add(data.Name, data);
			}
		}

		public static void ReadItemData()
		{
			if (ItemManager == null)
				ItemManager = new ItemDataManager();

			string[] files = Directory.GetFiles(FormMain.ArmorPath, "*.armor");

			foreach (var data in files.Select(Serializer.Deserialize<ArmorData>))
				ItemManager.ArmorData.Add(data.Name, data);

			files = Directory.GetFiles(FormMain.ShieldPath, "*.shield");

			foreach (var data in files.Select(Serializer.Deserialize<ShieldData>))
				ItemManager.ShieldData.Add(data.Name, data);

			files = Directory.GetFiles(FormMain.WeaponPath, "*.weapon");

			foreach (var data in files.Select(Serializer.Deserialize<WeaponData>))
				ItemManager.WeaponData.Add(data.Name, data);
		}

		public static void ReadKeyData()
		{
			if (ItemManager == null)
				ItemManager = new ItemDataManager();

			string[] files = Directory.GetFiles(FormMain.KeyPath, "*.key");
			foreach (var data in files.Select(Serializer.Deserialize<KeyData>))
				ItemManager.KeyData.Add(data.Name, data);
		}

		public static void ReadContainerData()
		{
			if (ItemManager == null)
				ItemManager = new ItemDataManager();

			string[] files = Directory.GetFiles(FormMain.ContainerPath, "*.container");
			foreach (var data in files.Select(Serializer.Deserialize<ContainerData>))
				ItemManager.ContainerData.Add(data.Name, data);
		}

		public static void WriteEntityData()
		{
			foreach (var key in EntityManager.EntityData.Keys)
				Serializer.Serialize(EntityManager.EntityData[key], FormMain.ClassPath + @"\" + key + ".class");
		}

		public static void ReadSkillData()
		{
			if (SkillManager == null)
				SkillManager = new SkillDataManager();

			string[] files = Directory.GetFiles(FormMain.SkillPath, "*.skill");

			foreach (var data in files.Select(Serializer.Deserialize<SkillData>))
				SkillManager.SkillData.Add(data.Name, data);
		}

		public static void WriteItemData()
		{
			foreach (var key in ItemManager.ArmorData.Keys)
				Serializer.Serialize(ItemManager.ArmorData[key], FormMain.ArmorPath + @"\" + key + ".armor");

			foreach (var key in ItemManager.ShieldData.Keys)
				Serializer.Serialize(ItemManager.ShieldData[key], FormMain.ShieldPath + @"\" + key + ".shield");

			foreach (var key in ItemManager.WeaponData.Keys)
				Serializer.Serialize(ItemManager.WeaponData[key], FormMain.WeaponPath + @"\" + key + ".weapon");
		}

		public static void WriteKeyData()
		{
			foreach (var key in ItemManager.KeyData.Keys)
				Serializer.Serialize(ItemManager.KeyData[key], FormMain.KeyPath + @"\" + key + ".key");
		}

		public static void WriteContainerData()
		{
			foreach (var key in ItemManager.ContainerData.Keys)
				Serializer.Serialize(ItemManager.ContainerData[key], FormMain.ContainerPath + @"\" + key + ".container");
		}

		public static void WriteSkillData()
		{
			foreach (var key in SkillManager.SkillData.Keys)
				Serializer.Serialize(SkillManager.SkillData[key], FormMain.SkillPath + @"\" + key + ".skill");
		}

		#endregion
	}
}
