using System;
using System.IO;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Skills;

namespace RpgEditor
{
	public partial class FormSkills : FormDetails
	{
		#region Constructors

		public FormSkills()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void AddButtonClick(object sender, EventArgs e)
		{
			using (var dataForm = new FormSkillData())
			{
				dataForm.ShowDialog();
				if (dataForm.Skill != null)
					AddSkill(dataForm.Skill);
			}
		}

		private void EditButtonClick(object sender, EventArgs e)
		{
			if (DetailList.SelectedItem == null)
				return;

			string name = DetailList.SelectedItem.ToString().Split(':')[0];
			var data = SkillManager.SkillData[name];
			SkillData newData;

			using (var dataForm = new FormSkillData())
			{
				dataForm.Skill = data;
				dataForm.ShowDialog();
				if (dataForm.Skill == null)
					return;

				if (dataForm.Skill.Name == name)
				{
					SkillManager.SkillData[name] = dataForm.Skill;
					LoadSkills();
					return;
				}

				newData = dataForm.Skill;
			}

			DialogResult result = MessageBox.Show("Name has changed. Do you want to add a new entry?", "New Entry",
												  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			if (SkillManager.SkillData.ContainsKey(newData.Name))
			{
				MessageBox.Show("Entry already exists. Use Edit to modify the entry.", "Skill Exists",
								MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DetailList.Items.Add(newData);
			SkillManager.SkillData.Add(newData.Name, newData);
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
			SkillManager.SkillData.Remove(name);
			if (File.Exists(FormMain.SkillPath + @"\" + name + ".skill"))
				File.Delete(FormMain.SkillPath + @"\" + name + ".skill");
		}

		#endregion

		#region Methods

		public void LoadSkills()
		{
			DetailList.Items.Clear();
			foreach (var key in SkillManager.SkillData.Keys)
				DetailList.Items.Add(SkillManager.SkillData[key]);
		}

		private void AddSkill(SkillData data)
		{
			if (SkillManager.SkillData.ContainsKey(data.Name))
			{
				DialogResult result = MessageBox.Show(data.Name + " already exists. Overwrite it?", "Skill Exists",
													  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result != DialogResult.Yes)
					return;

				SkillManager.SkillData[data.Name] = data;
				LoadSkills();
				return;
			}

			SkillManager.SkillData.Add(data.Name, data);
			DetailList.Items.Add(data);
		}

		#endregion
	}
}
