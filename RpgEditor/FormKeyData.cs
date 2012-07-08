using System;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormKeyData : Form
	{
		#region Fields
		#endregion

		#region Properties

		public KeyData Key;

		#endregion

		#region Constructors

		public FormKeyData()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormKeyDataLoad(object sender, EventArgs e)
		{
			if (Key == null)
				return;

			NameBox.Text = Key.Name;
			TypeBox.Text = Key.Type;
		}

		private void FormKeyDataFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show("No name specified!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			Key = new KeyData
			{
				Name = NameBox.Text,
				Type = TypeBox.Text
			};

			CloseForm();
		}

		private void FormCancelButtonClick(object sender, EventArgs e)
		{
			Key = null;
			CloseForm();
		}

		private void NameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		#endregion

		#region Methods

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
			FormClosing -= FormKeyDataFormClosing;
			Close();
		}

		#endregion
	}
}
