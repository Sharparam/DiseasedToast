using System;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Skills;

namespace RpgEditor
{
	public partial class FormSkillData : Form
	{
		#region Fields

		public SkillData Skill;

		#endregion

		#region Constructors

		public FormSkillData()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormSkillDataLoad(object sender, EventArgs e)
		{
			if (Skill == null)
				return;

			StrengthButton.Checked = false;
			DexterityButton.Checked = false;
			CunningButton.Checked = false;
			WillpowerButton.Checked = false;
			MagicButton.Checked = false;
			ConstitutionButton.Checked = false;

			NameBox.Text = Skill.Name;
			switch (Skill.PrimaryAttribute.ToLower())
			{
				case "strength":
					StrengthButton.Checked = true;
					break;
				case "dexterity":
					DexterityButton.Checked = true;
					break;
				case "cunning":
					CunningButton.Checked = true;
					break;
				case "willpower":
					WillpowerButton.Checked = true;
					break;
				case "magic":
					MagicButton.Checked = true;
					break;
				case "constitution":
					ConstitutionButton.Checked = true;
					break;
				default:
					StrengthButton.Checked = true;
					break;
			}

			foreach (var key in Skill.ClassModifiers.Keys)
				ModifierList.Items.Add(key + ": " + Skill.ClassModifiers[key]);
		}

		private void FormSkillDataFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}

		private void NameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void AddButtonClick(object sender, EventArgs e)
		{

		}

		private void EditButtonClick(object sender, EventArgs e)
		{

		}

		private void RemoveButtonClick(object sender, EventArgs e)
		{

		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show("Name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var newSkill = new SkillData {Name = NameBox.Text};

			if (StrengthButton.Checked)
				newSkill.PrimaryAttribute = "Strength";
			else if (DexterityButton.Checked)
				newSkill.PrimaryAttribute = "Dexterity";
			else if (CunningButton.Checked)
				newSkill.PrimaryAttribute = "Cunning";
			else if (WillpowerButton.Checked)
				newSkill.PrimaryAttribute = "Willpower";
			else if (MagicButton.Checked)
				newSkill.PrimaryAttribute = "Magic";
			else if (ConstitutionButton.Checked)
				newSkill.PrimaryAttribute = "Constitution";
			else
				newSkill.PrimaryAttribute = "Strength";

			Skill = newSkill;

			CloseForm();
		}

		private void FormCancelButtonClick(object sender, EventArgs e)
		{
			Skill = null;
			CloseForm();
		}

		#endregion

		#region

		private bool IsValid()
		{
			return !string.IsNullOrEmpty(NameBox.Text);
		}

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();
		}

		private void CloseForm()
		{
			FormClosing -= FormSkillDataFormClosing;
			Close();
		}

		#endregion
	}
}
