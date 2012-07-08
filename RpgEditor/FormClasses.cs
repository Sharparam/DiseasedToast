using System;
using System.IO;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Entities;

namespace RpgEditor
{
	public partial class FormClasses : FormDetails
	{
		#region Fields
		#endregion

		#region Constructors

		public FormClasses()
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
			using (var dataForm = new FormEntityData())
			{
				dataForm.ShowDialog();
				if (dataForm.EntityData != null)
					AddEntity(dataForm.EntityData);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			EntityData data = EntityManager.EntityData[name];
			EntityData newData;
			using (var dataForm = new FormEntityData())
			{
				dataForm.EntityData = data;
				dataForm.ShowDialog();
				if (dataForm.EntityData == null)
					return;

				if (dataForm.EntityData.Name == name)
				{
					EntityManager.EntityData[name] = dataForm.EntityData;
					LoadClasses();
					return;
				}

				newData = dataForm.EntityData;
			}
			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
			                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (EntityManager.EntityData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Entry Exists",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			EntityManager.EntityData.Add(newData.Name, newData);
		}

		private void DeleteButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = ((string) DetailList.SelectedItem).Split(':')[0];
			DialogResult result = MessageBox.Show("Are you sure you want to delete " + name + "?", "Delete Class",
			                                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				DetailList.Items.RemoveAt(DetailList.SelectedIndex);
				EntityManager.EntityData.Remove(name);
				if (File.Exists(FormMain.ClassPath + @"\" + name + ".class"))
					File.Delete(FormMain.ClassPath + @"\" + name + ".class");
			}
		}

		#endregion

		#region Methods

		public void LoadClasses()
		{
			DetailList.Items.Clear();
			foreach (var key in EntityManager.EntityData.Keys)
				DetailList.Items.Add(EntityManager.EntityData[key]);
		}

		private void AddEntity(EntityData data)
		{
			if (EntityManager.EntityData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Do you want to overwrite it?",
				                                      "Existing Character Class", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (result != DialogResult.Yes)
					return;

				EntityManager.EntityData[data.Name] = data;
				LoadClasses();
				return;
			}

			DetailList.Items.Add(data.ToString());

			EntityManager.EntityData.Add(data.Name, data);
		}

		#endregion
	}
}
