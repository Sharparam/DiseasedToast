using System;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary;

namespace RpgEditor
{
	public partial class FormNewGame : Form
	{
		#region Fields

		#endregion

		#region Properties

		public RolePlayingGame RolePlayingGame { get; private set; }

		#endregion

		#region Constructors

		public FormNewGame()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handling

		private void NameBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void DescriptionBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(DescriptionBox.Text))
			{
				MessageBox.Show("Name and/or Description cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			RolePlayingGame = new RolePlayingGame(NameBox.Text, DescriptionBox.Text);
			Close();
		}

		#endregion

		#region Methods

		private void ValidateForm()
		{
			OkButton.Enabled = !string.IsNullOrEmpty(NameBox.Text) && !string.IsNullOrEmpty(DescriptionBox.Text);
		}

		#endregion
	}
}
