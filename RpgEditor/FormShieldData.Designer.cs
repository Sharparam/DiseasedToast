namespace RpgEditor
{
	partial class FormShieldData
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
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.AllowedClassesLabel = new System.Windows.Forms.Label();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.AllowedList = new System.Windows.Forms.ListBox();
			this.ClassList = new System.Windows.Forms.ListBox();
			this.CharacterClassesLabel = new System.Windows.Forms.Label();
			this.AttackModifierLabel = new System.Windows.Forms.Label();
			this.AttackValueLabel = new System.Windows.Forms.Label();
			this.WeightLabel = new System.Windows.Forms.Label();
			this.PriceLabel = new System.Windows.Forms.Label();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.DefenseModifierBox = new System.Windows.Forms.NumericUpDown();
			this.DefenseValueBox = new System.Windows.Forms.NumericUpDown();
			this.WeightBox = new System.Windows.Forms.NumericUpDown();
			this.PriceBox = new System.Windows.Forms.NumericUpDown();
			this.TypeBox = new System.Windows.Forms.TextBox();
			this.NameBox = new System.Windows.Forms.TextBox();
			this.NameLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DefenseModifierBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DefenseValueBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WeightBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.PriceBox)).BeginInit();
			this.SuspendLayout();
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormCancelButton.Location = new System.Drawing.Point(434, 212);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(90, 30);
			this.FormCancelButton.TabIndex = 19;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// OkButton
			// 
			this.OkButton.Enabled = false;
			this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OkButton.Location = new System.Drawing.Point(305, 212);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(90, 30);
			this.OkButton.TabIndex = 18;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// AllowedClassesLabel
			// 
			this.AllowedClassesLabel.AutoSize = true;
			this.AllowedClassesLabel.Location = new System.Drawing.Point(455, 13);
			this.AllowedClassesLabel.Name = "AllowedClassesLabel";
			this.AllowedClassesLabel.Size = new System.Drawing.Size(86, 13);
			this.AllowedClassesLabel.TabIndex = 16;
			this.AllowedClassesLabel.Text = "Allowed Classes:";
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(377, 117);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveButton.TabIndex = 15;
			this.RemoveButton.Text = "<<";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(377, 80);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 14;
			this.AddButton.Text = ">>";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// AllowedList
			// 
			this.AllowedList.FormattingEnabled = true;
			this.AllowedList.Location = new System.Drawing.Point(458, 29);
			this.AllowedList.Name = "AllowedList";
			this.AllowedList.Size = new System.Drawing.Size(120, 173);
			this.AllowedList.TabIndex = 17;
			this.AllowedList.DoubleClick += new System.EventHandler(this.AllowedListDoubleClick);
			// 
			// ClassList
			// 
			this.ClassList.FormattingEnabled = true;
			this.ClassList.Location = new System.Drawing.Point(251, 29);
			this.ClassList.Name = "ClassList";
			this.ClassList.Size = new System.Drawing.Size(120, 173);
			this.ClassList.TabIndex = 13;
			this.ClassList.DoubleClick += new System.EventHandler(this.ClassListDoubleClick);
			// 
			// CharacterClassesLabel
			// 
			this.CharacterClassesLabel.AutoSize = true;
			this.CharacterClassesLabel.Location = new System.Drawing.Point(248, 13);
			this.CharacterClassesLabel.Name = "CharacterClassesLabel";
			this.CharacterClassesLabel.Size = new System.Drawing.Size(95, 13);
			this.CharacterClassesLabel.TabIndex = 12;
			this.CharacterClassesLabel.Text = "Character Classes:";
			// 
			// AttackModifierLabel
			// 
			this.AttackModifierLabel.AutoSize = true;
			this.AttackModifierLabel.Location = new System.Drawing.Point(17, 142);
			this.AttackModifierLabel.Name = "AttackModifierLabel";
			this.AttackModifierLabel.Size = new System.Drawing.Size(90, 13);
			this.AttackModifierLabel.TabIndex = 10;
			this.AttackModifierLabel.Text = "Defense Modifier:";
			// 
			// AttackValueLabel
			// 
			this.AttackValueLabel.AutoSize = true;
			this.AttackValueLabel.Location = new System.Drawing.Point(27, 116);
			this.AttackValueLabel.Name = "AttackValueLabel";
			this.AttackValueLabel.Size = new System.Drawing.Size(80, 13);
			this.AttackValueLabel.TabIndex = 8;
			this.AttackValueLabel.Text = "Defense Value:";
			// 
			// WeightLabel
			// 
			this.WeightLabel.AutoSize = true;
			this.WeightLabel.Location = new System.Drawing.Point(63, 90);
			this.WeightLabel.Name = "WeightLabel";
			this.WeightLabel.Size = new System.Drawing.Size(44, 13);
			this.WeightLabel.TabIndex = 6;
			this.WeightLabel.Text = "Weight:";
			// 
			// PriceLabel
			// 
			this.PriceLabel.AutoSize = true;
			this.PriceLabel.Location = new System.Drawing.Point(73, 64);
			this.PriceLabel.Name = "PriceLabel";
			this.PriceLabel.Size = new System.Drawing.Size(34, 13);
			this.PriceLabel.TabIndex = 4;
			this.PriceLabel.Text = "Price:";
			// 
			// TypeLabel
			// 
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Location = new System.Drawing.Point(73, 39);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(34, 13);
			this.TypeLabel.TabIndex = 2;
			this.TypeLabel.Text = "Type:";
			// 
			// DefenseModifierBox
			// 
			this.DefenseModifierBox.Location = new System.Drawing.Point(113, 140);
			this.DefenseModifierBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DefenseModifierBox.Name = "DefenseModifierBox";
			this.DefenseModifierBox.Size = new System.Drawing.Size(120, 20);
			this.DefenseModifierBox.TabIndex = 11;
			this.DefenseModifierBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// DefenseValueBox
			// 
			this.DefenseValueBox.Location = new System.Drawing.Point(113, 114);
			this.DefenseValueBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DefenseValueBox.Name = "DefenseValueBox";
			this.DefenseValueBox.Size = new System.Drawing.Size(120, 20);
			this.DefenseValueBox.TabIndex = 9;
			this.DefenseValueBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// WeightBox
			// 
			this.WeightBox.DecimalPlaces = 2;
			this.WeightBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.WeightBox.Location = new System.Drawing.Point(113, 88);
			this.WeightBox.Name = "WeightBox";
			this.WeightBox.Size = new System.Drawing.Size(120, 20);
			this.WeightBox.TabIndex = 7;
			this.WeightBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// PriceBox
			// 
			this.PriceBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.PriceBox.Location = new System.Drawing.Point(113, 62);
			this.PriceBox.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.PriceBox.Name = "PriceBox";
			this.PriceBox.Size = new System.Drawing.Size(120, 20);
			this.PriceBox.TabIndex = 5;
			this.PriceBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// TypeBox
			// 
			this.TypeBox.Location = new System.Drawing.Point(113, 36);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(120, 20);
			this.TypeBox.TabIndex = 3;
			this.TypeBox.TextChanged += new System.EventHandler(this.TypeBoxTextChanged);
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(113, 10);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(120, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(69, 13);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(38, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name:";
			// 
			// FormShieldDetail
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(594, 252);
			this.ControlBox = false;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.AllowedClassesLabel);
			this.Controls.Add(this.RemoveButton);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.AllowedList);
			this.Controls.Add(this.ClassList);
			this.Controls.Add(this.CharacterClassesLabel);
			this.Controls.Add(this.AttackModifierLabel);
			this.Controls.Add(this.AttackValueLabel);
			this.Controls.Add(this.WeightLabel);
			this.Controls.Add(this.PriceLabel);
			this.Controls.Add(this.TypeLabel);
			this.Controls.Add(this.DefenseModifierBox);
			this.Controls.Add(this.DefenseValueBox);
			this.Controls.Add(this.WeightBox);
			this.Controls.Add(this.PriceBox);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormShieldDetail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormShieldDetail";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormShieldDetailFormClosing);
			this.Load += new System.EventHandler(this.FormShieldDetailLoad);
			((System.ComponentModel.ISupportInitialize)(this.DefenseModifierBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DefenseValueBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WeightBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.PriceBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button FormCancelButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label AllowedClassesLabel;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.ListBox AllowedList;
		private System.Windows.Forms.ListBox ClassList;
		private System.Windows.Forms.Label CharacterClassesLabel;
		private System.Windows.Forms.Label AttackModifierLabel;
		private System.Windows.Forms.Label AttackValueLabel;
		private System.Windows.Forms.Label WeightLabel;
		private System.Windows.Forms.Label PriceLabel;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.NumericUpDown DefenseModifierBox;
		private System.Windows.Forms.NumericUpDown DefenseValueBox;
		private System.Windows.Forms.NumericUpDown WeightBox;
		private System.Windows.Forms.NumericUpDown PriceBox;
		private System.Windows.Forms.TextBox TypeBox;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.Label NameLabel;
	}
}