using System;
using System.IO;
using System.Windows.Forms;

using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormArmor : FormDetails
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Constructors

		public FormArmor()
		{
			InitializeComponent();

			AddButton.Click += AddButtonClick;
			EditButton.Click += EditButtonClick;
			DeleteButton.Click += DeleteButtonClick;
		}

		#endregion

		#region Button Event Handlers

		private void AddButtonClick(object sender, EventArgs e)
		{
			using (var dataForm = new FormArmorData())
			{
				dataForm.ShowDialog();
				if (dataForm.Armor != null)
					AddArmor(dataForm.Armor);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			ArmorData data = ItemManager.ArmorData[name];
			ArmorData newData;
			using (var dataForm = new FormArmorData())
			{
				dataForm.Armor = data;
				dataForm.ShowDialog();

				if (dataForm.Armor == null)
					return;

				if (dataForm.Armor.Name == name)
				{
					ItemManager.ArmorData[name] = dataForm.Armor;
					LoadArmor();
					return;
				}

				newData = dataForm.Armor;
			}

			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
			                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (ItemManager.ArmorData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Entry Exists",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			ItemManager.ArmorData.Add(newData.Name, newData);
		}

		private void DeleteButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			DialogResult result = MessageBox.Show("Are you sure you want to delete " + name + "?", "Delete",
			                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			DetailList.Items.RemoveAt(DetailList.SelectedIndex);
			ItemManager.ArmorData.Remove(name);
			if (File.Exists(FormMain.ArmorPath + @"\" + name + ".armor"))
				File.Delete(FormMain.ArmorPath + @"\" + name + ".armor");
		}

		#endregion

		#region Methods

		public void LoadArmor()
		{
			DetailList.Items.Clear();
			foreach (var key in ItemManager.ArmorData.Keys)
				DetailList.Items.Add(ItemManager.ArmorData[key]);
		}

		private void AddArmor(ArmorData data)
		{
			if (ItemManager.ArmorData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Do you want to overwrite it?",
													  "Existing Armor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result != DialogResult.Yes)
					return;

				ItemManager.ArmorData[data.Name] = data;
				LoadArmor();
				return;
			}

			DetailList.Items.Add(data.ToString());
			ItemManager.ArmorData.Add(data.Name, data);
		}

		#endregion
	}
}
