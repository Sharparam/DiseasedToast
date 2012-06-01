using System;
using System.Linq;
using System.Windows.Forms;

using RpgLibrary.Items;
using RpgLibrary.Items.Data;

namespace RpgEditor
{
	public partial class FormWeaponData : Form
	{
		#region Fields

		public WeaponData Weapon;

		#endregion

		#region Constructors

		public FormWeaponData()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormWeaponDetailsLoad(object sender, EventArgs e)
		{
			foreach (var c in FormDetails.EntityManager.EntityData.Keys)
				ClassList.Items.Add(c);

			foreach (var h in Enum.GetValues(typeof(Hands)))
				HandsBox.Items.Add(h);

			HandsBox.SelectedIndex = 0;

			if (Weapon == null)
				return;

			NameBox.Text = Weapon.Name;
			TypeBox.Text = Weapon.Type;
			PriceBox.Value = Weapon.Price;
			WeightBox.Value = (decimal) Weapon.Weight;
			HandsBox.SelectedIndex = (int) Weapon.Hands;
			AttackValueBox.Value = Weapon.AttackValue;
			AttackModifierBox.Value = Weapon.AttackModifier;
			DamageValueBox.Value = Weapon.DamageValue;
			DamageModifierBox.Value = Weapon.DamageModifier;

			foreach (var c in Weapon.AllowedClasses)
			{
				if (ClassList.Items.Contains(c))
					ClassList.Items.Remove(c);

				AllowedList.Items.Add(c);
			}
		}

		private void FormWeaponDetailFormClosing(object sender, FormClosingEventArgs e)
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
			Weapon = new WeaponData
			{
				Name = NameBox.Text,
				Type = TypeBox.Text,
				Price = (int) PriceBox.Value,
				Weight = (float) WeightBox.Value,
				Hands = (Hands) HandsBox.SelectedIndex,
				AttackValue = (int) AttackValueBox.Value,
				AttackModifier = (int) AttackModifierBox.Value,
				DamageValue = (int) DamageValueBox.Value,
				DamageModifier = (int) DamageModifierBox.Value,
				AllowedClasses = allowed.ToArray()
			};

			CloseForm();
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			Weapon = null;
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
			FormClosing -= FormWeaponDetailFormClosing;
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
