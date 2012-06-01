using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RpgLibrary.World;

namespace XRpgEditor
{
	public partial class FormNewLevel : Form
	{
		#region Fields

		#endregion

		#region Properties

		public bool OkPressed { get; private set; }
		public LevelData LevelData { get; private set; }

		#endregion

		#region Constructors

		public FormNewLevel()
		{
			InitializeComponent();

			SetDefaultValues();
		}

		#endregion

		#region Event Handlers

		private void NumericUpDownLeave(object sender, EventArgs e)
		{
			((NumericUpDown)sender).Value = Math.Floor(((NumericUpDown)sender).Value);
		}

		private void LevelNameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void MapNameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void MapWidthBoxValueChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void MapHeightBoxValueChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void TextBoxEnter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void NumericUpDownEnter(object sender, EventArgs e)
		{
			((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Value.ToString().Length);
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show("Level/Map name cannot be empty, width and height must be greater than zero!", "Error",
				                MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			LevelData = new LevelData(
				LevelNameBox.Text,
				MapNameBox.Text,
				(int) MapWidthBox.Value,
				(int) MapHeightBox.Value,
				new List<string>(),
				new List<string>(),
				new List<string>()
			);

			OkPressed = true;
			Close();
		}

		private void FormCancelButtonClick(object sender, EventArgs e)
		{
			OkPressed = false;
			Close();
		}

		#endregion

		#region Methods

		private bool IsValid()
		{
			return !string.IsNullOrEmpty(LevelNameBox.Text) && !string.IsNullOrEmpty(MapNameBox.Text) && MapWidthBox.Value > 0 && MapHeightBox.Value > 0;
		}

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();
		}

		private void SetDefaultValues()
		{
			LevelNameBox.Text = "New Level";
			MapNameBox.Text = "New Map";
			MapWidthBox.Value = 100;
			MapHeightBox.Value = 100;
		}

		#endregion
	}
}
