using System;
using System.Linq;
using System.Windows.Forms;

using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormShieldData : Form
	{
		#region Fields

		public ShieldData Shield;

		#endregion

		#region Constructors

		public FormShieldData()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormShieldDetailLoad(object sender, EventArgs e)
		{
			foreach (var key in FormDetails.EntityManager.EntityData.Keys)
				ClassList.Items.Add(key);

			if (Shield == null)
				return;

			NameBox.Text = Shield.Name;
			TypeBox.Text = Shield.Type;
			PriceBox.Value = Shield.Price;
			WeightBox.Value = (decimal) Shield.Weight;
			DefenseValueBox.Value = Shield.DefenseValue;
			DefenseModifierBox.Value = Shield.DefenseModifier;

			foreach (var c in Shield.AllowedClasses)
			{
				if (ClassList.Items.Contains(c))
					ClassList.Items.Remove(c);

				AllowedList.Items.Add(c);
			}
		}

		private void FormShieldDetailFormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				e.Cancel = true;
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid() || AllowedList.Items.Count <= 0)
			{
				MessageBox.Show("Name and/or Type cannot be empty, there must be at least one allowed class!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var allowed = (from object c in AllowedList.Items select c.ToString()).ToList();
			Shield = new ShieldData
			{
				Name = NameBox.Text,
				Type = TypeBox.Text,
				Price = (int) PriceBox.Value,
				Weight = (float) WeightBox.Value,
				DefenseValue = (int) DefenseValueBox.Value,
				DefenseModifier = (int) DefenseModifierBox.Value,
				AllowedClasses = allowed.ToArray()
			};

			CloseForm();
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			Shield = null;
			CloseForm();
		}

		private void NameBoxTextChanged(object sender, EventArgs e)
		{
			//NameBox.Text = NameBox.Text.Trim();
			//NameBox.Select(NameBox.Text.Length, 0);
			ValidateForm();
		}

		private void TypeBoxTextChanged(object sender, EventArgs e)
		{
			ValidateForm();
		}

		private void AddButtonClick(object sender, EventArgs e)
		{
			AddClass();
		}

		private void RemoveButtonClick(object sender, EventArgs e)
		{
			RemoveClass();
		}

		private void ClassListDoubleClick(object sender, EventArgs e)
		{
			AddClass();
		}

		private void AllowedListDoubleClick(object sender, EventArgs e)
		{
			RemoveClass();
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
		
		private bool IsValid()
		{
			return !string.IsNullOrEmpty(NameBox.Text) && !string.IsNullOrEmpty(TypeBox.Text);
		}

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();
		}

		private void CloseForm()
		{
			FormClosing -= FormShieldDetailFormClosing;
			Close();
		}

		private void AddClass()
		{
			if (ClassList.SelectedItem == null)
				return;

			AllowedList.Items.Add(ClassList.SelectedItem);
			ClassList.Items.RemoveAt(ClassList.SelectedIndex);
		}

		private void RemoveClass()
		{
			if (AllowedList.SelectedItem == null)
				return;

			ClassList.Items.Add(AllowedList.SelectedItem);
			AllowedList.Items.RemoveAt(AllowedList.SelectedIndex);
		}

		#endregion
	}
}
