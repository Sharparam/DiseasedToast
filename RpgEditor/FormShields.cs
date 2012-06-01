using System;
using System.IO;
using System.Windows.Forms;

using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormShields : FormDetails
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Constructors

		public FormShields()
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
			using (var dataForm = new FormShieldData())
			{
				dataForm.ShowDialog();
				if (dataForm.Shield != null)
					AddShield(dataForm.Shield);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			ShieldData data = ItemManager.ShieldData[name];
			ShieldData newData;
			using (var dataForm = new FormShieldData())
			{
				dataForm.Shield = data;
				dataForm.ShowDialog();

				if (dataForm.Shield == null)
					return;

				if (dataForm.Shield.Name == name)
				{
					ItemManager.ShieldData[name] = dataForm.Shield;
					LoadShields();
					return;
				}

				newData = dataForm.Shield;
			}

			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
			                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (ItemManager.ShieldData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Entry Exists",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			ItemManager.ShieldData.Add(newData.Name, newData);
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
			ItemManager.ShieldData.Remove(name);
			if (File.Exists(FormMain.ShieldPath + @"\" + name + ".shield"))
				File.Delete(FormMain.ShieldPath + @"\" + name + ".shield");
		}

		#endregion

		#region Methods

		public void LoadShields()
		{
			DetailList.Items.Clear();
			foreach (var key in ItemManager.ShieldData.Keys)
				DetailList.Items.Add(ItemManager.ShieldData[key]);
		}

		private void AddShield(ShieldData data)
		{
			if (ItemManager.ShieldData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Do you want to overwrite it?",
													  "Existing Shield", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result != DialogResult.Yes)
					return;

				ItemManager.ShieldData[data.Name] = data;
				LoadShields();
				return;
			}

			DetailList.Items.Add(data.ToString());

			ItemManager.ShieldData.Add(data.Name, data);
		}

		#endregion
	}
}
