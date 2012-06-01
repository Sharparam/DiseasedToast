namespace RpgEditor
{
	partial class FormSkillData
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
			this.AttributeGroup = new System.Windows.Forms.GroupBox();
			this.ConstitutionButton = new System.Windows.Forms.RadioButton();
			this.MagicButton = new System.Windows.Forms.RadioButton();
			this.WillpowerButton = new System.Windows.Forms.RadioButton();
			this.CunningButton = new System.Windows.Forms.RadioButton();
			this.DexterityButton = new System.Windows.Forms.RadioButton();
			this.StrengthButton = new System.Windows.Forms.RadioButton();
			this.ModifierGroup = new System.Windows.Forms.GroupBox();
			this.EditButton = new System.Windows.Forms.Button();
			this.RemoveButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.ModifierList = new System.Windows.Forms.ListBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.FormCancelButton = new System.Windows.Forms.Button();
			this.AttributeGroup.SuspendLayout();
			this.ModifierGroup.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Location = new System.Drawing.Point(12, 15);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(60, 13);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "Skill Name:";
			// 
			// NameBox
			// 
			this.NameBox.Location = new System.Drawing.Point(78, 12);
			this.NameBox.Name = "NameBox";
			this.NameBox.Size = new System.Drawing.Size(150, 20);
			this.NameBox.TabIndex = 1;
			this.NameBox.TextChanged += new System.EventHandler(this.NameBoxTextChanged);
			// 
			// AttributeGroup
			// 
			this.AttributeGroup.Controls.Add(this.ConstitutionButton);
			this.AttributeGroup.Controls.Add(this.MagicButton);
			this.AttributeGroup.Controls.Add(this.WillpowerButton);
			this.AttributeGroup.Controls.Add(this.CunningButton);
			this.AttributeGroup.Controls.Add(this.DexterityButton);
			this.AttributeGroup.Controls.Add(this.StrengthButton);
			this.AttributeGroup.Location = new System.Drawing.Point(12, 38);
			this.AttributeGroup.Name = "AttributeGroup";
			this.AttributeGroup.Size = new System.Drawing.Size(107, 161);
			this.AttributeGroup.TabIndex = 2;
			this.AttributeGroup.TabStop = false;
			this.AttributeGroup.Text = "Primary Attribute";
			// 
			// ConstitutionButton
			// 
			this.ConstitutionButton.AutoSize = true;
			this.ConstitutionButton.Location = new System.Drawing.Point(6, 134);
			this.ConstitutionButton.Name = "ConstitutionButton";
			this.ConstitutionButton.Size = new System.Drawing.Size(80, 17);
			this.ConstitutionButton.TabIndex = 0;
			this.ConstitutionButton.Text = "Constitution";
			this.ConstitutionButton.UseVisualStyleBackColor = true;
			// 
			// MagicButton
			// 
			this.MagicButton.AutoSize = true;
			this.MagicButton.Location = new System.Drawing.Point(6, 111);
			this.MagicButton.Name = "MagicButton";
			this.MagicButton.Size = new System.Drawing.Size(54, 17);
			this.MagicButton.TabIndex = 0;
			this.MagicButton.Text = "Magic";
			this.MagicButton.UseVisualStyleBackColor = true;
			// 
			// WillpowerButton
			// 
			this.WillpowerButton.AutoSize = true;
			this.WillpowerButton.Location = new System.Drawing.Point(6, 88);
			this.WillpowerButton.Name = "WillpowerButton";
			this.WillpowerButton.Size = new System.Drawing.Size(71, 17);
			this.WillpowerButton.TabIndex = 0;
			this.WillpowerButton.Text = "Willpower";
			this.WillpowerButton.UseVisualStyleBackColor = true;
			// 
			// CunningButton
			// 
			this.CunningButton.AutoSize = true;
			this.CunningButton.Location = new System.Drawing.Point(6, 65);
			this.CunningButton.Name = "CunningButton";
			this.CunningButton.Size = new System.Drawing.Size(64, 17);
			this.CunningButton.TabIndex = 0;
			this.CunningButton.Text = "Cunning";
			this.CunningButton.UseVisualStyleBackColor = true;
			// 
			// DexterityButton
			// 
			this.DexterityButton.AutoSize = true;
			this.DexterityButton.Location = new System.Drawing.Point(6, 42);
			this.DexterityButton.Name = "DexterityButton";
			this.DexterityButton.Size = new System.Drawing.Size(66, 17);
			this.DexterityButton.TabIndex = 0;
			this.DexterityButton.Text = "Dexterity";
			this.DexterityButton.UseVisualStyleBackColor = true;
			// 
			// StrengthButton
			// 
			this.StrengthButton.AutoSize = true;
			this.StrengthButton.Checked = true;
			this.StrengthButton.Location = new System.Drawing.Point(6, 19);
			this.StrengthButton.Name = "StrengthButton";
			this.StrengthButton.Size = new System.Drawing.Size(65, 17);
			this.StrengthButton.TabIndex = 0;
			this.StrengthButton.TabStop = true;
			this.StrengthButton.Text = "Strength";
			this.StrengthButton.UseVisualStyleBackColor = true;
			// 
			// ModifierGroup
			// 
			this.ModifierGroup.Controls.Add(this.EditButton);
			this.ModifierGroup.Controls.Add(this.RemoveButton);
			this.ModifierGroup.Controls.Add(this.AddButton);
			this.ModifierGroup.Controls.Add(this.ModifierList);
			this.ModifierGroup.Location = new System.Drawing.Point(125, 38);
			this.ModifierGroup.Name = "ModifierGroup";
			this.ModifierGroup.Size = new System.Drawing.Size(400, 161);
			this.ModifierGroup.TabIndex = 3;
			this.ModifierGroup.TabStop = false;
			this.ModifierGroup.Text = "Class Modifiers";
			// 
			// EditButton
			// 
			this.EditButton.Location = new System.Drawing.Point(162, 132);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(75, 23);
			this.EditButton.TabIndex = 2;
			this.EditButton.Text = "&Edit";
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += new System.EventHandler(this.EditButtonClick);
			// 
			// RemoveButton
			// 
			this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.RemoveButton.Location = new System.Drawing.Point(254, 131);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new System.Drawing.Size(75, 23);
			this.RemoveButton.TabIndex = 1;
			this.RemoveButton.Text = "&Remove";
			this.RemoveButton.UseVisualStyleBackColor = true;
			this.RemoveButton.Click += new System.EventHandler(this.RemoveButtonClick);
			// 
			// AddButton
			// 
			this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.AddButton.Location = new System.Drawing.Point(70, 132);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(75, 23);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "&Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += new System.EventHandler(this.AddButtonClick);
			// 
			// ModifierList
			// 
			this.ModifierList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ModifierList.FormattingEnabled = true;
			this.ModifierList.Location = new System.Drawing.Point(6, 19);
			this.ModifierList.Name = "ModifierList";
			this.ModifierList.Size = new System.Drawing.Size(388, 108);
			this.ModifierList.TabIndex = 0;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.OkButton.Enabled = false;
			this.OkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.OkButton.Location = new System.Drawing.Point(162, 210);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(80, 30);
			this.OkButton.TabIndex = 4;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			this.OkButton.Click += new System.EventHandler(this.OkButtonClick);
			// 
			// FormCancelButton
			// 
			this.FormCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.FormCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.FormCancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormCancelButton.Location = new System.Drawing.Point(292, 210);
			this.FormCancelButton.Name = "FormCancelButton";
			this.FormCancelButton.Size = new System.Drawing.Size(80, 30);
			this.FormCancelButton.TabIndex = 5;
			this.FormCancelButton.Text = "&Cancel";
			this.FormCancelButton.UseVisualStyleBackColor = true;
			this.FormCancelButton.Click += new System.EventHandler(this.FormCancelButtonClick);
			// 
			// FormSkillData
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.FormCancelButton;
			this.ClientSize = new System.Drawing.Size(534, 252);
			this.ControlBox = false;
			this.Controls.Add(this.FormCancelButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.ModifierGroup);
			this.Controls.Add(this.AttributeGroup);
			this.Controls.Add(this.NameBox);
			this.Controls.Add(this.NameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormSkillData";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Skill";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSkillDataFormClosing);
			this.Load += new System.EventHandler(this.FormSkillDataLoad);
			this.AttributeGroup.ResumeLayout(false);
			this.AttributeGroup.PerformLayout();
			this.ModifierGroup.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.TextBox NameBox;
		private System.Windows.Forms.GroupBox AttributeGroup;
		private System.Windows.Forms.RadioButton ConstitutionButton;
		private System.Windows.Forms.RadioButton MagicButton;
		private System.Windows.Forms.RadioButton WillpowerButton;
		private System.Windows.Forms.RadioButton CunningButton;
		private System.Windows.Forms.RadioButton DexterityButton;
		private System.Windows.Forms.RadioButton StrengthButton;
		private System.Windows.Forms.GroupBox ModifierGroup;
		private System.Windows.Forms.Button EditButton;
		private System.Windows.Forms.Button RemoveButton;
		private System.Windows.Forms.Button AddButton;
		private System.Windows.Forms.ListBox ModifierList;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button FormCancelButton;
	}
}