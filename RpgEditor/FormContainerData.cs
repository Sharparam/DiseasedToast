using System;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Items.Data;
using F16Gaming.Game.RPGLibrary.Skills;

namespace RpgEditor
{
	public partial class FormContainerData : Form
	{
		#region Fields

		public ContainerData ContainerData;

		#endregion

		#region Constructors

		public FormContainerData()
		{
			InitializeComponent();

			foreach (var d in Enum.GetNames(typeof(Difficulty)))
				LockDifficultyBox.Items.Add(d);

			LockDifficultyBox.SelectedIndex = 0;
		}

		#endregion

		#region Event Handlers

		private void FormContainerDataLoad(object sender, EventArgs e)
		{
			if (ContainerData == null)
				return;

			NameBox.Text = ContainerData.Name;
			for (int i = 0; i < Enum.GetValues(typeof(Difficulty)).Length; i++)
			{
				if ((int)Enum.GetValues(typeof(Difficulty)).GetValue(i) == (int)ContainerData.Difficulty)
				{
					LockDifficultyBox.SelectedIndex = i;
					break;
				}
			}
			KeyNameBox.Text = ContainerData.KeyName;
			KeyTypeBox.Text = ContainerData.KeyType;
			KeysNeededBox.Value = ContainerData.KeysRequired;
			TrapNameBox.Text = ContainerData.TrapName;
			MinGoldBox.Value = ContainerData.MinGold;
			MaxGoldBox.Value = ContainerData.MaxGold;

			LockCheck.Checked = ContainerData.IsLocked;
			TrapCheck.Checked = ContainerData.IsTrapped;
		}

		private void FormContainerDataFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}

		private void LockCheckCheckedChanged(object sender, EventArgs e)
		{
			LockDifficultyLabel.Enabled = LockCheck.Checked;
			LockDifficultyBox.Enabled = LockCheck.Checked;
			KeyNameLabel.Enabled = LockCheck.Checked;
			KeyNameBox.Enabled = LockCheck.Checked;
			KeyTypeLabel.Enabled = LockCheck.Checked;
			KeyTypeBox.Enabled = LockCheck.Checked;
			KeysNeededLabel.Enabled = LockCheck.Checked;
			KeysNeededBox.Enabled = LockCheck.Checked;

			ValidateForm();
		}

		private void TrapCheckCheckedChanged(object sender, EventArgs e)
		{
			TrapNameLabel.Enabled = TrapCheck.Checked;
			TrapNameBox.Enabled = TrapCheck.Checked;

			ValidateForm();
		}

		private void NameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void KeyNameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void KeysNeededBoxValueChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void TrapNameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void MinGoldBoxValueChanged(object sender, EventArgs e)
		{
			if (MinGoldBox.Value > MaxGoldBox.Value)
				MinGoldBox.Value = MaxGoldBox.Value;

			ValidateForm();
		}

		private void MaxGoldBoxValueChanged(object sender, EventArgs e)
		{
			if (MinGoldBox.Value > MaxGoldBox.Value)
				MinGoldBox.Value = MaxGoldBox.Value;

			ValidateForm();
		}

		private void AddButtonClick(object sender, EventArgs e)
		{

		}

		private void RemoveButtonClick(object sender, EventArgs e)
		{

		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show(
					"Name cannot be empty. Key details must be specified if Locked mode is enabled. Trap details must be specified if Trapped mode is enabled. Minimum gold value cannot be greater than maximum gold value.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var data = new ContainerData
			{
				Name = NameBox.Text,
				IsLocked = LockCheck.Checked,
				IsTrapped = TrapCheck.Checked,
				MinGold = (int) MinGoldBox.Value,
				MaxGold = (int) MaxGoldBox.Value
			};

			if (LockCheck.Checked)
			{
				data.Difficulty = (Difficulty) Enum.GetValues(typeof(Difficulty)).GetValue(LockDifficultyBox.SelectedIndex);
				data.KeyName = KeyNameBox.Text;
				data.KeyType = KeyTypeBox.Text;
				data.KeysRequired = (int) KeysNeededBox.Value;
			}

			if (TrapCheck.Checked)
				data.TrapName = TrapNameBox.Text;

			ContainerData = data;
			CloseForm();
		}

		private void FormCancelButtonClick(object sender, EventArgs e)
		{
			ContainerData = null;
			CloseForm();
		}

		private void NumericUpDownEnter(object sender, EventArgs e)
		{
			var box = sender as NumericUpDown;
			if (box != null)
				box.Select(0, box.Value.ToString().Length);
		}

		#endregion

		#region Methods

		private bool IsTrapValid()
		{
			if (!TrapCheck.Checked)
				return true;

			return !string.IsNullOrEmpty(TrapNameBox.Text);
		}

		private bool IsGoldValid()
		{
			return MinGoldBox.Value <= MaxGoldBox.Value;
		}

		private bool IsValid()
		{
			return !string.IsNullOrEmpty(NameBox.Text) && IsTrapValid() && IsGoldValid();
		}

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();
		}

		private void CloseForm()
		{
			FormClosing -= FormContainerDataFormClosing;
			Close();
		}

		#endregion
	}
}
