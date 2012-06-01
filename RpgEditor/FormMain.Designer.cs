namespace RpgEditor
{
	partial class FormMain
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
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.GameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveGameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ClassesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.WeaponsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ArmorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ShieldsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.KeysMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ContainersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SkillsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MenuBar.SuspendLayout();
			this.StatusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuBar
			// 
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenuItem,
            this.ClassesMenuItem,
            this.ItemsMenuItem,
            this.KeysMenuItem,
            this.ContainersMenuItem,
            this.SkillsMenuItem});
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.Size = new System.Drawing.Size(1264, 24);
			this.MenuBar.TabIndex = 0;
			this.MenuBar.Text = "menuStrip1";
			// 
			// GameMenuItem
			// 
			this.GameMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGameMenuItem,
            this.OpenGameMenuItem,
            this.SaveGameMenuItem,
            this.ExportMenuItem,
            this.toolStripMenuItem1,
            this.ExitMenuItem});
			this.GameMenuItem.Name = "GameMenuItem";
			this.GameMenuItem.Size = new System.Drawing.Size(50, 20);
			this.GameMenuItem.Text = "&Game";
			// 
			// NewGameMenuItem
			// 
			this.NewGameMenuItem.Name = "NewGameMenuItem";
			this.NewGameMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.NewGameMenuItem.Size = new System.Drawing.Size(200, 22);
			this.NewGameMenuItem.Text = "&New Game";
			this.NewGameMenuItem.Click += new System.EventHandler(this.NewGameMenuItemClick);
			// 
			// OpenGameMenuItem
			// 
			this.OpenGameMenuItem.Name = "OpenGameMenuItem";
			this.OpenGameMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.OpenGameMenuItem.Size = new System.Drawing.Size(200, 22);
			this.OpenGameMenuItem.Text = "&Open Game";
			this.OpenGameMenuItem.Click += new System.EventHandler(this.OpenGameMenuItemClick);
			// 
			// SaveGameMenuItem
			// 
			this.SaveGameMenuItem.Name = "SaveGameMenuItem";
			this.SaveGameMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveGameMenuItem.Size = new System.Drawing.Size(200, 22);
			this.SaveGameMenuItem.Text = "&Save Game";
			this.SaveGameMenuItem.Click += new System.EventHandler(this.SaveGameMenuItemClick);
			// 
			// ExportMenuItem
			// 
			this.ExportMenuItem.Enabled = false;
			this.ExportMenuItem.Name = "ExportMenuItem";
			this.ExportMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.ExportMenuItem.Size = new System.Drawing.Size(200, 22);
			this.ExportMenuItem.Text = "Export Data Files";
			this.ExportMenuItem.Click += new System.EventHandler(this.ExportMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
			// 
			// ExitMenuItem
			// 
			this.ExitMenuItem.Name = "ExitMenuItem";
			this.ExitMenuItem.Size = new System.Drawing.Size(200, 22);
			this.ExitMenuItem.Text = "E&xit Game";
			this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
			// 
			// ClassesMenuItem
			// 
			this.ClassesMenuItem.Enabled = false;
			this.ClassesMenuItem.Name = "ClassesMenuItem";
			this.ClassesMenuItem.Size = new System.Drawing.Size(57, 20);
			this.ClassesMenuItem.Text = "&Classes";
			this.ClassesMenuItem.Click += new System.EventHandler(this.ClassesMenuItemClick);
			// 
			// ItemsMenuItem
			// 
			this.ItemsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WeaponsMenuItem,
            this.ArmorMenuItem,
            this.ShieldsMenuItem});
			this.ItemsMenuItem.Enabled = false;
			this.ItemsMenuItem.Name = "ItemsMenuItem";
			this.ItemsMenuItem.Size = new System.Drawing.Size(48, 20);
			this.ItemsMenuItem.Text = "&Items";
			// 
			// WeaponsMenuItem
			// 
			this.WeaponsMenuItem.Name = "WeaponsMenuItem";
			this.WeaponsMenuItem.Size = new System.Drawing.Size(123, 22);
			this.WeaponsMenuItem.Text = "&Weapons";
			this.WeaponsMenuItem.Click += new System.EventHandler(this.WeaponsMenuItemClick);
			// 
			// ArmorMenuItem
			// 
			this.ArmorMenuItem.Name = "ArmorMenuItem";
			this.ArmorMenuItem.Size = new System.Drawing.Size(123, 22);
			this.ArmorMenuItem.Text = "&Armor";
			this.ArmorMenuItem.Click += new System.EventHandler(this.ArmorMenuItemClick);
			// 
			// ShieldsMenuItem
			// 
			this.ShieldsMenuItem.Name = "ShieldsMenuItem";
			this.ShieldsMenuItem.Size = new System.Drawing.Size(123, 22);
			this.ShieldsMenuItem.Text = "&Shields";
			this.ShieldsMenuItem.Click += new System.EventHandler(this.ShieldsMenuItemClick);
			// 
			// KeysMenuItem
			// 
			this.KeysMenuItem.Enabled = false;
			this.KeysMenuItem.Name = "KeysMenuItem";
			this.KeysMenuItem.Size = new System.Drawing.Size(43, 20);
			this.KeysMenuItem.Text = "&Keys";
			this.KeysMenuItem.Click += new System.EventHandler(this.KeysMenuItemClick);
			// 
			// ContainersMenuItem
			// 
			this.ContainersMenuItem.Enabled = false;
			this.ContainersMenuItem.Name = "ContainersMenuItem";
			this.ContainersMenuItem.Size = new System.Drawing.Size(76, 20);
			this.ContainersMenuItem.Text = "C&ontainers";
			this.ContainersMenuItem.Click += new System.EventHandler(this.ContainersMenuItemClick);
			// 
			// SkillsMenuItem
			// 
			this.SkillsMenuItem.Enabled = false;
			this.SkillsMenuItem.Name = "SkillsMenuItem";
			this.SkillsMenuItem.Size = new System.Drawing.Size(45, 20);
			this.SkillsMenuItem.Text = "&Skills";
			this.SkillsMenuItem.Click += new System.EventHandler(this.SkillsMenuItemClick);
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
			this.StatusBar.Location = new System.Drawing.Point(0, 660);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(1264, 22);
			this.StatusBar.TabIndex = 2;
			this.StatusBar.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(26, 17);
			this.StatusLabel.Text = "Idle";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1264, 682);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.MenuBar);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.MenuBar;
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XNA RPG Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
			this.MenuBar.ResumeLayout(false);
			this.MenuBar.PerformLayout();
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem GameMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewGameMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenGameMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveGameMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ClassesMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ItemsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem WeaponsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ArmorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ShieldsMenuItem;
		private System.Windows.Forms.ToolStripMenuItem KeysMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContainersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ExportMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SkillsMenuItem;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
	}
}

