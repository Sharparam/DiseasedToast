namespace RpgEditor
{
	partial class FormDetails
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
			this.DeleteButton = new System.Windows.Forms.Button();
			this.EditButton = new System.Windows.Forms.Button();
			this.AddButton = new System.Windows.Forms.Button();
			this.DetailList = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// DeleteButton
			// 
			this.DeleteButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.DeleteButton.Location = new System.Drawing.Point(500, 440);
			this.DeleteButton.Name = "DeleteButton";
			this.DeleteButton.Size = new System.Drawing.Size(100, 23);
			this.DeleteButton.TabIndex = 3;
			this.DeleteButton.Text = "&Delete";
			this.DeleteButton.UseVisualStyleBackColor = true;
			// 
			// EditButton
			// 
			this.EditButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.EditButton.Location = new System.Drawing.Point(350, 440);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new System.Drawing.Size(100, 23);
			this.EditButton.TabIndex = 2;
			this.EditButton.Text = "&Edit";
			this.EditButton.UseVisualStyleBackColor = true;
			// 
			// AddButton
			// 
			this.AddButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.AddButton.Location = new System.Drawing.Point(200, 440);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new System.Drawing.Size(100, 23);
			this.AddButton.TabIndex = 1;
			this.AddButton.Text = "&Add";
			this.AddButton.UseVisualStyleBackColor = true;
			// 
			// DetailList
			// 
			this.DetailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DetailList.FormattingEnabled = true;
			this.DetailList.HorizontalScrollbar = true;
			this.DetailList.Location = new System.Drawing.Point(12, 7);
			this.DetailList.Name = "DetailList";
			this.DetailList.Size = new System.Drawing.Size(770, 420);
			this.DetailList.TabIndex = 0;
			// 
			// FormDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(794, 472);
			this.Controls.Add(this.DeleteButton);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.DetailList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "FormDetails";
			this.Text = "FormDetails";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDetailsFormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Button DeleteButton;
		protected System.Windows.Forms.Button EditButton;
		protected System.Windows.Forms.Button AddButton;
		protected System.Windows.Forms.ListBox DetailList;
	}
}