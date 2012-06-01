namespace XRpgEditor
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
			this.components = new System.ComponentModel.Container();
			this.MenuBar = new System.Windows.Forms.MenuStrip();
			this.LevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewLevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenLevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveLevelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LevelMenuSplit = new System.Windows.Forms.ToolStripSeparator();
			this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DisplayGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TilesetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewTilesetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenTilesetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveTilesetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RemoveTilesetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SaveLayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CharactersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ContainersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.KeysMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusBar = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MapLocationLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MapContainer = new System.Windows.Forms.SplitContainer();
			this.MapTabs = new System.Windows.Forms.TabControl();
			this.TilePage = new System.Windows.Forms.TabPage();
			this.TileIndexLabel = new System.Windows.Forms.Label();
			this.TilesetList = new System.Windows.Forms.ListBox();
			this.TilesetsLabel = new System.Windows.Forms.Label();
			this.TilesetPreview = new System.Windows.Forms.PictureBox();
			this.CurrentTilesetLabel = new System.Windows.Forms.Label();
			this.CurrentTileBox = new System.Windows.Forms.NumericUpDown();
			this.DrawModeGroup = new System.Windows.Forms.GroupBox();
			this.BrushSizeLabel = new System.Windows.Forms.Label();
			this.BrushSizeBox = new System.Windows.Forms.ComboBox();
			this.EraseButton = new System.Windows.Forms.RadioButton();
			this.DrawButton = new System.Windows.Forms.RadioButton();
			this.TilePreview = new System.Windows.Forms.PictureBox();
			this.TileLabel = new System.Windows.Forms.Label();
			this.LayerTab = new System.Windows.Forms.TabPage();
			this.LayerList = new System.Windows.Forms.CheckedListBox();
			this.CharacterPage = new System.Windows.Forms.TabPage();
			this.ContainerPage = new System.Windows.Forms.TabPage();
			this.KeyPage = new System.Windows.Forms.TabPage();
			this.ControlTimer = new System.Windows.Forms.Timer(this.components);
			this.BrushSizeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.MapDisplay = new XRpgEditor.MapDisplay();
			this.GridColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BlackGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BlueGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RedGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GreenGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.YellowGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.WhiteGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.MenuBar.SuspendLayout();
			this.StatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MapContainer)).BeginInit();
			this.MapContainer.Panel1.SuspendLayout();
			this.MapContainer.Panel2.SuspendLayout();
			this.MapContainer.SuspendLayout();
			this.MapTabs.SuspendLayout();
			this.TilePage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TilesetPreview)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentTileBox)).BeginInit();
			this.DrawModeGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TilePreview)).BeginInit();
			this.LayerTab.SuspendLayout();
			this.SuspendLayout();
			// 
			// MenuBar
			// 
			this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LevelMenuItem,
            this.ViewMenuItem,
            this.TilesetMenuItem,
            this.LayerMenuItem,
            this.CharactersMenuItem,
            this.ContainersMenuItem,
            this.KeysMenuItem});
			this.MenuBar.Location = new System.Drawing.Point(0, 0);
			this.MenuBar.Name = "MenuBar";
			this.MenuBar.Size = new System.Drawing.Size(1008, 24);
			this.MenuBar.TabIndex = 0;
			this.MenuBar.Text = "menuStrip1";
			// 
			// LevelMenuItem
			// 
			this.LevelMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewLevelMenuItem,
            this.OpenLevelMenuItem,
            this.SaveLevelMenuItem,
            this.LevelMenuSplit,
            this.ExitMenuItem});
			this.LevelMenuItem.Name = "LevelMenuItem";
			this.LevelMenuItem.Size = new System.Drawing.Size(46, 20);
			this.LevelMenuItem.Text = "&Level";
			// 
			// NewLevelMenuItem
			// 
			this.NewLevelMenuItem.Name = "NewLevelMenuItem";
			this.NewLevelMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.NewLevelMenuItem.Size = new System.Drawing.Size(176, 22);
			this.NewLevelMenuItem.Text = "&New Level";
			this.NewLevelMenuItem.Click += new System.EventHandler(this.NewLevelMenuItemClick);
			// 
			// OpenLevelMenuItem
			// 
			this.OpenLevelMenuItem.Name = "OpenLevelMenuItem";
			this.OpenLevelMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.OpenLevelMenuItem.Size = new System.Drawing.Size(176, 22);
			this.OpenLevelMenuItem.Text = "&Open Level";
			this.OpenLevelMenuItem.Click += new System.EventHandler(this.OpenLevelMenuItemClick);
			// 
			// SaveLevelMenuItem
			// 
			this.SaveLevelMenuItem.Enabled = false;
			this.SaveLevelMenuItem.Name = "SaveLevelMenuItem";
			this.SaveLevelMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.SaveLevelMenuItem.Size = new System.Drawing.Size(176, 22);
			this.SaveLevelMenuItem.Text = "&Save Level";
			this.SaveLevelMenuItem.Click += new System.EventHandler(this.SaveLevelMenuItemClick);
			// 
			// LevelMenuSplit
			// 
			this.LevelMenuSplit.Name = "LevelMenuSplit";
			this.LevelMenuSplit.Size = new System.Drawing.Size(173, 6);
			// 
			// ExitMenuItem
			// 
			this.ExitMenuItem.Name = "ExitMenuItem";
			this.ExitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.ExitMenuItem.Size = new System.Drawing.Size(176, 22);
			this.ExitMenuItem.Text = "E&xit";
			// 
			// ViewMenuItem
			// 
			this.ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayGridMenuItem,
            this.GridColorMenuItem});
			this.ViewMenuItem.Name = "ViewMenuItem";
			this.ViewMenuItem.Size = new System.Drawing.Size(44, 20);
			this.ViewMenuItem.Text = "&View";
			// 
			// DisplayGridMenuItem
			// 
			this.DisplayGridMenuItem.Checked = true;
			this.DisplayGridMenuItem.CheckOnClick = true;
			this.DisplayGridMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DisplayGridMenuItem.Name = "DisplayGridMenuItem";
			this.DisplayGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.DisplayGridMenuItem.Text = "&Display Grid";
			// 
			// TilesetMenuItem
			// 
			this.TilesetMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTilesetMenuItem,
            this.OpenTilesetMenuItem,
            this.SaveTilesetMenuItem,
            this.RemoveTilesetMenuItem});
			this.TilesetMenuItem.Enabled = false;
			this.TilesetMenuItem.Name = "TilesetMenuItem";
			this.TilesetMenuItem.Size = new System.Drawing.Size(53, 20);
			this.TilesetMenuItem.Text = "&Tileset";
			// 
			// NewTilesetMenuItem
			// 
			this.NewTilesetMenuItem.Name = "NewTilesetMenuItem";
			this.NewTilesetMenuItem.Size = new System.Drawing.Size(154, 22);
			this.NewTilesetMenuItem.Text = "&New Tileset";
			this.NewTilesetMenuItem.Click += new System.EventHandler(this.NewTilesetMenuItemClick);
			// 
			// OpenTilesetMenuItem
			// 
			this.OpenTilesetMenuItem.Name = "OpenTilesetMenuItem";
			this.OpenTilesetMenuItem.Size = new System.Drawing.Size(154, 22);
			this.OpenTilesetMenuItem.Text = "&Open Tileset";
			this.OpenTilesetMenuItem.Click += new System.EventHandler(this.OpenTilesetMenuItemClick);
			// 
			// SaveTilesetMenuItem
			// 
			this.SaveTilesetMenuItem.Name = "SaveTilesetMenuItem";
			this.SaveTilesetMenuItem.Size = new System.Drawing.Size(154, 22);
			this.SaveTilesetMenuItem.Text = "&Save Tileset";
			this.SaveTilesetMenuItem.Click += new System.EventHandler(this.SaveTilesetMenuItemClick);
			// 
			// RemoveTilesetMenuItem
			// 
			this.RemoveTilesetMenuItem.Name = "RemoveTilesetMenuItem";
			this.RemoveTilesetMenuItem.Size = new System.Drawing.Size(154, 22);
			this.RemoveTilesetMenuItem.Text = "&Remove Tileset";
			this.RemoveTilesetMenuItem.Click += new System.EventHandler(this.RemoveTilesetMenuItemClick);
			// 
			// LayerMenuItem
			// 
			this.LayerMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewLayerMenuItem,
            this.OpenLayerMenuItem,
            this.SaveLayerMenuItem});
			this.LayerMenuItem.Enabled = false;
			this.LayerMenuItem.Name = "LayerMenuItem";
			this.LayerMenuItem.Size = new System.Drawing.Size(74, 20);
			this.LayerMenuItem.Text = "&Map Layer";
			// 
			// NewLayerMenuItem
			// 
			this.NewLayerMenuItem.Name = "NewLayerMenuItem";
			this.NewLayerMenuItem.Size = new System.Drawing.Size(134, 22);
			this.NewLayerMenuItem.Text = "&New Layer";
			this.NewLayerMenuItem.Click += new System.EventHandler(this.NewLayerMenuItemClick);
			// 
			// OpenLayerMenuItem
			// 
			this.OpenLayerMenuItem.Name = "OpenLayerMenuItem";
			this.OpenLayerMenuItem.Size = new System.Drawing.Size(134, 22);
			this.OpenLayerMenuItem.Text = "&Open Layer";
			this.OpenLayerMenuItem.Click += new System.EventHandler(this.OpenLayerMenuItemClick);
			// 
			// SaveLayerMenuItem
			// 
			this.SaveLayerMenuItem.Name = "SaveLayerMenuItem";
			this.SaveLayerMenuItem.Size = new System.Drawing.Size(134, 22);
			this.SaveLayerMenuItem.Text = "&Save Layer";
			this.SaveLayerMenuItem.Click += new System.EventHandler(this.SaveLayerMenuItemClick);
			// 
			// CharactersMenuItem
			// 
			this.CharactersMenuItem.Enabled = false;
			this.CharactersMenuItem.Name = "CharactersMenuItem";
			this.CharactersMenuItem.Size = new System.Drawing.Size(75, 20);
			this.CharactersMenuItem.Text = "&Characters";
			this.CharactersMenuItem.Click += new System.EventHandler(this.CharactersMenuItemClick);
			// 
			// ContainersMenuItem
			// 
			this.ContainersMenuItem.Enabled = false;
			this.ContainersMenuItem.Name = "ContainersMenuItem";
			this.ContainersMenuItem.Size = new System.Drawing.Size(76, 20);
			this.ContainersMenuItem.Text = "C&ontainers";
			this.ContainersMenuItem.Click += new System.EventHandler(this.ContainersMenuItemClick);
			// 
			// KeysMenuItem
			// 
			this.KeysMenuItem.Enabled = false;
			this.KeysMenuItem.Name = "KeysMenuItem";
			this.KeysMenuItem.Size = new System.Drawing.Size(43, 20);
			this.KeysMenuItem.Text = "&Keys";
			this.KeysMenuItem.Click += new System.EventHandler(this.KeysMenuItemClick);
			// 
			// StatusBar
			// 
			this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.MapLocationLabel,
            this.BrushSizeStatusLabel});
			this.StatusBar.Location = new System.Drawing.Point(0, 660);
			this.StatusBar.Name = "StatusBar";
			this.StatusBar.Size = new System.Drawing.Size(1008, 22);
			this.StatusBar.TabIndex = 1;
			this.StatusBar.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(26, 17);
			this.StatusLabel.Text = "Idle";
			// 
			// MapLocationLabel
			// 
			this.MapLocationLabel.Name = "MapLocationLabel";
			this.MapLocationLabel.Size = new System.Drawing.Size(85, 17);
			this.MapLocationLabel.Text = "Location: (0, 0)";
			// 
			// MapContainer
			// 
			this.MapContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapContainer.IsSplitterFixed = true;
			this.MapContainer.Location = new System.Drawing.Point(0, 24);
			this.MapContainer.Name = "MapContainer";
			// 
			// MapContainer.Panel1
			// 
			this.MapContainer.Panel1.Controls.Add(this.MapDisplay);
			// 
			// MapContainer.Panel2
			// 
			this.MapContainer.Panel2.Controls.Add(this.MapTabs);
			this.MapContainer.Panel2MinSize = 250;
			this.MapContainer.Size = new System.Drawing.Size(1008, 636);
			this.MapContainer.SplitterDistance = 754;
			this.MapContainer.TabIndex = 2;
			this.MapContainer.Resize += new System.EventHandler(this.MapContainerResize);
			// 
			// MapTabs
			// 
			this.MapTabs.Controls.Add(this.TilePage);
			this.MapTabs.Controls.Add(this.LayerTab);
			this.MapTabs.Controls.Add(this.CharacterPage);
			this.MapTabs.Controls.Add(this.ContainerPage);
			this.MapTabs.Controls.Add(this.KeyPage);
			this.MapTabs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapTabs.Location = new System.Drawing.Point(0, 0);
			this.MapTabs.Name = "MapTabs";
			this.MapTabs.SelectedIndex = 0;
			this.MapTabs.Size = new System.Drawing.Size(250, 636);
			this.MapTabs.TabIndex = 0;
			// 
			// TilePage
			// 
			this.TilePage.Controls.Add(this.TileIndexLabel);
			this.TilePage.Controls.Add(this.TilesetList);
			this.TilePage.Controls.Add(this.TilesetsLabel);
			this.TilePage.Controls.Add(this.TilesetPreview);
			this.TilePage.Controls.Add(this.CurrentTilesetLabel);
			this.TilePage.Controls.Add(this.CurrentTileBox);
			this.TilePage.Controls.Add(this.DrawModeGroup);
			this.TilePage.Controls.Add(this.TilePreview);
			this.TilePage.Controls.Add(this.TileLabel);
			this.TilePage.Location = new System.Drawing.Point(4, 22);
			this.TilePage.Name = "TilePage";
			this.TilePage.Padding = new System.Windows.Forms.Padding(3);
			this.TilePage.Size = new System.Drawing.Size(242, 610);
			this.TilePage.TabIndex = 0;
			this.TilePage.Text = "Tiles";
			this.TilePage.UseVisualStyleBackColor = true;
			// 
			// TileIndexLabel
			// 
			this.TileIndexLabel.AutoSize = true;
			this.TileIndexLabel.Location = new System.Drawing.Point(6, 86);
			this.TileIndexLabel.Name = "TileIndexLabel";
			this.TileIndexLabel.Size = new System.Drawing.Size(56, 13);
			this.TileIndexLabel.TabIndex = 8;
			this.TileIndexLabel.Text = "Tile Index:";
			// 
			// TilesetList
			// 
			this.TilesetList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TilesetList.FormattingEnabled = true;
			this.TilesetList.Location = new System.Drawing.Point(7, 387);
			this.TilesetList.Name = "TilesetList";
			this.TilesetList.Size = new System.Drawing.Size(227, 212);
			this.TilesetList.TabIndex = 7;
			this.TilesetList.SelectedIndexChanged += new System.EventHandler(this.TilesetListSelectedIndexChanged);
			// 
			// TilesetsLabel
			// 
			this.TilesetsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TilesetsLabel.Location = new System.Drawing.Point(7, 361);
			this.TilesetsLabel.Name = "TilesetsLabel";
			this.TilesetsLabel.Size = new System.Drawing.Size(227, 23);
			this.TilesetsLabel.TabIndex = 6;
			this.TilesetsLabel.Text = "Tilesets";
			this.TilesetsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// TilesetPreview
			// 
			this.TilesetPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TilesetPreview.Location = new System.Drawing.Point(7, 138);
			this.TilesetPreview.Name = "TilesetPreview";
			this.TilesetPreview.Size = new System.Drawing.Size(227, 220);
			this.TilesetPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.TilesetPreview.TabIndex = 5;
			this.TilesetPreview.TabStop = false;
			this.TilesetPreview.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TilesetPreviewMouseDown);
			// 
			// CurrentTilesetLabel
			// 
			this.CurrentTilesetLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CurrentTilesetLabel.Location = new System.Drawing.Point(7, 112);
			this.CurrentTilesetLabel.Name = "CurrentTilesetLabel";
			this.CurrentTilesetLabel.Size = new System.Drawing.Size(227, 23);
			this.CurrentTilesetLabel.TabIndex = 4;
			this.CurrentTilesetLabel.Text = "Current Tileset";
			this.CurrentTilesetLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// CurrentTileBox
			// 
			this.CurrentTileBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.CurrentTileBox.Location = new System.Drawing.Point(68, 84);
			this.CurrentTileBox.Name = "CurrentTileBox";
			this.CurrentTileBox.Size = new System.Drawing.Size(166, 20);
			this.CurrentTileBox.TabIndex = 3;
			this.CurrentTileBox.ValueChanged += new System.EventHandler(this.CurrentTileBoxValueChanged);
			// 
			// DrawModeGroup
			// 
			this.DrawModeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DrawModeGroup.Controls.Add(this.BrushSizeLabel);
			this.DrawModeGroup.Controls.Add(this.BrushSizeBox);
			this.DrawModeGroup.Controls.Add(this.EraseButton);
			this.DrawModeGroup.Controls.Add(this.DrawButton);
			this.DrawModeGroup.Location = new System.Drawing.Point(63, 7);
			this.DrawModeGroup.Name = "DrawModeGroup";
			this.DrawModeGroup.Size = new System.Drawing.Size(171, 70);
			this.DrawModeGroup.TabIndex = 2;
			this.DrawModeGroup.TabStop = false;
			this.DrawModeGroup.Text = "Draw Mode";
			// 
			// BrushSizeLabel
			// 
			this.BrushSizeLabel.AutoSize = true;
			this.BrushSizeLabel.Location = new System.Drawing.Point(63, 22);
			this.BrushSizeLabel.Name = "BrushSizeLabel";
			this.BrushSizeLabel.Size = new System.Drawing.Size(60, 13);
			this.BrushSizeLabel.TabIndex = 2;
			this.BrushSizeLabel.Text = "Brush Size:";
			// 
			// BrushSizeBox
			// 
			this.BrushSizeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.BrushSizeBox.FormattingEnabled = true;
			this.BrushSizeBox.Items.AddRange(new object[] {
            "1 x 1",
            "2 x 2",
            "4 x 4",
            "8 x 8"});
			this.BrushSizeBox.Location = new System.Drawing.Point(65, 42);
			this.BrushSizeBox.Name = "BrushSizeBox";
			this.BrushSizeBox.Size = new System.Drawing.Size(100, 21);
			this.BrushSizeBox.TabIndex = 1;
			this.BrushSizeBox.SelectedIndexChanged += new System.EventHandler(this.BrushSizeBoxSelectedIndexChanged);
			// 
			// EraseButton
			// 
			this.EraseButton.AutoSize = true;
			this.EraseButton.Location = new System.Drawing.Point(7, 43);
			this.EraseButton.Name = "EraseButton";
			this.EraseButton.Size = new System.Drawing.Size(52, 17);
			this.EraseButton.TabIndex = 0;
			this.EraseButton.Text = "Erase";
			this.EraseButton.UseVisualStyleBackColor = true;
			// 
			// DrawButton
			// 
			this.DrawButton.AutoSize = true;
			this.DrawButton.Checked = true;
			this.DrawButton.Location = new System.Drawing.Point(7, 20);
			this.DrawButton.Name = "DrawButton";
			this.DrawButton.Size = new System.Drawing.Size(50, 17);
			this.DrawButton.TabIndex = 0;
			this.DrawButton.TabStop = true;
			this.DrawButton.Text = "Draw";
			this.DrawButton.UseVisualStyleBackColor = true;
			// 
			// TilePreview
			// 
			this.TilePreview.Location = new System.Drawing.Point(7, 27);
			this.TilePreview.Name = "TilePreview";
			this.TilePreview.Size = new System.Drawing.Size(50, 50);
			this.TilePreview.TabIndex = 1;
			this.TilePreview.TabStop = false;
			// 
			// TileLabel
			// 
			this.TileLabel.Location = new System.Drawing.Point(7, 7);
			this.TileLabel.Name = "TileLabel";
			this.TileLabel.Size = new System.Drawing.Size(50, 17);
			this.TileLabel.TabIndex = 0;
			this.TileLabel.Text = "Tile";
			this.TileLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// LayerTab
			// 
			this.LayerTab.Controls.Add(this.LayerList);
			this.LayerTab.Location = new System.Drawing.Point(4, 22);
			this.LayerTab.Name = "LayerTab";
			this.LayerTab.Padding = new System.Windows.Forms.Padding(3);
			this.LayerTab.Size = new System.Drawing.Size(242, 610);
			this.LayerTab.TabIndex = 1;
			this.LayerTab.Text = "Map Layers";
			this.LayerTab.UseVisualStyleBackColor = true;
			// 
			// LayerList
			// 
			this.LayerList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.LayerList.FormattingEnabled = true;
			this.LayerList.Location = new System.Drawing.Point(3, 3);
			this.LayerList.Name = "LayerList";
			this.LayerList.Size = new System.Drawing.Size(236, 604);
			this.LayerList.TabIndex = 0;
			// 
			// CharacterPage
			// 
			this.CharacterPage.Location = new System.Drawing.Point(4, 22);
			this.CharacterPage.Name = "CharacterPage";
			this.CharacterPage.Padding = new System.Windows.Forms.Padding(3);
			this.CharacterPage.Size = new System.Drawing.Size(242, 610);
			this.CharacterPage.TabIndex = 2;
			this.CharacterPage.Text = "Characters";
			this.CharacterPage.UseVisualStyleBackColor = true;
			// 
			// ContainerPage
			// 
			this.ContainerPage.Location = new System.Drawing.Point(4, 22);
			this.ContainerPage.Name = "ContainerPage";
			this.ContainerPage.Padding = new System.Windows.Forms.Padding(3);
			this.ContainerPage.Size = new System.Drawing.Size(242, 610);
			this.ContainerPage.TabIndex = 3;
			this.ContainerPage.Text = "Containers";
			this.ContainerPage.UseVisualStyleBackColor = true;
			// 
			// KeyPage
			// 
			this.KeyPage.Location = new System.Drawing.Point(4, 22);
			this.KeyPage.Name = "KeyPage";
			this.KeyPage.Padding = new System.Windows.Forms.Padding(3);
			this.KeyPage.Size = new System.Drawing.Size(242, 610);
			this.KeyPage.TabIndex = 4;
			this.KeyPage.Text = "Keys";
			this.KeyPage.UseVisualStyleBackColor = true;
			// 
			// ControlTimer
			// 
			this.ControlTimer.Interval = 200;
			this.ControlTimer.Tick += new System.EventHandler(this.ControlTimerTick);
			// 
			// BrushSizeStatusLabel
			// 
			this.BrushSizeStatusLabel.Name = "BrushSizeStatusLabel";
			this.BrushSizeStatusLabel.Size = new System.Drawing.Size(89, 17);
			this.BrushSizeStatusLabel.Text = "Brush Size: 1 x 1";
			// 
			// MapDisplay
			// 
			this.MapDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MapDisplay.Location = new System.Drawing.Point(0, 0);
			this.MapDisplay.Name = "MapDisplay";
			this.MapDisplay.Size = new System.Drawing.Size(754, 636);
			this.MapDisplay.TabIndex = 0;
			this.MapDisplay.Text = "MapDisplay";
			this.MapDisplay.OnInitialize += new System.EventHandler(this.MapDisplayOnInitialize);
			this.MapDisplay.OnDraw += new System.EventHandler(this.MapDisplayOnDraw);
			this.MapDisplay.SizeChanged += new System.EventHandler(this.MapDisplaySizeChanged);
			this.MapDisplay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MapDisplayMouseDown);
			this.MapDisplay.MouseEnter += new System.EventHandler(this.MapDisplayMouseEnter);
			this.MapDisplay.MouseLeave += new System.EventHandler(this.MapDisplayMouseLeave);
			this.MapDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MapDisplayMouseMove);
			this.MapDisplay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MapDisplayMouseUp);
			// 
			// GridColorMenuItem
			// 
			this.GridColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BlackGridMenuItem,
            this.BlueGridMenuItem,
            this.RedGridMenuItem,
            this.GreenGridMenuItem,
            this.YellowGridMenuItem,
            this.WhiteGridMenuItem});
			this.GridColorMenuItem.Name = "GridColorMenuItem";
			this.GridColorMenuItem.Size = new System.Drawing.Size(152, 22);
			this.GridColorMenuItem.Text = "&Grid Color";
			// 
			// BlackGridMenuItem
			// 
			this.BlackGridMenuItem.Name = "BlackGridMenuItem";
			this.BlackGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.BlackGridMenuItem.Text = "&Black";
			this.BlackGridMenuItem.Click += new System.EventHandler(this.BlackGridMenuItemClick);
			// 
			// BlueGridMenuItem
			// 
			this.BlueGridMenuItem.Name = "BlueGridMenuItem";
			this.BlueGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.BlueGridMenuItem.Text = "B&lue";
			this.BlueGridMenuItem.Click += new System.EventHandler(this.BlueGridMenuItemClick);
			// 
			// RedGridMenuItem
			// 
			this.RedGridMenuItem.Name = "RedGridMenuItem";
			this.RedGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.RedGridMenuItem.Text = "&Red";
			this.RedGridMenuItem.Click += new System.EventHandler(this.RedGridMenuItemClick);
			// 
			// GreenGridMenuItem
			// 
			this.GreenGridMenuItem.Name = "GreenGridMenuItem";
			this.GreenGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.GreenGridMenuItem.Text = "&Green";
			this.GreenGridMenuItem.Click += new System.EventHandler(this.GreenGridMenuItemClick);
			// 
			// YellowGridMenuItem
			// 
			this.YellowGridMenuItem.Name = "YellowGridMenuItem";
			this.YellowGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.YellowGridMenuItem.Text = "&Yellow";
			this.YellowGridMenuItem.Click += new System.EventHandler(this.YellowGridMenuItemClick);
			// 
			// WhiteGridMenuItem
			// 
			this.WhiteGridMenuItem.Checked = true;
			this.WhiteGridMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.WhiteGridMenuItem.Name = "WhiteGridMenuItem";
			this.WhiteGridMenuItem.Size = new System.Drawing.Size(152, 22);
			this.WhiteGridMenuItem.Text = "&White";
			this.WhiteGridMenuItem.Click += new System.EventHandler(this.WhiteGridMenuItemClick);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 682);
			this.Controls.Add(this.MapContainer);
			this.Controls.Add(this.StatusBar);
			this.Controls.Add(this.MenuBar);
			this.MainMenuStrip = this.MenuBar;
			this.MinimumSize = new System.Drawing.Size(800, 640);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "FormMain";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainFormClosing);
			this.Load += new System.EventHandler(this.FormMainLoad);
			this.Resize += new System.EventHandler(this.FormMainResize);
			this.MenuBar.ResumeLayout(false);
			this.MenuBar.PerformLayout();
			this.StatusBar.ResumeLayout(false);
			this.StatusBar.PerformLayout();
			this.MapContainer.Panel1.ResumeLayout(false);
			this.MapContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.MapContainer)).EndInit();
			this.MapContainer.ResumeLayout(false);
			this.MapTabs.ResumeLayout(false);
			this.TilePage.ResumeLayout(false);
			this.TilePage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TilesetPreview)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CurrentTileBox)).EndInit();
			this.DrawModeGroup.ResumeLayout(false);
			this.DrawModeGroup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TilePreview)).EndInit();
			this.LayerTab.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MenuBar;
		private System.Windows.Forms.ToolStripMenuItem LevelMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewLevelMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenLevelMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveLevelMenuItem;
		private System.Windows.Forms.ToolStripSeparator LevelMenuSplit;
		private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TilesetMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewTilesetMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenTilesetMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveTilesetMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RemoveTilesetMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LayerMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewLayerMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenLayerMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SaveLayerMenuItem;
		private System.Windows.Forms.ToolStripMenuItem CharactersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContainersMenuItem;
		private System.Windows.Forms.ToolStripMenuItem KeysMenuItem;
		private System.Windows.Forms.StatusStrip StatusBar;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.SplitContainer MapContainer;
		private MapDisplay MapDisplay;
		private System.Windows.Forms.TabControl MapTabs;
		private System.Windows.Forms.TabPage TilePage;
		private System.Windows.Forms.TabPage LayerTab;
		private System.Windows.Forms.TabPage CharacterPage;
		private System.Windows.Forms.TabPage ContainerPage;
		private System.Windows.Forms.TabPage KeyPage;
		private System.Windows.Forms.NumericUpDown CurrentTileBox;
		private System.Windows.Forms.GroupBox DrawModeGroup;
		private System.Windows.Forms.RadioButton EraseButton;
		private System.Windows.Forms.RadioButton DrawButton;
		private System.Windows.Forms.PictureBox TilePreview;
		private System.Windows.Forms.Label TileLabel;
		private System.Windows.Forms.ListBox TilesetList;
		private System.Windows.Forms.Label TilesetsLabel;
		private System.Windows.Forms.PictureBox TilesetPreview;
		private System.Windows.Forms.Label CurrentTilesetLabel;
		private System.Windows.Forms.CheckedListBox LayerList;
		private System.Windows.Forms.Label TileIndexLabel;
		private System.Windows.Forms.Timer ControlTimer;
		private System.Windows.Forms.ToolStripStatusLabel MapLocationLabel;
		private System.Windows.Forms.ToolStripMenuItem ViewMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DisplayGridMenuItem;
		private System.Windows.Forms.Label BrushSizeLabel;
		private System.Windows.Forms.ComboBox BrushSizeBox;
		private System.Windows.Forms.ToolStripStatusLabel BrushSizeStatusLabel;
		private System.Windows.Forms.ToolStripMenuItem GridColorMenuItem;
		private System.Windows.Forms.ToolStripMenuItem BlackGridMenuItem;
		private System.Windows.Forms.ToolStripMenuItem BlueGridMenuItem;
		private System.Windows.Forms.ToolStripMenuItem RedGridMenuItem;
		private System.Windows.Forms.ToolStripMenuItem GreenGridMenuItem;
		private System.Windows.Forms.ToolStripMenuItem YellowGridMenuItem;
		private System.Windows.Forms.ToolStripMenuItem WhiteGridMenuItem;
	}
}