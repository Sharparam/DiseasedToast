using System;
using System.Linq;
using System.Windows.Forms;

using RpgLibrary.Items;
using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormArmorData : Form
	{
		#region Fields

		public ArmorData Armor;

		#endregion

		#region Constructors

		public FormArmorData()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormArmorDetailLoad(object sender, EventArgs e)
		{
			foreach (var key in FormDetails.EntityManager.EntityData.Keys)
				ClassList.Items.Add(key);

			foreach (var loc in Enum.GetValues(typeof(ArmorLocation)))
				ArmorLocationBox.Items.Add(loc);

			ArmorLocationBox.SelectedIndex = 0;

			if (Armor == null)
				return;

			NameBox.Text = Armor.Name;
			TypeBox.Text = Armor.Type;
			PriceBox.Value = Armor.Price;
			WeightBox.Value = (decimal) Armor.Weight;
			ArmorLocationBox.SelectedIndex = (int) Armor.ArmorLocation;
			DefenseValueBox.Value = Armor.DefenseValue;
			DefenseModifierBox.Value = Armor.DefenseModifier;

			foreach (var c in Armor.AllowedClasses)
			{
				if (ClassList.Items.Contains(c))
					ClassList.Items.Remove(c);

				AllowedList.Items.Add(c);
			}
		}

		private void FormArmorDetailFormClosing(object sender, FormClosingEventArgs e)
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

			var allowed = (from object item in AllowedList.Items select item.ToString()).ToList();
			Armor = new ArmorData
			{
				Name = NameBox.Text,
				Type = TypeBox.Text,
				Price = (int) PriceBox.Value,
				Weight = (float) WeightBox.Value,
				ArmorLocation = (ArmorLocation) ArmorLocationBox.SelectedIndex,
				DefenseValue = (int) DefenseValueBox.Value,
				DefenseModifier = (int) DefenseModifierBox.Value,
				AllowedClasses = allowed.ToArray()
			};

			CloseForm();
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			Armor = null;
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
			FormClosing -= FormArmorDetailFormClosing;
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
