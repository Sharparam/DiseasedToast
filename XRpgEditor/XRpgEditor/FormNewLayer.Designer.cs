namespace XRpgEditor
{
	partial class FormNewLayer
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
			this.NameLabel = new System.Windows.Forms.Label();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.FillCheck = new System.Windows.Forms.CheckBox();
			this.FillGroup = new System.Windows.Forms.GroupBox();
			this.FillTilesetIndexBox = new System.Windows.Forms.NumericUpDown();
			this.FillTileIndexBox = new System.Windows.Forms.NumericUpDown();
			this.FillTilesetIndexLabel = new System.Windows.Forms.Label();
			this.FillTileIndexLabel = new System.Windows.Forms.Label();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.FillGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FillTilesetIndexBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FillTileIndexBox)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(12, 15);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(67, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Layer Name:";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(85, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(100, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.DataValueChanged);
			this.NameBox.Enter += new System.EventHandler(this.TextBoxEnter);
			// 
			// FillCheck
			// 
			this.FillCheck.AutoSize = true;
			this.FillCheck.Location = new System.Drawing.Point(13, 40);
			this.FillCheck.Name = "FillCheck";
			this.FillCheck.Size = new System.Drawing.Size(73, 17);
			this.FillCheck.TabIndex = 2;
			this.FillCheck.Text = "Fill Layer?";
			this.FillCheck.UseVisualStyleBackColor = true;
			this.FillCheck.CheckedChanged += new System.EventHandler(this.FillCheckCheckedChanged);
			// 
			// FillGroup
			// 
			this.FillGroup.Controls.Add(this.FillTilesetIndexBox);
			this.FillGroup.Controls.Add(this.FillTileIndexBox);
			this.FillGroup.Controls.Add(this.FillTilesetIndexLabel);
			this.FillGroup.Controls.Add(this.FillTileIndexLabel);
			this.FillGroup.Enabled = false;
			this.FillGroup.Location = new System.Drawing.Point(12, 63);
			this.FillGroup.Name = "FillGroup";
			this.FillGroup.Size = new System.Drawing.Size(173, 80);
			this.FillGroup.TabIndex = 3;
			this.FillGroup.TabStop = false;
			this.FillGroup.Text = "Fill With";
			// 
			// FillTilesetIndexBox
			// 
			this.FillTilesetIndexBox.Location = new System.Drawing.Point(79, 45);
			this.FillTilesetIndexBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.FillTilesetIndexBox.Name = "FillTilesetIndexBox";
			this.FillTilesetIndexBox.Size = new System.Drawing.Size(80, 20);
			this.FillTilesetIndexBox.TabIndex = 3;
			this.FillTilesetIndexBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.FillTilesetIndexBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// FillTileIndexBox
			// 
			this.FillTileIndexBox.Location = new System.Drawing.Point(79, 19);
			this.FillTileIndexBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.FillTileIndexBox.Name = "FillTileIndexBox";
			this.FillTileIndexBox.Size = new System.Drawing.Size(80, 20);
			this.FillTileIndexBox.TabIndex = 1;
			this.FillTileIndexBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.FillTileIndexBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// FillTilesetIndexLabel
			// 
			this.FillTilesetIndexLabel.AutoSize = true;
			this.FillTilesetIndexLabel.Location = new System.Drawing.Point(6, 47);
			this.FillTilesetIndexLabel.Name = "FillTilesetIndexLabel";
			this.FillTilesetIndexLabel.Size = new System.Drawing.Size(67, 13);
			this.FillTilesetIndexLabel.TabIndex = 2;
			this.FillTilesetIndexLabel.Text = "Tileset Index";
			// 
			// FillTileIndexLabel
			// 
			this.FillTileIndexLabel.AutoSize = true;
			this.FillTileIndexLabel.Location = new System.Drawing.Point(17, 21);
			this.FillTileIndexLabel.Name = "FillTileIndexLabel";
			this.FillTileIndexLabel.Size = new System.Drawing.Size(56, 13);
			this.FillTileIndexLabel.TabIndex = 0;
			this.FillTileIndexLabel.Text = "Tile Index:";
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(15, 149);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 4;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(110, 149);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 5;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButtonClick);
			// 
			// FormNewLayer
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(200, 187);
			this.ControlBox = false;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.FillGroup);
			this.Controls.Add(this.FillCheck);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewLayer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Layer";
			this.FillGroup.ResumeLayout(false);
			this.FillGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FillTilesetIndexBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FillTileIndexBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.CheckBox FillCheck;
		private System.Windows.Forms.GroupBox FillGroup;
		private System.Windows.Forms.NumericUpDown FillTilesetIndexBox;
		private System.Windows.Forms.NumericUpDown FillTileIndexBox;
		private System.Windows.Forms.Label FillTilesetIndexLabel;
		private System.Windows.Forms.Label FillTileIndexLabel;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button FormCancelButton;
	}
}