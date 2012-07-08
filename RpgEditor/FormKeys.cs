using System;
using System.IO;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormKeys : FormDetails
	{
		#region Constructors

		public FormKeys()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void AddButtonClick(object sender, EventArgs e)
		{
			using (var dataForm = new FormKeyData())
			{
				dataForm.ShowDialog();
				if (dataForm.Key != null)
					AddKey(dataForm.Key);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			KeyData data = ItemManager.KeyData[name];
			KeyData newData;

			using (var dataForm = new FormKeyData())
			{
				dataForm.Key = data;
				dataForm.ShowDialog();

				if (dataForm.Key == null)
					return;

				if (dataForm.Key.Name == name)
				{
					ItemManager.KeyData[name] = dataForm.Key;
					LoadKeys();
					return;
				}

				newData = dataForm.Key;
			}

			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
			                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (ItemManager.KeyData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Key Exists",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			ItemManager.KeyData.Add(newData.Name, newData);
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
			ItemManager.KeyData.Remove(name);
			if (File.Exists(FormMain.KeyPath + @"\" + name + ".key"))
				File.Delete(FormMain.KeyPath + @"\" + name + ".key");
		}

		#endregion

		#region Methods

		public void LoadKeys()
		{
			DetailList.Items.Clear();
			foreach (var key in ItemManager.KeyData.Keys)
				DetailList.Items.Add(ItemManager.KeyData[key]);
		}

		private void AddKey(KeyData data)
		{
			if (ItemManager.KeyData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Overwrite it?", "Key Exists",
				                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes)
					return;

				ItemManager.KeyData[data.Name] = data;
				LoadKeys();
				return;
			}

			ItemManager.KeyData.Add(data.Name, data);
			DetailList.Items.Add(data);
		}

		#endregion
	}
}
