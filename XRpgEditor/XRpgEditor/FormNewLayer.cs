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
	public partial class FormNewLayer : Form
	{
		#region Fields

		private int _layerWidth;
		private int _layerHeight;

		#endregion

		#region Properties

		public bool OkPressed { get; private set; }
		public MapLayerData LayerData { get; private set; }

		#endregion

		#region Constructors

		public FormNewLayer(int width, int height)
		{
			InitializeComponent();

			_layerWidth = width;
			_layerHeight = height;

			SetDefaultValues();
		}

		#endregion

		#region Event Handlers

		private void DataValueChanged(object sender, EventArgs e)
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

		private void FillCheckCheckedChanged(object sender, EventArgs e)
		{
			FillGroup.Enabled = FillCheck.Checked;
			if (FillCheck.Checked)
			{
				FillTileIndexBox.Value = 0;
				FillTilesetIndexBox.Value = 0;
			}
			else
			{
				FillTileIndexBox.Value = -1;
				FillTilesetIndexBox.Value = -1;
			}
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show("Name cannot be empty, fill data must be valid if enabled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (FillCheck.Checked)
			{
				LayerData = new MapLayerData(
					NameBox.Text,
					_layerWidth,
					_layerHeight,
					(int) FillTileIndexBox.Value,
					(int) FillTilesetIndexBox.Value);
			}
			else
			{
				LayerData = new MapLayerData(
					NameBox.Text,
					_layerWidth,
					_layerHeight);
			}

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
			return !string.IsNullOrEmpty(NameBox.Text) && IsFillValid();
		}

		private bool IsFillValid()
		{
			if (!FillCheck.Checked)
				return true;

			return FillTileIndexBox.Value >= 0 && FillTilesetIndexBox.Value >= 0;
		}

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();
		}

		private void SetDefaultValues()
		{
			NameBox.Text = "New Layer";
		}

		#endregion
	}
}
