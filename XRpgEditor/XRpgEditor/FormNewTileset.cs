using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using F16Gaming.Game.RPGLibrary.World;

namespace XRpgEditor
{
	public partial class FormNewTileset : Form
	{
		#region Fields

		private const int MaxImageSize = 16384;
		private bool _imageChecked;
		private int _imageWidth;
		private int _imageHeight;
		private bool _imageLastValid;
		private bool _tileWarningShown;

		#endregion

		#region Properties

		public bool OkPressed { get; private set; }
		public TilesetData TilesetData { get; private set; }

		#endregion

		#region Constructors

		public FormNewTileset()
		{
			InitializeComponent();

			SetDefaultValues();
		}

		#endregion

		#region Event Handlers

		private void NumericUpDownLeave(object sender, EventArgs e)
		{
			((NumericUpDown) sender).Value = Math.Floor(((NumericUpDown) sender).Value);
		}

		private void DataBoxTextChanged(object sender, EventArgs e)
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

		private void BrowseButtonClick(object sender, EventArgs e)
		{
			LoadImage();
			ValidateForm();
		}

		private void OkButtonClick(object sender, EventArgs e)
		{
			if (!IsValid())
			{
				MessageBox.Show("Name cannot be empty, image must be specified, tile width and height must be valid.\n\nAdditionally, image size (width and height) cannot be larger than " + MaxImageSize + " pixels.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			var image = Image.FromFile(ImageBox.Text);

			TilesetData = new TilesetData
			{
				Name = NameBox.Text,
				Image = ImageBox.Text,
				TileWidth = (int) TileWidthBox.Value,
				TileHeight = (int) TileHeightBox.Value,
				TilesWide = (int) (image.Width / TileWidthBox.Value),
				TilesHigh = (int) (image.Height / TileHeightBox.Value)
			};

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
			return !string.IsNullOrEmpty(NameBox.Text) && !string.IsNullOrEmpty(ImageBox.Text) && IsValidImage() && IsValidImageSize() && IsValidTileSettings();
		}

		private bool IsValidImage()
		{
			return File.Exists(ImageBox.Text) && Path.GetExtension(ImageBox.Text) == ".png";
		}

		private bool IsValidImageSize()
		{
			if (_imageChecked)
				return _imageLastValid;

			using (var image = new Bitmap(ImageBox.Text))
			{
				_imageWidth = image.Width;
				_imageHeight = image.Height;
			}
			bool imgSize = _imageWidth <= MaxImageSize && _imageHeight <= MaxImageSize;
			_imageLastValid = imgSize;
			_imageChecked = true;
			return _imageLastValid;
		}

		private bool IsValidTileSettings()
		{
			return _imageWidth % (int) TileWidthBox.Value == 0 && _imageHeight % (int) TileHeightBox.Value == 0;
		}

		private void ValidateForm()
		{
			OkButton.Enabled = IsValid();

			NumTilesWideValue.Text = (_imageWidth / TileWidthBox.Value).ToString();
			NumTilesHighValue.Text = (_imageHeight / TileHeightBox.Value).ToString();
		}

		private void LoadImage()
		{
			if (ImageBrowseDialog.ShowDialog() == DialogResult.OK)
				ImageBox.Text = ImageBrowseDialog.FileName;

			_imageChecked = false;
		}

		private void SetDefaultValues()
		{
			NameBox.Text = "New Tileset";
			TileWidthBox.Value = 32;
			TileHeightBox.Value = 32;
		}

		#endregion
	}
}
