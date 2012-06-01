using System;
using System.IO;
using System.Windows.Forms;

using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormContainers : FormDetails
	{
		#region Constructors

		public FormContainers()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void AddButtonClick(object sender, EventArgs e)
		{
			using (var dataForm = new FormContainerData())
			{
				dataForm.ShowDialog();
				if (dataForm.ContainerData != null)
					AddContainer(dataForm.ContainerData);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			ContainerData data = ItemManager.ContainerData[name];
			ContainerData newData;

			using (var dataForm = new FormContainerData())
			{
				dataForm.ContainerData = data;
				dataForm.ShowDialog();

				if (dataForm.ContainerData == null)
					return;

				if (dataForm.ContainerData.Name == name)
				{
					ItemManager.ContainerData[name] = dataForm.ContainerData;
					LoadContainers();
					return;
				}

				newData = dataForm.ContainerData;
			}

			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
												  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (ItemManager.ContainerData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Container Exists",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			ItemManager.ContainerData.Add(newData.Name, newData);
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
			ItemManager.ContainerData.Remove(name);
			if (File.Exists(FormMain.ContainerPath + @"\" + name + ".container"))
				File.Delete(FormMain.ContainerPath + @"\" + name + ".container");
		}

		#endregion

		#region Methods

		public void LoadContainers()
		{
			DetailList.Items.Clear();
			foreach (var key in ItemManager.ContainerData.Keys)
				DetailList.Items.Add(ItemManager.ContainerData[key]);
		}

		private void AddContainer(ContainerData data)
		{
			if (ItemManager.ContainerData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Overwrite it?", "Container Exists",
													  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes)
					return;

				ItemManager.ContainerData[data.Name] = data;
				LoadContainers();
				return;
			}

			ItemManager.ContainerData.Add(data.Name, data);
			DetailList.Items.Add(data);
		}

		#endregion
	}
}
