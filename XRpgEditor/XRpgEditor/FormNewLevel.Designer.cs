namespace XRpgEditor
{
	partial class FormNewLevel
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
			this.LevelNameBox = new System.Windows.Forms.TextBox();
			this.LevelNameLabel = new System.Windows.Forms.Label();
			this.MapNameLabel = new System.Windows.Forms.Label();
			this.MapWidthLabel = new System.Windows.Forms.Label();
			this.MapHeightLabel = new System.Windows.Forms.Label();
			this.MapNameBox = new System.Windows.Forms.TextBox();
			this.MapWidthBox = new System.Windows.Forms.NumericUpDown();
			this.MapHeightBox = new System.Windows.Forms.NumericUpDown();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.MapWidthBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MapHeightBox)).BeginInit();
			this.SuspendLayout();
			// 
			// LevelNameBox
			// 
			this.LevelNameBox.Location = new System.Drawing.Point(85, 12);
			this.LevelNameBox.Name = "LevelNameBox";
			this.LevelNameBox.Size = new System.Drawing.Size(100, 20);
			this.LevelNameBox.TabIndex = 1;
			this.LevelNameBox.TextChanged += new System.EventHandler(this.LevelNameBoxTextChanged);
			this.LevelNameBox.Enter += new System.EventHandler(this.TextBoxEnter);
			// 
			// LevelNameLabel
			// 
			this.LevelNameLabel.AutoSize = true;
			this.LevelNameLabel.Location = new System.Drawing.Point(12, 15);
			this.LevelNameLabel.Name = "LevelNameLabel";
			this.LevelNameLabel.Size = new System.Drawing.Size(67, 13);
			this.LevelNameLabel.TabIndex = 0;
			this.LevelNameLabel.Text = "Level Name:";
			// 
			// MapNameLabel
			// 
			this.MapNameLabel.AutoSize = true;
			this.MapNameLabel.Location = new System.Drawing.Point(17, 41);
			this.MapNameLabel.Name = "MapNameLabel";
			this.MapNameLabel.Size = new System.Drawing.Size(62, 13);
			this.MapNameLabel.TabIndex = 2;
			this.MapNameLabel.Text = "Map Name:";
			// 
			// MapWidthLabel
			// 
			this.MapWidthLabel.AutoSize = true;
			this.MapWidthLabel.Location = new System.Drawing.Point(17, 67);
			this.MapWidthLabel.Name = "MapWidthLabel";
			this.MapWidthLabel.Size = new System.Drawing.Size(62, 13);
			this.MapWidthLabel.TabIndex = 4;
			this.MapWidthLabel.Text = "Map Width:";
			// 
			// MapHeightLabel
			// 
			this.MapHeightLabel.AutoSize = true;
			this.MapHeightLabel.Location = new System.Drawing.Point(14, 93);
			this.MapHeightLabel.Name = "MapHeightLabel";
			this.MapHeightLabel.Size = new System.Drawing.Size(65, 13);
			this.MapHeightLabel.TabIndex = 6;
			this.MapHeightLabel.Text = "Map Height:";
			// 
			// MapNameBox
			// 
			this.MapNameBox.Location = new System.Drawing.Point(85, 38);
			this.MapNameBox.Name = "MapNameBox";
			this.MapNameBox.Size = new System.Drawing.Size(100, 20);
			this.MapNameBox.TabIndex = 3;
			this.MapNameBox.TextChanged += new System.EventHandler(this.MapNameBoxTextChanged);
			this.MapNameBox.Enter += new System.EventHandler(this.TextBoxEnter);
			// 
			// MapWidthBox
			// 
			this.MapWidthBox.Location = new System.Drawing.Point(85, 65);
			this.MapWidthBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.MapWidthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MapWidthBox.Name = "MapWidthBox";
			this.MapWidthBox.Size = new System.Drawing.Size(100, 20);
			this.MapWidthBox.TabIndex = 5;
			this.MapWidthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MapWidthBox.ValueChanged += new System.EventHandler(this.MapWidthBoxValueChanged);
			this.MapWidthBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			this.MapWidthBox.Leave += new System.EventHandler(this.NumericUpDownLeave);
			// 
			// MapHeightBox
			// 
			this.MapHeightBox.Location = new System.Drawing.Point(85, 91);
			this.MapHeightBox.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
			this.MapHeightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MapHeightBox.Name = "MapHeightBox";
			this.MapHeightBox.Size = new System.Drawing.Size(100, 20);
			this.MapHeightBox.TabIndex = 7;
			this.MapHeightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MapHeightBox.ValueChanged += new System.EventHandler(this.MapHeightBoxValueChanged);
			this.MapHeightBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			this.MapHeightBox.Leave += new System.EventHandler(this.NumericUpDownLeave);
			// 
			// OkButton
			// 
			this.OkButton.Enabled = false;
			this.OkButton.Location = new System.Drawing.Point(12, 117);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 8;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Location = new System.Drawing.Point(114, 117);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(75, 23);
			this.FormCancelButton.TabIndex = 9;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButtonClick);
			// 
			// FormNewLevel
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(201, 150);
			this.ControlBox = false;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.MapHeightBox);
			this.Controls.Add(this.MapWidthBox);
			this.Controls.Add(this.MapHeightLabel);
			this.Controls.Add(this.MapWidthLabel);
			this.Controls.Add(this.MapNameLabel);
			this.Controls.Add(this.LevelNameLabel);
			this.Controls.Add(this.MapNameBox);
			this.Controls.Add(this.LevelNameBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewLevel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Level";
			((System.ComponentModel.ISupportInitialize)(this.MapWidthBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MapHeightBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox LevelNameBox;
		private System.Windows.Forms.Label LevelNameLabel;
		private System.Windows.Forms.Label MapNameLabel;
		private System.Windows.Forms.Label MapWidthLabel;
		private System.Windows.Forms.Label MapHeightLabel;
		private System.Windows.Forms.TextBox MapNameBox;
		private System.Windows.Forms.NumericUpDown MapWidthBox;
		private System.Windows.Forms.NumericUpDown MapHeightBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button FormCancelButton;
	}
}