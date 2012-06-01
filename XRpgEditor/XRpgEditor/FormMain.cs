using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RpgLibrary.World;
using RpgLibrary.Serializing;

using XRpgLibrary.TileEngine;

using Color = Microsoft.Xna.Framework.Color;
using GDIColor = System.Drawing.Color;
using GDIImage = System.Drawing.Image;
using GDIBitMap = System.Drawing.Bitmap;
using GDIGraphics = System.Drawing.Graphics;
using GDIRectangle = System.Drawing.Rectangle;
using GDIGraphicsUnit = System.Drawing.GraphicsUnit;

namespace XRpgEditor
{
	internal enum BrushSize
	{
		Small = 0,
		Medium = 1,
		Large = 2,
		Huge = 3
	}

	public partial class FormMain : Form
	{
		#region Fields

		private const string MapLocationFormat = "Location: ({0}, {1})";
		private const string BrushSizeFormat = "Brush Size: {0} x {0}";
		private const int MapUpdateInterval = 17;

		private const string ContentFolder = "Content";
		private static string CursorFile { get { return Path.Combine(ContentFolder, "cursor.png"); } }
		private static string GridFile { get { return Path.Combine(ContentFolder, "grid.png"); } }

		private SpriteBatch _spriteBatch;
		private LevelData _levelData;
		private TileMap _map;
		private readonly List<Tileset> _tilesets = new List<Tileset>();
		private readonly List<TilesetData> _tilesetData = new List<TilesetData>(); 
		private readonly List<MapLayer> _layers = new List<MapLayer>();
		private readonly List<GDIImage> _tilesetImages = new List<GDIImage>();
		private Camera _camera;
		private Engine _engine;
		private Point _mouse;
		private bool _isMouseDown;
		private bool _trackMouse;
		private Texture2D _cursor;
		private Texture2D _grid;
		private Texture2D _shadow;
		private Vector2 _shadowPosition = Vector2.Zero;
		private Color _gridColor = Color.White;
		private int _frameCount;
		private int _brushSize = 1;

		#endregion

		#region Properties

		public GraphicsDevice GraphicsDevice
		{
			get { return MapDisplay.GraphicsDevice; }
		}

		#endregion

		#region Constructors

		public FormMain()
		{
			InitializeComponent();
		}

		#endregion

		#region Event Handlers

		private void FormMainLoad(object sender, EventArgs e)
		{
			var viewPort = new Rectangle(0, 0, MapDisplay.Width, MapDisplay.Height);
			_camera = new Camera(viewPort);
			_engine = new Engine(32, 32);

			ControlTimer.Interval = MapUpdateInterval;
			ControlTimer.Enabled = true;

			BrushSizeBox.SelectedIndex = 0;
		}

		private void FormMainResize(object sender, EventArgs e)
		{
			if (ActiveForm == null)
				return;

			MapContainer.IsSplitterFixed = ActiveForm.WindowState == FormWindowState.Normal;
		}

		private void FormMainFormClosing(object sender, FormClosingEventArgs e)
		{

		}

		private void MapContainerResize(object sender, EventArgs e)
		{
			if (MapContainer.Width <= 250)
				return;

			MapContainer.SplitterDistance = MapContainer.Width - 250;
		}

		private void TilesetListSelectedIndexChanged(object sender, EventArgs e)
		{
			if (TilesetList.SelectedItem == null)
				return;

			CurrentTileBox.Value = 0;
			CurrentTileBox.Maximum = _tilesets[TilesetList.SelectedIndex].SourceRectangles.Length - 1;
			FillPreviews();
		}

		private void CurrentTileBoxValueChanged(object sender, EventArgs e)
		{
			if (TilesetList.SelectedItem == null)
				return;

			FillPreviews();
		}

		private void ControlTimerTick(object sender, EventArgs e)
		{
			_frameCount = ++_frameCount % 6;
			MapDisplay.Invalidate();
			Logic();
		}

		private void TilesetPreviewMouseDown(object sender, MouseEventArgs e)
		{
			if (TilesetList.Items.Count == 0 || e.Button != MouseButtons.Left)
				return;

			int index = TilesetList.SelectedIndex;
			float xScale = (float) _tilesetImages[index].Width / TilesetPreview.Width;
			float yScale = (float) _tilesetImages[index].Height / TilesetPreview.Height;

			var previewPoint = new Point(e.X, e.Y);
			var tilesetPoint = new Point((int) (previewPoint.X * xScale), (int) (previewPoint.Y * yScale));
			var tile = new Point(tilesetPoint.X / _tilesets[index].TileWidth, tilesetPoint.Y / _tilesets[index].TileHeight);

			CurrentTileBox.Value = tile.Y * _tilesets[index].TilesWide + tile.X;
		}

		private void BrushSizeBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			switch((BrushSize) BrushSizeBox.SelectedIndex)
			{
				case BrushSize.Small:
					_brushSize = 1;
					break;
				case BrushSize.Medium:
					_brushSize = 2;
					break;
				case BrushSize.Large:
					_brushSize = 4;
					break;
				case BrushSize.Huge:
					_brushSize = 8;
					break;
				default:
					_brushSize = 1;
					break;
			}

			BrushSizeStatusLabel.Text = string.Format(BrushSizeFormat, _brushSize);
		}

		#endregion

		#region Menu Items

		private void NewLevelMenuItemClick(object sender, EventArgs e)
		{
			using (var form = new FormNewLevel())
			{
				form.ShowDialog();
				if (form.OkPressed)
				{
					_levelData = form.LevelData;
					TilesetMenuItem.Enabled = true;
					SaveLevelMenuItem.Enabled = true;

					StatusLabel.Text = "Created new level!";
				}
			}
		}

		private void OpenLevelMenuItemClick(object sender, EventArgs e)
		{
			var fileDialog = new OpenFileDialog
			{
				Filter = "Level files|*.level",
				CheckFileExists = true,
				CheckPathExists = true
			};

			DialogResult result = fileDialog.ShowDialog();

			if (result != DialogResult.OK)
				return;

			string path = Path.GetDirectoryName(fileDialog.FileName);

			LevelData newLevel;
			MapData mapData;

			try
			{
				newLevel = Serializer.Deserialize<LevelData>(fileDialog.FileName);
				mapData = Serializer.Deserialize<MapData>(path + @"\Maps\" + newLevel.MapName + ".map");
			}
			catch (IOException ex)
			{
				MessageBox.Show("Failed to read level data. IOException thrown with message: " + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, "Error Reading Level",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			_tilesetImages.Clear();
			_tilesetData.Clear();
			_tilesets.Clear();
			_layers.Clear();
			TilesetList.Items.Clear();
			LayerList.Items.Clear();

			_levelData = newLevel;

			try
			{
				foreach (var data in mapData.Tilesets)
				{
					_tilesetData.Add(data);
					TilesetList.Items.Add(data.Name);

					var image = GDIImage.FromFile(data.Image);
					_tilesetImages.Add(image);

					using (var stream = new FileStream(data.Image, FileMode.Open, FileAccess.Read))
					{
						var texture = Texture2D.FromStream(GraphicsDevice, stream);
						_tilesets.Add(new Tileset(texture, data.TilesWide, data.TilesHigh, data.TileWidth, data.TileHeight));
					}
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show("Failed to read tileset image. IOException thrown with message: " + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				_tilesetData.Clear();
				TilesetList.Items.Clear();
				_tilesetImages.Clear();
				_tilesets.Clear();
				return;
			}

			foreach (var layer in mapData.Layers)
			{
				LayerList.Items.Add(layer.Name, true);
				_layers.Add(MapLayer.FromMapLayerData(layer));
			}

			TilesetList.SelectedIndex = 0;
			LayerList.SelectedIndex = 0;
			CurrentTileBox.Value = 0;

			_map = new TileMap(_tilesets, _layers);

			TilesetMenuItem.Enabled = true;
			LayerMenuItem.Enabled = true;
			CharactersMenuItem.Enabled = true;
			ContainersMenuItem.Enabled = true;
			KeysMenuItem.Enabled = true;

			StatusLabel.Text = "Loaded " + fileDialog.FileName + "!";
		}

		private void SaveLevelMenuItemClick(object sender, EventArgs e)
		{
			if (_map == null)
				return;

			var mapLayerData = new List<MapLayerData>();

			for (int i = 0; i < LayerList.Items.Count; i++)
			{
				var data = new MapLayerData(LayerList.Items[i].ToString(), _layers[i].Width, _layers[i].Height);

				for (int y = 0; y < _layers[i].Height; y++)
					for (int x = 0; x < _layers[i].Width; x++)
						data.SetTile(x, y, _layers[i].GetTile(x, y).TileIndex, _layers[i].GetTile(x, y).Tileset);

				mapLayerData.Add(data);
			}

			var mapData = new MapData(_levelData.MapName, _tilesetData, mapLayerData);

			var folderDialog = new FolderBrowserDialog
			{
				Description = "Select Game Folder",
				SelectedPath = Application.StartupPath
			};

			DialogResult result = folderDialog.ShowDialog();

			if (result != DialogResult.OK)
				return;

			if (!File.Exists(folderDialog.SelectedPath + @"\Game.xgi"))
			{
				MessageBox.Show("Game.xgi not found, folder is not a valid game folder.", "Game Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			string levelPath = Path.Combine(folderDialog.SelectedPath, @"Levels\");
			string mapPath = Path.Combine(levelPath, @"Maps\");

			if (!Directory.Exists(levelPath))
				Directory.CreateDirectory(levelPath);

			if (!Directory.Exists(mapPath))
				Directory.CreateDirectory(mapPath);

			Serializer.Serialize(_levelData, levelPath + _levelData.LevelName + ".level");
			Serializer.Serialize(mapData, mapPath + mapData.MapName + ".map");

			StatusLabel.Text = "Saved level to game folder: " + folderDialog.SelectedPath;
		}

		private void NewTilesetMenuItemClick(object sender, EventArgs e)
		{
			using (var form = new FormNewTileset())
			{
				form.ShowDialog();

				if (!form.OkPressed)
					return;

				var data = form.TilesetData;

				try
				{
					var image = GDIImage.FromFile(data.Image);
					_tilesetImages.Add(image);
					var stream = new FileStream(data.Image, FileMode.Open, FileAccess.Read);
					var texture = Texture2D.FromStream(GraphicsDevice, stream);
					var tileset = new Tileset(
						texture,
						data.TilesWide,
						data.TilesHigh,
						data.TileWidth,
						data.TileHeight);
					_tilesets.Add(tileset);
					_tilesetData.Add(data);

					if (_map != null)
						_map.AddTileset(tileset);

					stream.Close();
					stream.Dispose();
				}
				catch (IOException ex)
				{
					MessageBox.Show("Error reading tileset image file, IOException thrown with message: " + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace,
					                "Error Reading Tileset Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				TilesetList.Items.Add(data.Name);

				if (TilesetList.SelectedItem == null)
					TilesetList.SelectedIndex = 0;

				LayerMenuItem.Enabled = true;
			}
		}

		private void OpenTilesetMenuItemClick(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Filter = "Tileset Data|*.tdat",
				CheckPathExists = true,
				CheckFileExists = true
			};

			DialogResult result = dialog.ShowDialog();

			if (result != DialogResult.OK)
				return;

			TilesetData data;
			Tileset tileset;
			GDIImage image;

			try
			{
				data = Serializer.Deserialize<TilesetData>(dialog.FileName);

				Texture2D texture;
				using (var stream = new FileStream(data.Image, FileMode.Open, FileAccess.Read))
				{
					texture = Texture2D.FromStream(GraphicsDevice, stream);
					stream.Close();
				}

				image = GDIImage.FromFile(data.Image);

				tileset = new Tileset(texture, data.TilesWide, data.TilesHigh, data.TileWidth, data.TileHeight);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Failed to read tileset data, IOException thrown with message: " + ex.Message, "Error Reading Tileset Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (TilesetList.Items.Cast<object>().Any(t => t.ToString() == data.Name))
			{
				MessageBox.Show("Level already contains a tileset with name: " + data.Name, "Existing Tileset", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			_tilesetData.Add(data);
			_tilesets.Add(tileset);
			TilesetList.Items.Add(data.Name);
			TilesetPreview.Image = image;
			_tilesetImages.Add(image);
			TilesetList.SelectedIndex = TilesetList.Items.Count - 1;
			CurrentTileBox.Value = 0;

			LayerMenuItem.Enabled = true;
		}

		private void SaveTilesetMenuItemClick(object sender, EventArgs e)
		{
			if (_tilesetData.Count <= 0)
				return;

			var dialog = new SaveFileDialog
			{
				Filter = "Tileset Data|*.tdat",
				CheckPathExists = true,
				OverwritePrompt = true,
				ValidateNames = true
			};

			DialogResult result = dialog.ShowDialog();

			if (result != DialogResult.OK)
				return;

			try
			{
				Serializer.Serialize(_tilesetData[TilesetList.SelectedIndex], dialog.FileName);
			}
			catch(IOException ex)
			{
				MessageBox.Show("Failed to save tileset, IOException thrown with message: " + ex.Message, "Error Saving Tileset", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void RemoveTilesetMenuItemClick(object sender, EventArgs e)
		{

		}

		private void NewLayerMenuItemClick(object sender, EventArgs e)
		{
			using (var form = new FormNewLayer(_levelData.MapWidth, _levelData.MapHeight))
			{
				form.ShowDialog();
				if (form.OkPressed)
				{
					var data = form.LayerData;

					if (LayerList.Items.Contains(data.Name))
					{
						MessageBox.Show("Layer with name \"" + data.Name + "\" already exists!", "Exisiting Layer", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					var layer = MapLayer.FromMapLayerData(data);
					LayerList.Items.Add(data.Name, true);
					LayerList.SelectedIndex = LayerList.Items.Count - 1;
					_layers.Add(layer);

					if (_map == null)
						_map = new TileMap(_tilesets, _layers);

					CharactersMenuItem.Enabled = true;
					ContainersMenuItem.Enabled = true;
					KeysMenuItem.Enabled = true;
				}
			}
		}

		private void OpenLayerMenuItemClick(object sender, EventArgs e)
		{
			var dialog = new OpenFileDialog
			{
				Filter = "Map Layer Data|*.mldat",
				CheckPathExists = true,
				CheckFileExists = true
			};

			DialogResult result = dialog.ShowDialog();

			if (result != DialogResult.OK)
				return;

			MapLayerData data;

			try
			{
				data = Serializer.Deserialize<MapLayerData>(dialog.FileName);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Failed to read map layer data, IOException thrown with message: " + ex.Message, "Error Reading Map Layer Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (LayerList.Items.Cast<object>().Any(t => t.ToString() == data.Name))
			{
				MessageBox.Show("Layer already exists: " + data.Name, "Existing Layer", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			LayerList.Items.Add(data.Name, true);
			_layers.Add(MapLayer.FromMapLayerData(data));

			if (_map == null)
				_map = new TileMap(_tilesets, _layers);
		}

		private void SaveLayerMenuItemClick(object sender, EventArgs e)
		{
			if (_layers.Count <= 0)
				return;

			var dialog = new SaveFileDialog
			{
				Filter = "Map Layer Data|*.layer",
				CheckPathExists = true,
				OverwritePrompt = true,
				ValidateNames = true
			};

			DialogResult result = dialog.ShowDialog();

			if (result != DialogResult.OK)
				return;

			int index = LayerList.SelectedIndex;

			var data = new MapLayerData(LayerList.SelectedItem.ToString(), _layers[index].Width, _layers[index].Height);

			for (int y = 0; y < _layers[index].Height; y++)
				for (int x = 0; x < _layers[index].Width; x++)
					data.SetTile(x, y, _layers[index].GetTile(x, y).TileIndex, _layers[LayerList.SelectedIndex].GetTile(x, y).Tileset);

			try
			{
				Serializer.Serialize(data, dialog.FileName);
			}
			catch (IOException ex)
			{
				MessageBox.Show("Failed to save map layer data, IOException thrown with message: " + ex.Message, "Error Saving Map Layer Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void CharactersMenuItemClick(object sender, EventArgs e)
		{

		}

		private void ContainersMenuItemClick(object sender, EventArgs e)
		{

		}

		private void KeysMenuItemClick(object sender, EventArgs e)
		{

		}

		#endregion

		#region Map Display Events

		private void MapDisplayOnInitialize(object sender, EventArgs e)
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			_shadow = new Texture2D(GraphicsDevice, 20, 20, false, SurfaceFormat.Color);

			var data = new Color[_shadow.Width * _shadow.Height];
			var tint = Color.LightSteelBlue;
			tint.A = 25;

			for (int i = 0; i < _shadow.Width * _shadow.Height; i++)
				data[i] = tint;

			_shadow.SetData(data);
			
			try
			{
				using (var stream = new FileStream(CursorFile, FileMode.Open, FileAccess.Read))
				{
					_cursor = Texture2D.FromStream(GraphicsDevice, stream);
					stream.Close();
				}

				using (var stream = new FileStream(GridFile, FileMode.Open, FileAccess.Read))
				{
					_grid = Texture2D.FromStream(GraphicsDevice, stream);
					stream.Close();
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show("Error: Failed to read images (IOException), message: " + ex.Message + "\n\nStack Trace:\n" + ex.StackTrace, "Error Reading Images", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				_grid = null;
				_cursor = null;
			}
		}

		private void MapDisplayOnDraw(object sender, EventArgs e)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			Render();
			Logic();
		}

		private void MapDisplayMouseEnter(object sender, EventArgs e)
		{
			_trackMouse = true;
		}

		private void MapDisplayMouseLeave(object sender, EventArgs e)
		{
			_trackMouse = false;
		}

		private void MapDisplayMouseMove(object sender, MouseEventArgs e)
		{
			_mouse.X = e.X;
			_mouse.Y = e.Y;
		}

		private void MapDisplayMouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				_isMouseDown = true;
		}

		private void MapDisplayMouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				_isMouseDown = false;
		}

		private void MapDisplaySizeChanged(object sender, EventArgs e)
		{
			var viewPort = new Rectangle(0, 0, MapDisplay.Width, MapDisplay.Height);
			Vector2 cameraPosition = _camera.Position;
			_camera = new Camera(viewPort, cameraPosition);
			_camera.LockCamera();
			MapDisplay.Invalidate();
		}

		#endregion

		#region Grid Color Menu Event Handlers

		private void BlackGridMenuItemClick(object sender, EventArgs e)
		{
			_gridColor = Color.Black;
			BlackGridMenuItem.Checked = true;
			BlueGridMenuItem.Checked = false;
			RedGridMenuItem.Checked = false;
			GreenGridMenuItem.Checked = false;
			YellowGridMenuItem.Checked = false;
			WhiteGridMenuItem.Checked = false;
		}

		private void BlueGridMenuItemClick(object sender, EventArgs e)
		{
			_gridColor = Color.Blue;
			BlackGridMenuItem.Checked = false;
			BlueGridMenuItem.Checked = true;
			RedGridMenuItem.Checked = false;
			GreenGridMenuItem.Checked = false;
			YellowGridMenuItem.Checked = false;
			WhiteGridMenuItem.Checked = false;
		}

		private void RedGridMenuItemClick(object sender, EventArgs e)
		{
			_gridColor = Color.Red;
			BlackGridMenuItem.Checked = false;
			BlueGridMenuItem.Checked = false;
			RedGridMenuItem.Checked = true;
			GreenGridMenuItem.Checked = false;
			YellowGridMenuItem.Checked = false;
			WhiteGridMenuItem.Checked = false;
		}

		private void GreenGridMenuItemClick(object sender, EventArgs e)
		{
			_gridColor = Color.Green;
			BlackGridMenuItem.Checked = false;
			BlueGridMenuItem.Checked = false;
			RedGridMenuItem.Checked = false;
			GreenGridMenuItem.Checked = true;
			YellowGridMenuItem.Checked = false;
			WhiteGridMenuItem.Checked = false;
		}

		private void YellowGridMenuItemClick(object sender, EventArgs e)
		{
			_gridColor = Color.Yellow;
			BlackGridMenuItem.Checked = false;
			BlueGridMenuItem.Checked = false;
			RedGridMenuItem.Checked = false;
			GreenGridMenuItem.Checked = false;
			YellowGridMenuItem.Checked = true;
			WhiteGridMenuItem.Checked = false;
		}

		private void WhiteGridMenuItemClick(object sender, EventArgs e)
		{
			_gridColor = Color.White;
			BlackGridMenuItem.Checked = false;
			BlueGridMenuItem.Checked = false;
			RedGridMenuItem.Checked = false;
			GreenGridMenuItem.Checked = false;
			YellowGridMenuItem.Checked = false;
			WhiteGridMenuItem.Checked = true;
		}

		#endregion

		#region Methods

		private void Render()
		{
			for (int i = 0; i < _layers.Count; i++)
			{
				_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.Transformation);
				
				if (LayerList.GetItemChecked(i))
					_layers[i].Draw(_spriteBatch, _camera, _tilesets);

				var dest = new Rectangle(
					(int) _shadowPosition.X * Engine.TileWidth,
					(int) _shadowPosition.Y * Engine.TileHeight,
					_brushSize * Engine.TileWidth,
					_brushSize * Engine.TileHeight);

				Color tint = Color.White;
				tint.A = 1;

				_spriteBatch.Draw(_shadow, dest, tint);

				_spriteBatch.End();
			}

			DrawDisplay();
		}

		private void DrawDisplay()
		{
			if (_map == null)
				return;

			var dest = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
			if (DisplayGridMenuItem.Checked)
			{
				int maxX = MapDisplay.Width / Engine.TileWidth + 1;
				int maxY = MapDisplay.Height / Engine.TileHeight + 1;

				_spriteBatch.Begin();

				for (int y = 0; y < maxY; y++)
				{
					dest.Y = y * Engine.TileHeight;

					for (int x = 0; x < maxX; x++)
					{
						dest.X = x * Engine.TileWidth;
						_spriteBatch.Draw(_grid, dest, _gridColor);
					}
				}

				_spriteBatch.End();
			}

			_spriteBatch.Begin();

			dest.X = _mouse.X;
			dest.Y = _mouse.Y;

			if (DrawButton.Checked)
			{
				_spriteBatch.Draw(_tilesets[TilesetList.SelectedIndex].Texture, dest,
								  _tilesets[TilesetList.SelectedIndex].SourceRectangles[(int) CurrentTileBox.Value],
								  Color.White);
			}

			_spriteBatch.Draw(_cursor, dest, Color.White);

			_spriteBatch.End();
		}

		private void Logic()
		{
			if (_layers.Count == 0 || !_trackMouse)
				return;

			Vector2 position = _camera.Position;

			if (_frameCount == 0)
			{
				if (_mouse.X < Engine.TileWidth)
					position.X -= Engine.TileWidth;
				else if (_mouse.X > MapDisplay.Width - Engine.TileWidth)
					position.X += Engine.TileWidth;
				else if (_mouse.Y < Engine.TileHeight)
					position.Y -= Engine.TileHeight;
				else if (_mouse.Y > MapDisplay.Height - Engine.TileHeight)
					position.Y += Engine.TileHeight;

				_camera.Position = position;
				_camera.LockCamera();
			}

			position.X = _mouse.X + _camera.Position.X;
			position.Y = _mouse.Y + _camera.Position.Y;

			Point tile = Engine.VectorToCell(position);
			_shadowPosition = new Vector2(tile.X, tile.Y);

			if (tile.X > _layers[LayerList.SelectedIndex].Width - 1 || tile.Y > _layers[LayerList.SelectedIndex].Height - 1)
				return;

			MapLocationLabel.Text = string.Format(MapLocationFormat, tile.X, tile.Y);

			if (!_isMouseDown)
				return;

			if (DrawButton.Checked)
				SetTiles(tile, (int) CurrentTileBox.Value, TilesetList.SelectedIndex);
			else if (EraseButton.Checked)
				SetTiles(tile, -1, -1);
		}

		private void SetTiles(Point tile, int tileIndex, int tileset)
		{
			int selected = LayerList.SelectedIndex;

			for (int y = 0; y < _brushSize; y++)
			{
				if (tile.Y + y >= _layers[selected].Height)
					break;

				for (int x = 0; x < _brushSize; x++)
				{
					if (tile.X + x < _layers[selected].Width)
						_layers[selected].SetTile(tile.X + x, tile.Y + y, tileIndex, tileset);
				}
			}
		}

		private void FillPreviews()
		{
			int selected = TilesetList.SelectedIndex;
			var tile = (int) CurrentTileBox.Value;
			var preview = (GDIImage) new GDIBitMap(TilePreview.Width, TilePreview.Height);
			var dest = new GDIRectangle(0, 0, preview.Width, preview.Height);
			var source = new GDIRectangle(
				_tilesets[selected].SourceRectangles[tile].X,
				_tilesets[selected].SourceRectangles[tile].Y,
				_tilesets[selected].SourceRectangles[tile].Width,
				_tilesets[selected].SourceRectangles[tile].Height);
			var g = GDIGraphics.FromImage(preview);
			g.DrawImage(_tilesetImages[selected], dest, source, GDIGraphicsUnit.Pixel);
			TilesetPreview.Image = _tilesetImages[selected];
			TilePreview.Image = preview;
		}

		#endregion
	}
}
