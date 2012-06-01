namespace RpgEditor
{
	partial class FormContainerData
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
			this.LockGroup = new System.Windows.Forms.GroupBox();
			this.KeysNeededBox = new System.Windows.Forms.NumericUpDown();
			this.KeyTypeBox = new System.Windows.Forms.TextBox();
			this.KeyNameBox = new System.Windows.Forms.TextBox();
			this.LockDifficultyBox = new System.Windows.Forms.ComboBox();
			this.KeysNeededLabel = new System.Windows.Forms.Label();
			this.KeyTypeLabel = new System.Windows.Forms.Label();
			this.KeyNameLabel = new System.Windows.Forms.Label();
			this.LockDifficultyLabel = new System.Windows.Forms.Label();
			this.LockCheck = new System.Windows.Forms.CheckBox();
			this.TrapGroup = new System.Windows.Forms.GroupBox();
			this.TrapNameLabel = new System.Windows.Forms.Label();
			this.TrapNameBox = new System.Windows.Forms.TextBox();
			this.TrapCheck = new System.Windows.Forms.CheckBox();
			this.GoldGroup = new System.Windows.Forms.GroupBox();
			this.MaxGoldLabel = new System.Windows.Forms.Label();
			this.MinGoldLabel = new System.Windows.Forms.Label();
			this.MaxGoldBox = new System.Windows.Forms.NumericUpDown();
			this.MinGoldBox = new System.Windows.Forms.NumericUpDown();
			this.ItemGroup = new System.Windows.Forms.GroupBox();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.ItemList = new System.Windows.Forms.ListBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.LockGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.KeysNeededBox)).BeginInit();
			this.TrapGroup.SuspendLayout();
			this.GoldGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxGoldBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinGoldBox)).BeginInit();
			this.ItemGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(12, 15);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(86, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Container Name:";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(104, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(128, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
			// 
			// LockGroup
			// 
			this.LockGroup.Controls.Add(this.KeysNeededBox);
			this.LockGroup.Controls.Add(this.KeyTypeBox);
			this.LockGroup.Controls.Add(this.KeyNameBox);
			this.LockGroup.Controls.Add(this.LockDifficultyBox);
			this.LockGroup.Controls.Add(this.KeysNeededLabel);
			this.LockGroup.Controls.Add(this.KeyTypeLabel);
			this.LockGroup.Controls.Add(this.KeyNameLabel);
			this.LockGroup.Controls.Add(this.LockDifficultyLabel);
			this.LockGroup.Controls.Add(this.LockCheck);
			this.LockGroup.Location = new System.Drawing.Point(12, 38);
			this.LockGroup.Name = "LockGroup";
			this.LockGroup.Size = new System.Drawing.Size(220, 155);
			this.LockGroup.TabIndex = 2;
			this.LockGroup.TabStop = false;
			this.LockGroup.Text = "Lock Properties";
			// 
			// KeysNeededBox
			// 
			this.KeysNeededBox.Enabled = false;
			this.KeysNeededBox.Location = new System.Drawing.Point(85, 122);
			this.KeysNeededBox.Name = "KeysNeededBox";
			this.KeysNeededBox.Size = new System.Drawing.Size(120, 20);
			this.KeysNeededBox.TabIndex = 8;
			this.KeysNeededBox.ValueChanged += new System.EventHandler(this.KeysNeededBoxValueChanged);
			this.KeysNeededBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// KeyTypeBox
			// 
			this.KeyTypeBox.Enabled = false;
			this.KeyTypeBox.Location = new System.Drawing.Point(85, 96);
			this.KeyTypeBox.Name = "KeyTypeBox";
			this.KeyTypeBox.Size = new System.Drawing.Size(120, 20);
			this.KeyTypeBox.TabIndex = 6;
			// 
			// KeyNameBox
			// 
			this.KeyNameBox.Enabled = false;
			this.KeyNameBox.Location = new System.Drawing.Point(85, 70);
			this.KeyNameBox.Name = "KeyNameBox";
			this.KeyNameBox.Size = new System.Drawing.Size(120, 20);
			this.KeyNameBox.TabIndex = 4;
			this.KeyNameBox.TextChanged += new System.EventHandler(this.KeyNameBoxTextChanged);
			// 
			// LockDifficultyBox
			// 
			this.LockDifficultyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LockDifficultyBox.Enabled = false;
			this.LockDifficultyBox.FormattingEnabled = true;
			this.LockDifficultyBox.Location = new System.Drawing.Point(85, 43);
			this.LockDifficultyBox.Name = "LockDifficultyBox";
			this.LockDifficultyBox.Size = new System.Drawing.Size(120, 21);
			this.LockDifficultyBox.TabIndex = 2;
			// 
			// KeysNeededLabel
			// 
			this.KeysNeededLabel.AutoSize = true;
			this.KeysNeededLabel.Enabled = false;
			this.KeysNeededLabel.Location = new System.Drawing.Point(8, 124);
			this.KeysNeededLabel.Name = "KeysNeededLabel";
			this.KeysNeededLabel.Size = new System.Drawing.Size(74, 13);
			this.KeysNeededLabel.TabIndex = 7;
			this.KeysNeededLabel.Text = "Keys Needed:";
			// 
			// KeyTypeLabel
			// 
			this.KeyTypeLabel.AutoSize = true;
			this.KeyTypeLabel.Enabled = false;
			this.KeyTypeLabel.Location = new System.Drawing.Point(27, 99);
			this.KeyTypeLabel.Name = "KeyTypeLabel";
			this.KeyTypeLabel.Size = new System.Drawing.Size(55, 13);
			this.KeyTypeLabel.TabIndex = 5;
			this.KeyTypeLabel.Text = "Key Type:";
			// 
			// KeyNameLabel
			// 
			this.KeyNameLabel.AutoSize = true;
			this.KeyNameLabel.Enabled = false;
			this.KeyNameLabel.Location = new System.Drawing.Point(23, 73);
			this.KeyNameLabel.Name = "KeyNameLabel";
			this.KeyNameLabel.Size = new System.Drawing.Size(59, 13);
			this.KeyNameLabel.TabIndex = 3;
			this.KeyNameLabel.Text = "Key Name:";
			// 
			// LockDifficultyLabel
			// 
			this.LockDifficultyLabel.AutoSize = true;
			this.LockDifficultyLabel.Enabled = false;
			this.LockDifficultyLabel.Location = new System.Drawing.Point(32, 46);
			this.LockDifficultyLabel.Name = "LockDifficultyLabel";
			this.LockDifficultyLabel.Size = new System.Drawing.Size(50, 13);
			this.LockDifficultyLabel.TabIndex = 1;
			this.LockDifficultyLabel.Text = "Difficulty:";
			// 
			// LockCheck
			// 
			this.LockCheck.AutoSize = true;
			this.LockCheck.Location = new System.Drawing.Point(10, 20);
			this.LockCheck.Name = "LockCheck";
			this.LockCheck.Size = new System.Drawing.Size(62, 17);
			this.LockCheck.TabIndex = 0;
			this.LockCheck.Text = "Locked";
			this.LockCheck.UseVisualStyleBackColor = true;
			this.LockCheck.CheckedChanged += new System.EventHandler(this.LockCheckCheckedChanged);
			// 
			// TrapGroup
			// 
			this.TrapGroup.Controls.Add(this.TrapNameLabel);
			this.TrapGroup.Controls.Add(this.TrapNameBox);
			this.TrapGroup.Controls.Add(this.TrapCheck);
			this.TrapGroup.Location = new System.Drawing.Point(12, 199);
			this.TrapGroup.Name = "TrapGroup";
			this.TrapGroup.Size = new System.Drawing.Size(220, 75);
			this.TrapGroup.TabIndex = 3;
			this.TrapGroup.TabStop = false;
			this.TrapGroup.Text = "Trap Properties";
			// 
			// TrapNameLabel
			// 
			this.TrapNameLabel.AutoSize = true;
			this.TrapNameLabel.Enabled = false;
			this.TrapNameLabel.Location = new System.Drawing.Point(19, 46);
			this.TrapNameLabel.Name = "TrapNameLabel";
			this.TrapNameLabel.Size = new System.Drawing.Size(63, 13);
			this.TrapNameLabel.TabIndex = 1;
			this.TrapNameLabel.Text = "Trap Name:";
			// 
			// TrapNameBox
			// 
			this.TrapNameBox.Enabled = false;
			this.TrapNameBox.Location = new System.Drawing.Point(85, 43);
			this.TrapNameBox.Name = "TrapNameBox";
			this.TrapNameBox.Size = new System.Drawing.Size(120, 20);
			this.TrapNameBox.TabIndex = 2;
			this.TrapNameBox.TextChanged += new System.EventHandler(this.TrapNameBoxTextChanged);
			// 
			// TrapCheck
			// 
			this.TrapCheck.AutoSize = true;
			this.TrapCheck.Location = new System.Drawing.Point(10, 20);
			this.TrapCheck.Name = "TrapCheck";
			this.TrapCheck.Size = new System.Drawing.Size(66, 17);
			this.TrapCheck.TabIndex = 0;
			this.TrapCheck.Text = "Trapped";
			this.TrapCheck.UseVisualStyleBackColor = true;
			this.TrapCheck.CheckedChanged += new System.EventHandler(this.TrapCheckCheckedChanged);
			// 
			// GoldGroup
			// 
			this.GoldGroup.Controls.Add(this.MaxGoldLabel);
			this.GoldGroup.Controls.Add(this.MinGoldLabel);
			this.GoldGroup.Controls.Add(this.MaxGoldBox);
			this.GoldGroup.Controls.Add(this.MinGoldBox);
			this.GoldGroup.Location = new System.Drawing.Point(12, 280);
			this.GoldGroup.Name = "GoldGroup";
			this.GoldGroup.Size = new System.Drawing.Size(220, 80);
			this.GoldGroup.TabIndex = 4;
			this.GoldGroup.TabStop = false;
			this.GoldGroup.Text = "Gold Properties";
			// 
			// MaxGoldLabel
			// 
			this.MaxGoldLabel.AutoSize = true;
			this.MaxGoldLabel.Location = new System.Drawing.Point(3, 47);
			this.MaxGoldLabel.Name = "MaxGoldLabel";
			this.MaxGoldLabel.Size = new System.Drawing.Size(79, 13);
			this.MaxGoldLabel.TabIndex = 2;
			this.MaxGoldLabel.Text = "Maximum Gold:";
			// 
			// MinGoldLabel
			// 
			this.MinGoldLabel.AutoSize = true;
			this.MinGoldLabel.Location = new System.Drawing.Point(6, 21);
			this.MinGoldLabel.Name = "MinGoldLabel";
			this.MinGoldLabel.Size = new System.Drawing.Size(76, 13);
			this.MinGoldLabel.TabIndex = 0;
			this.MinGoldLabel.Text = "Minimum Gold:";
			// 
			// MaxGoldBox
			// 
			this.MaxGoldBox.Location = new System.Drawing.Point(85, 45);
			this.MaxGoldBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.MaxGoldBox.Name = "MaxGoldBox";
			this.MaxGoldBox.Size = new System.Drawing.Size(120, 20);
			this.MaxGoldBox.TabIndex = 3;
			this.MaxGoldBox.ValueChanged += new System.EventHandler(this.MaxGoldBoxValueChanged);
			this.MaxGoldBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// MinGoldBox
			// 
			this.MinGoldBox.Location = new System.Drawing.Point(85, 19);
			this.MinGoldBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.MinGoldBox.Name = "MinGoldBox";
			this.MinGoldBox.Size = new System.Drawing.Size(120, 20);
			this.MinGoldBox.TabIndex = 1;
			this.MinGoldBox.ValueChanged += new System.EventHandler(this.MinGoldBoxValueChanged);
			this.MinGoldBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// ItemGroup
			// 
			this.ItemGroup.Controls.Add(this.RemoveButton);
			this.ItemGroup.Controls.Add(this.AddButton);
			this.ItemGroup.Controls.Add(this.ItemList);
			this.ItemGroup.Location = new System.Drawing.Point(238, 15);
			this.ItemGroup.Name = "ItemGroup";
			this.ItemGroup.Size = new System.Drawing.Size(400, 345);
			this.ItemGroup.TabIndex = 5;
			this.ItemGroup.TabStop = false;
			this.ItemGroup.Text = "Item Properties";
			// 
			// RemoveButton
			// 
			this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveButton.Location = new System.Drawing.Point(219, 316);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveButton.TabIndex = 2;
			this.RemoveButton.Text = "&Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
			// 
			// AddButton
			// 
			this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddButton.Location = new System.Drawing.Point(106, 316);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "&Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// ItemList
			// 
			this.ItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ItemList.FormattingEnabled = true;
			this.ItemList.Location = new System.Drawing.Point(6, 19);
			this.ItemList.Name = "ItemList";
			this.ItemList.Size = new System.Drawing.Size(388, 290);
			this.ItemList.TabIndex = 0;
			// 
			// OkButton
			// 
			this.OkButton.Enabled = false;
			this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OkButton.Location = new System.Drawing.Point(212, 366);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(80, 30);
			this.OkButton.TabIndex = 6;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormCancelButton.Location = new System.Drawing.Point(357, 366);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(80, 30);
			this.FormCancelButton.TabIndex = 7;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButtonClick);
			// 
			// FormContainerData
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(649, 407);
			this.ControlBox = false;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.ItemGroup);
			this.Controls.Add(this.GoldGroup);
			this.Controls.Add(this.TrapGroup);
			this.Controls.Add(this.LockGroup);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormContainerData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Container";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormContainerDataFormClosing);
			this.Load += new System.EventHandler(this.FormContainerDataLoad);
			this.LockGroup.ResumeLayout(false);
			this.LockGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.KeysNeededBox)).EndInit();
			this.TrapGroup.ResumeLayout(false);
			this.TrapGroup.PerformLayout();
			this.GoldGroup.ResumeLayout(false);
			this.GoldGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxGoldBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinGoldBox)).EndInit();
			this.ItemGroup.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.GroupBox LockGroup;
		private System.Windows.Forms.NumericUpDown KeysNeededBox;
		private System.Windows.Forms.TextBox KeyTypeBox;
		private System.Windows.Forms.TextBox KeyNameBox;
		private System.Windows.Forms.ComboBox LockDifficultyBox;
		private System.Windows.Forms.Label KeysNeededLabel;
		private System.Windows.Forms.Label KeyTypeLabel;
		private System.Windows.Forms.Label KeyNameLabel;
		private System.Windows.Forms.Label LockDifficultyLabel;
		private System.Windows.Forms.CheckBox LockCheck;
		private System.Windows.Forms.GroupBox TrapGroup;
		private System.Windows.Forms.Label TrapNameLabel;
		private System.Windows.Forms.TextBox TrapNameBox;
		private System.Windows.Forms.CheckBox TrapCheck;
		private System.Windows.Forms.GroupBox GoldGroup;
		private System.Windows.Forms.Label MaxGoldLabel;
		private System.Windows.Forms.Label MinGoldLabel;
		private System.Windows.Forms.NumericUpDown MaxGoldBox;
		private System.Windows.Forms.NumericUpDown MinGoldBox;
		private System.Windows.Forms.GroupBox ItemGroup;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.ListBox ItemList;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button FormCancelButton;
	}
}