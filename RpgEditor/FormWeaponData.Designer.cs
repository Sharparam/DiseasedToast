namespace RpgEditor
{
	partial class FormWeaponData
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
			this.TypeBox = new System.Windows.Forms.TextBox();
			this.PriceBox = new System.Windows.Forms.NumericUpDown();
			this.WeightBox = new System.Windows.Forms.NumericUpDown();
			this.HandsBox = new System.Windows.Forms.ComboBox();
			this.AttackValueBox = new System.Windows.Forms.NumericUpDown();
			this.AttackModifierBox = new System.Windows.Forms.NumericUpDown();
			this.DamageValueBox = new System.Windows.Forms.NumericUpDown();
			this.DamageModifierBox = new System.Windows.Forms.NumericUpDown();
			this.TypeLabel = new System.Windows.Forms.Label();
			this.PriceLabel = new System.Windows.Forms.Label();
			this.WeightLabel = new System.Windows.Forms.Label();
			this.HandsLabel = new System.Windows.Forms.Label();
			this.AttackValueLabel = new System.Windows.Forms.Label();
			this.AttackModifierLabel = new System.Windows.Forms.Label();
			this.DamageValueLabel = new System.Windows.Forms.Label();
			this.DamageModifierLabel = new System.Windows.Forms.Label();
			this.CharacterClassesLabel = new System.Windows.Forms.Label();
			this.ClassList = new System.Windows.Forms.ListBox();
			this.AddButton = new System.Windows.Forms.Button();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AllowedList = new System.Windows.Forms.ListBox();
			this.AllowedClassesLabel = new System.Windows.Forms.Label();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PriceBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.WeightBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AttackValueBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.AttackModifierBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageValueBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageModifierBox)).BeginInit();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(64, 13);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(38, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Name:";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(108, 10);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(120, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
			// 
			// TypeBox
			// 
			this.TypeBox.Location = new System.Drawing.Point(108, 36);
			this.TypeBox.Name = "TypeBox";
			this.TypeBox.Size = new System.Drawing.Size(120, 20);
			this.TypeBox.TabIndex = 3;
			this.TypeBox.TextChanged += new System.EventHandler(this.TypeBoxTextChanged);
			// 
			// PriceBox
			// 
			this.PriceBox.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.PriceBox.Location = new System.Drawing.Point(108, 62);
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
			// WeightBox
			// 
			this.WeightBox.DecimalPlaces = 2;
			this.WeightBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.WeightBox.Location = new System.Drawing.Point(108, 88);
			this.WeightBox.Name = "WeightBox";
			this.WeightBox.Size = new System.Drawing.Size(120, 20);
			this.WeightBox.TabIndex = 7;
			this.WeightBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// HandsBox
			// 
			this.HandsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.HandsBox.FormattingEnabled = true;
			this.HandsBox.Location = new System.Drawing.Point(108, 114);
			this.HandsBox.Name = "HandsBox";
			this.HandsBox.Size = new System.Drawing.Size(120, 21);
			this.HandsBox.TabIndex = 9;
			// 
			// AttackValueBox
			// 
			this.AttackValueBox.Location = new System.Drawing.Point(108, 141);
			this.AttackValueBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.AttackValueBox.Name = "AttackValueBox";
			this.AttackValueBox.Size = new System.Drawing.Size(120, 20);
			this.AttackValueBox.TabIndex = 11;
			this.AttackValueBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// AttackModifierBox
			// 
			this.AttackModifierBox.Location = new System.Drawing.Point(108, 167);
			this.AttackModifierBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.AttackModifierBox.Name = "AttackModifierBox";
			this.AttackModifierBox.Size = new System.Drawing.Size(120, 20);
			this.AttackModifierBox.TabIndex = 13;
			this.AttackModifierBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// DamageValueBox
			// 
			this.DamageValueBox.Location = new System.Drawing.Point(108, 193);
			this.DamageValueBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DamageValueBox.Name = "DamageValueBox";
			this.DamageValueBox.Size = new System.Drawing.Size(120, 20);
			this.DamageValueBox.TabIndex = 15;
			this.DamageValueBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// DamageModifierBox
			// 
			this.DamageModifierBox.Location = new System.Drawing.Point(108, 219);
			this.DamageModifierBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.DamageModifierBox.Name = "DamageModifierBox";
			this.DamageModifierBox.Size = new System.Drawing.Size(120, 20);
			this.DamageModifierBox.TabIndex = 17;
			this.DamageModifierBox.Enter += new System.EventHandler(this.NumericUpDownEnter);
			// 
			// TypeLabel
			// 
			this.TypeLabel.AutoSize = true;
			this.TypeLabel.Location = new System.Drawing.Point(68, 39);
			this.TypeLabel.Name = "TypeLabel";
			this.TypeLabel.Size = new System.Drawing.Size(34, 13);
			this.TypeLabel.TabIndex = 2;
			this.TypeLabel.Text = "Type:";
			// 
			// PriceLabel
			// 
			this.PriceLabel.AutoSize = true;
			this.PriceLabel.Location = new System.Drawing.Point(68, 64);
			this.PriceLabel.Name = "PriceLabel";
			this.PriceLabel.Size = new System.Drawing.Size(34, 13);
			this.PriceLabel.TabIndex = 4;
			this.PriceLabel.Text = "Price:";
			// 
			// WeightLabel
			// 
			this.WeightLabel.AutoSize = true;
			this.WeightLabel.Location = new System.Drawing.Point(58, 90);
			this.WeightLabel.Name = "WeightLabel";
			this.WeightLabel.Size = new System.Drawing.Size(44, 13);
			this.WeightLabel.TabIndex = 6;
			this.WeightLabel.Text = "Weight:";
			// 
			// HandsLabel
			// 
			this.HandsLabel.AutoSize = true;
			this.HandsLabel.Location = new System.Drawing.Point(61, 117);
			this.HandsLabel.Name = "HandsLabel";
			this.HandsLabel.Size = new System.Drawing.Size(41, 13);
			this.HandsLabel.TabIndex = 8;
			this.HandsLabel.Text = "Hands:";
			// 
			// AttackValueLabel
			// 
			this.AttackValueLabel.AutoSize = true;
			this.AttackValueLabel.Location = new System.Drawing.Point(31, 143);
			this.AttackValueLabel.Name = "AttackValueLabel";
			this.AttackValueLabel.Size = new System.Drawing.Size(71, 13);
			this.AttackValueLabel.TabIndex = 10;
			this.AttackValueLabel.Text = "Attack Value:";
			// 
			// AttackModifierLabel
			// 
			this.AttackModifierLabel.AutoSize = true;
			this.AttackModifierLabel.Location = new System.Drawing.Point(21, 169);
			this.AttackModifierLabel.Name = "AttackModifierLabel";
			this.AttackModifierLabel.Size = new System.Drawing.Size(81, 13);
			this.AttackModifierLabel.TabIndex = 12;
			this.AttackModifierLabel.Text = "Attack Modifier:";
			// 
			// DamageValueLabel
			// 
			this.DamageValueLabel.AutoSize = true;
			this.DamageValueLabel.Location = new System.Drawing.Point(22, 195);
			this.DamageValueLabel.Name = "DamageValueLabel";
			this.DamageValueLabel.Size = new System.Drawing.Size(80, 13);
			this.DamageValueLabel.TabIndex = 14;
			this.DamageValueLabel.Text = "Damage Value:";
			// 
			// DamageModifierLabel
			// 
			this.DamageModifierLabel.AutoSize = true;
			this.DamageModifierLabel.Location = new System.Drawing.Point(12, 221);
			this.DamageModifierLabel.Name = "DamageModifierLabel";
			this.DamageModifierLabel.Size = new System.Drawing.Size(90, 13);
			this.DamageModifierLabel.TabIndex = 16;
			this.DamageModifierLabel.Text = "Damage Modifier:";
			// 
			// CharacterClassesLabel
			// 
			this.CharacterClassesLabel.AutoSize = true;
			this.CharacterClassesLabel.Location = new System.Drawing.Point(243, 13);
			this.CharacterClassesLabel.Name = "CharacterClassesLabel";
			this.CharacterClassesLabel.Size = new System.Drawing.Size(95, 13);
			this.CharacterClassesLabel.TabIndex = 18;
			this.CharacterClassesLabel.Text = "Character Classes:";
			// 
			// ClassList
			// 
			this.ClassList.FormattingEnabled = true;
			this.ClassList.Location = new System.Drawing.Point(246, 29);
			this.ClassList.Name = "ClassList";
			this.ClassList.Size = new System.Drawing.Size(120, 173);
			this.ClassList.TabIndex = 19;
			this.ClassList.DoubleClick += new System.EventHandler(this.ClassListDoubleClick);
			// 
			// AddButton
			// 
			this.AddButton.Location = new System.Drawing.Point(372, 80);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 20;
			this.AddButton.Text = ">>";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Location = new System.Drawing.Point(372, 117);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveButton.TabIndex = 21;
			this.RemoveButton.Text = "<<";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
			// 
			// AllowedList
			// 
			this.AllowedList.FormattingEnabled = true;
			this.AllowedList.Location = new System.Drawing.Point(453, 29);
			this.AllowedList.Name = "AllowedList";
			this.AllowedList.Size = new System.Drawing.Size(120, 173);
			this.AllowedList.TabIndex = 23;
			this.AllowedList.DoubleClick += new System.EventHandler(this.AllowedListDoubleClick);
			// 
			// AllowedClassesLabel
			// 
			this.AllowedClassesLabel.AutoSize = true;
			this.AllowedClassesLabel.Location = new System.Drawing.Point(450, 13);
			this.AllowedClassesLabel.Name = "AllowedClassesLabel";
			this.AllowedClassesLabel.Size = new System.Drawing.Size(86, 13);
			this.AllowedClassesLabel.TabIndex = 22;
			this.AllowedClassesLabel.Text = "Allowed Classes:";
			// 
			// OkButton
			// 
			this.OkButton.Enabled = false;
			this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OkButton.Location = new System.Drawing.Point(300, 212);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(90, 30);
			this.OkButton.TabIndex = 24;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormCancelButton.Location = new System.Drawing.Point(429, 212);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(90, 30);
			this.FormCancelButton.TabIndex = 25;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// FormWeaponDetail
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
			this.Controls.Add(this.DamageModifierLabel);
			this.Controls.Add(this.DamageValueLabel);
			this.Controls.Add(this.AttackModifierLabel);
			this.Controls.Add(this.AttackValueLabel);
			this.Controls.Add(this.HandsLabel);
			this.Controls.Add(this.WeightLabel);
			this.Controls.Add(this.PriceLabel);
			this.Controls.Add(this.TypeLabel);
			this.Controls.Add(this.DamageModifierBox);
			this.Controls.Add(this.DamageValueBox);
			this.Controls.Add(this.AttackModifierBox);
			this.Controls.Add(this.AttackValueBox);
			this.Controls.Add(this.HandsBox);
			this.Controls.Add(this.WeightBox);
			this.Controls.Add(this.PriceBox);
			this.Controls.Add(this.TypeBox);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormWeaponDetail";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Weapon Details";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWeaponDetailFormClosing);
			this.Load += new System.EventHandler(this.FormWeaponDetailsLoad);
			((System.ComponentModel.ISupportInitialize)(this.PriceBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.WeightBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AttackValueBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.AttackModifierBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageValueBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DamageModifierBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.TextBox TypeBox;
		private System.Windows.Forms.NumericUpDown PriceBox;
		private System.Windows.Forms.NumericUpDown WeightBox;
		private System.Windows.Forms.ComboBox HandsBox;
		private System.Windows.Forms.NumericUpDown AttackValueBox;
		private System.Windows.Forms.NumericUpDown AttackModifierBox;
		private System.Windows.Forms.NumericUpDown DamageValueBox;
		private System.Windows.Forms.NumericUpDown DamageModifierBox;
		private System.Windows.Forms.Label TypeLabel;
		private System.Windows.Forms.Label PriceLabel;
		private System.Windows.Forms.Label WeightLabel;
		private System.Windows.Forms.Label HandsLabel;
		private System.Windows.Forms.Label AttackValueLabel;
		private System.Windows.Forms.Label AttackModifierLabel;
		private System.Windows.Forms.Label DamageValueLabel;
		private System.Windows.Forms.Label DamageModifierLabel;
		private System.Windows.Forms.Label CharacterClassesLabel;
		private System.Windows.Forms.ListBox ClassList;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.ListBox AllowedList;
		private System.Windows.Forms.Label AllowedClassesLabel;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button FormCancelButton;
	}
}