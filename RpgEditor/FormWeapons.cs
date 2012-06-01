using System;
using System.IO;
using System.Windows.Forms;

using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormWeapons : FormDetails
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Constructors

		public FormWeapons()
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
			using (var dataForm = new FormWeaponData())
			{
				dataForm.ShowDialog();
				if (dataForm.Weapon != null)
					AddWeapon(dataForm.Weapon);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			WeaponData data = ItemManager.WeaponData[name];
			WeaponData newData;
			using (var dataForm = new FormWeaponData())
			{
				dataForm.Weapon = data;
				dataForm.ShowDialog();

				if (dataForm.Weapon == null)
					return;

				if (dataForm.Weapon.Name == name)
				{
					ItemManager.WeaponData[name] = dataForm.Weapon;
					LoadWeapons();
					return;
				}

				newData = dataForm.Weapon;
			}

			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
												  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (ItemManager.WeaponData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Entry Exists",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			ItemManager.WeaponData.Add(newData.Name, newData);
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
			ItemManager.WeaponData.Remove(name);
			if (File.Exists(FormMain.WeaponPath + @"\" + name + ".weapon"))
				File.Delete(FormMain.WeaponPath + @"\" + name + ".weapon");
		}

		#endregion

		#region Methods

		public void LoadWeapons()
		{
			DetailList.Items.Clear();
			foreach (var key in ItemManager.WeaponData.Keys)
				DetailList.Items.Add(ItemManager.WeaponData[key]);
		}

		private void AddWeapon(WeaponData data)
		{
			if (ItemManager.WeaponData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Do you want to overwrite it?",
													  "Existing Weapon", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result != DialogResult.Yes)
					return;

				ItemManager.WeaponData[data.Name] = data;
				LoadWeapons();
				return;
			}

			DetailList.Items.Add(data.ToString());

			ItemManager.WeaponData.Add(data.Name, data);
		}

		#endregion
	}
}
