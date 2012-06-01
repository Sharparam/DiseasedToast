using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using RpgLibrary.Entities;

namespace RpgEditor
{
	public partial class FormEntityData : Form
	{
		#region Fields

		public EntityData EntityData;

		private readonly Regex _formulaRegex = new Regex(@"^\d+\|\w+\|\d+$");

		#endregion

		#region Constructors

		public FormEntityData()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormEntityDataLoad(object sender, EventArgs e)
		{
			if (EntityData == null)
				return;

			NameBox.Text = EntityData.Name;
			StrengthBox.Value = EntityData.Strength;
			DexterityBox.Value = EntityData.Dexterity;
			CunningBox.Value = EntityData.Cunning;
			WillpowerBox.Value = EntityData.Willpower;
			ConstitutionBox.Value = EntityData.Constitution;
			HealthFormulaBox.Text = EntityData.HealthFormula;
			StaminaFormulaBox.Text = EntityData.StaminaFormula;
			ManaFormulaBox.Text = EntityData.MagicFormula;
		}

		private void FormEntityDataFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show("Name, Health Formula, Stamina Formula and/or Mana Formula cannot be empty!", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			EntityData = new EntityData(
				NameBox.Text,
				(int) StrengthBox.Value,
				(int) DexterityBox.Value,
				(int) CunningBox.Value,
				(int) WillpowerBox.Value,
				(int) MagicBox.Value,
				(int) ConstitutionBox.Value,
				HealthFormulaBox.Text,
				StaminaFormulaBox.Text,
				ManaFormulaBox.Text);

			CloseForm();
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			EntityData = null;
			CloseForm();
		}

		private void NameBoxTextChanged(object sender, EventArgs e)
		{
			//NameBox.Text = NameBox.Text.Trim();
			//NameBox.Select(NameBox.Text.Length, 0);
			ValidateForm();
		}

		private void HealthFormulaBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void StaminaFormulaBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void ManaFormulaBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void NumericUpDownEnter(object sender, EventArgs e)
		{
			var box = sender as NumericUpDown;
			if (box == null)
				return;

			box.Select(0, box.Value.ToString().Length);
		}

		#endregion

		#region Methods

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();
		}

		private bool IsValid()
		{
			return !string.IsNullOrEmpty(NameBox.Text) && !string.IsNullOrEmpty(HealthFormulaBox.Text) &&
				   !string.IsNullOrEmpty(StaminaFormulaBox.Text) && !string.IsNullOrEmpty(ManaFormulaBox.Text) &&
				   _formulaRegex.IsMatch(HealthFormulaBox.Text) && _formulaRegex.IsMatch(StaminaFormulaBox.Text) &&
				   _formulaRegex.IsMatch(ManaFormulaBox.Text);
		}

		private void CloseForm()
		{
			FormClosing -= FormEntityDataFormClosing;
			Close();
		}

		#endregion
	}
}
