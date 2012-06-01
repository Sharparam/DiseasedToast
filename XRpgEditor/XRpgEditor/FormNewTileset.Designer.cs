namespace XRpgEditor
{
	partial class FormNewTileset
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TilesetNameLabel = new System.Windows.Forms.Label();
			this.TilesetImageLabel = new System.Windows.Forms.Label();
			this.TileWidthLabel = new System.Windows.Forms.Label();
			this.TileHeightLabel = new System.Windows.Forms.Label();
			this.NumTilesWideLabel = new System.Windows.Forms.Label();
			this.NumTilesHighLabel = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.ImageBox = new System.Windows.Forms.TextBox();
			this.TileWidthBox = new System.Windows.Forms.NumericUpDown();
			this.TileHeightBox = new System.Windows.Forms.NumericUpDown();
			this.BrowseButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.ImageBrowseDialog = new System.Windows.Forms.OpenFileDialog();
			this.NumTilesWideValue = new System.Windows.Forms.Label();
			this.NumTilesHighValue = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.TileWidthBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TileHeightBox)).BeginInit();
			this.SuspendLayout();
			// 
			// TilesetNameLabel
			// 
			this.TilesetNameLabel.AutoSize = true;
			this.TilesetNameLabel.Location = new System.Drawing.Point(34, 15);
			this.TilesetNameLabel.Name = "TilesetNameLabel";
			this.TilesetNameLabel.Size = new System.Drawing.Size(72, 13);
			this.TilesetNameLabel.TabIndex = 0;
			this.TilesetNameLabel.Text = "Tileset Name:";
			// 
			// TilesetImageLabel
			// 
			this.TilesetImageLabel.AutoSize = true;
			this.TilesetImageLabel.Location = new System.Drawing.Point(33, 41);
			this.TilesetImageLabel.Name = "TilesetImageLabel";
			this.TilesetImageLabel.Size = new System.Drawing.Size(73, 13);
			this.TilesetImageLabel.TabIndex = 2;
			this.TilesetImageLabel.Text = "Tileset Image:";
			// 
			// TileWidthLabel
			// 
			this.TileWidthLabel.AutoSize = true;
			this.TileWidthLabel.Location = new System.Drawing.Point(48, 67);
			this.TileWidthLabel.Name = "TileWidthLabel";
			this.TileWidthLabel.Size = new System.Drawing.Size(58, 13);
			this.TileWidthLabel.TabIndex = 5;
			this.TileWidthLabel.Text = "Tile Width:";
			// 
			// TileHeightLabel
			// 
			this.TileHeightLabel.AutoSize = true;
			this.TileHeightLabel.Location = new System.Drawing.Point(45, 93);
			this.TileHeightLabel.Name = "TileHeightLabel";
			this.TileHeightLabel.Size = new System.Drawing.Size(61, 13);
			this.TileHeightLabel.TabIndex = 7;
			this.TileHeightLabel.Text = "Tile Height:";
			// 
			// NumTilesWideLabel
			// 
			this.NumTilesWideLabel.AutoSize = true;
			this.NumTilesWideLabel.Location = new System.Drawing.Point(6, 119);
			this.NumTilesWideLabel.Name = "NumTilesWideLabel";
			this.NumTilesWideLabel.Size = new System.Drawing.Size(100, 13);
			this.NumTilesWideLabel.TabIndex = 9;
			this.NumTilesWideLabel.Text = "Number Tiles Wide:";
			// 
			// NumTilesHighLabel
			// 
			this.NumTilesHighLabel.AutoSize = true;
			this.NumTilesHighLabel.Location = new System.Drawing.Point(9, 145);
			this.NumTilesHighLabel.Name = "NumTilesHighLabel";
			this.NumTilesHighLabel.Size = new System.Drawing.Size(97, 13);
			this.NumTilesHighLabel.TabIndex = 11;
			this.NumTilesHighLabel.Text = "Number Tiles High:";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(112, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(122, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.DataBoxTextChanged);
			this.NameBox.Enter += new System.EventHandler(this.TextBoxEnter);
			// 
			// ImageBox
			// 
			this.ImageBox.Location = new System.Drawing.Point(112, 38);
			this.ImageBox.Name = "ImageBox";
			this.ImageBox.ReadOnly = true;
			this.ImageBox.Size = new System.Drawing.Size(86, 20);
			this.ImageBox.TabIndex = 3;
			this.ImageBox.TextChanged += new System.EventHandler(this.DataBoxTextChanged);
			this.ImageBox.Enter += new System.EventHandler(this.TextBoxEnter);
			// 
			// TileWidthBox
			// 
			this.TileWidthBox.Location = new System.Drawing.Point(112, 65);
			this.TileWidthBox.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
			this.TileWidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.TileWidthBox.Name = "TileWidthBox";
			this.TileWidthBox.Size = new System.Drawing.Size(122, 20);
			this.TileWidthBox.TabIndex = 6;
			this.TileWidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.TileWidthBox.ValueChanged += new System.EventHandler(this.DataBoxTextChanged);
			this.TileWidthBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// TileHeightBox
			// 
			this.TileHeightBox.Location = new System.Drawing.Point(112, 91);
			this.TileHeightBox.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
			this.TileHeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.TileHeightBox.Name = "TileHeightBox";
			this.TileHeightBox.Size = new System.Drawing.Size(122, 20);
			this.TileHeightBox.TabIndex = 8;
			this.TileHeightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.TileHeightBox.ValueChanged += new System.EventHandler(this.DataBoxTextChanged);
			this.TileHeightBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			this.TileHeightBox.Leave += new System.EventHandler(this.NumericUpDownLeave);
			// 
			// BrowseButton
			// 
			this.BrowseButton.Location = new System.Drawing.Point(204, 36);
			this.BrowseButton.Name = "BrowseButton";
			this.BrowseButton.Size = new System.Drawing.Size(30, 23);
			this.BrowseButton.TabIndex = 4;
			this.BrowseButton.Text = "...";
			this.BrowseButton.UseVisualStyleBackColor = true;
			this.BrowseButton.Click += new System.EventHandler(this.BrowseButtonClick);
			// 
			// OkButton
			// 
			this.OkButton.Enabled = false;
			this.OkButton.Location = new System.Drawing.Point(30, 169);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 13;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(143, 169);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 14;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButtonClick);
			// 
			// ImageBrowseDialog
			// 
			this.ImageBrowseDialog.DefaultExt = "png";
			this.ImageBrowseDialog.FileName = "tileset.png";
			this.ImageBrowseDialog.Filter = "Image files|*.png;*.bmp;*.gif;*.jpg;*.tga";
			this.ImageBrowseDialog.Title = "Select tileset image...";
			// 
			// NumTilesWideValue
			// 
			this.NumTilesWideValue.AutoSize = true;
			this.NumTilesWideValue.Location = new System.Drawing.Point(112, 119);
			this.NumTilesWideValue.Name = "NumTilesWideValue";
			this.NumTilesWideValue.Size = new System.Drawing.Size(13, 13);
			this.NumTilesWideValue.TabIndex = 15;
			this.NumTilesWideValue.Text = "0";
			// 
			// NumTilesHighValue
			// 
			this.NumTilesHighValue.AutoSize = true;
			this.NumTilesHighValue.Location = new System.Drawing.Point(112, 145);
			this.NumTilesHighValue.Name = "NumTilesHighValue";
			this.NumTilesHighValue.Size = new System.Drawing.Size(13, 13);
			this.NumTilesHighValue.TabIndex = 16;
			this.NumTilesHighValue.Text = "0";
			// 
			// FormNewTileset
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(248, 204);
			this.ControlBox = false;
			this.Controls.Add(this.NumTilesHighValue);
			this.Controls.Add(this.NumTilesWideValue);
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.BrowseButton);
			this.Controls.Add(this.TileHeightBox);
			this.Controls.Add(this.TileWidthBox);
			this.Controls.Add(this.ImageBox);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NumTilesHighLabel);
			this.Controls.Add(this.NumTilesWideLabel);
			this.Controls.Add(this.TileHeightLabel);
			this.Controls.Add(this.TileWidthLabel);
			this.Controls.Add(this.TilesetImageLabel);
			this.Controls.Add(this.TilesetNameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewTileset";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Tileset";
			((System.ComponentModel.ISupportInitialize)(this.TileWidthBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TileHeightBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label TilesetNameLabel;
		private System.Windows.Forms.Label TilesetImageLabel;
		private System.Windows.Forms.Label TileWidthLabel;
		private System.Windows.Forms.Label TileHeightLabel;
		private System.Windows.Forms.Label NumTilesWideLabel;
		private System.Windows.Forms.Label NumTilesHighLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TextBox ImageBox;
		private System.Windows.Forms.NumericUpDown TileWidthBox;
		private System.Windows.Forms.NumericUpDown TileHeightBox;
		private System.Windows.Forms.Button BrowseButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button FormCancelButton;
		private System.Windows.Forms.OpenFileDialog ImageBrowseDialog;
		private System.Windows.Forms.Label NumTilesWideValue;
		private System.Windows.Forms.Label NumTilesHighValue;
	}
}