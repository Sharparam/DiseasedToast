using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RpgLibrary.World;

namespace XRpgLibrary.TileEngine
{
	public class MapLayer
	{
		#region Fields

		private readonly Tile[,] _map;
		private readonly Random _rand = new Random();

		#endregion

		#region Properties

		public int Width
		{
			get { return _map.GetLength(1); }
		}

		public int Height
		{
			get { return _map.GetLength(0); }
		}

		public Tile this[int x, int y]
		{
			get { return _map[y, x]; }
			set { _map[y, x] = value; }
		}

		#endregion

		#region Constructors

		public MapLayer(Tile[,] map)
		{
			_map = (Tile[,]) map.Clone();
		}

		public MapLayer(int width, int height)
		{
			_map = new Tile[height, width];

			for (int y = 0; y < height; y++)
				for (int x = 0; x < width; x++)
					this[x, y] = new Tile();
		}

		#endregion

		#region Methods

		public static MapLayer FromMapLayerData(MapLayerData data)
		{
			var layer = new MapLayer(data.Width, data.Height);

			for (int y = 0; y < data.Height; y++)
				for (int x = 0; x < data.Width; x++)
				{
					//Console.WriteLine("({0}, {1}): {2}, {3}", x, y, data.GetTile(x, y).TileIndex, data.GetTile(x, y).TileSetIndex);
					layer.SetTile(x, y, data.GetTile(x, y).TileIndex, data.GetTile(x, y).TilesetIndex);
				}

			return layer;
		}

		public void Draw(SpriteBatch spriteBatch, Camera camera, List<Tileset> tilesets)
		{
			Point cameraPoint = Engine.VectorToCell(camera.Position * (1 / camera.Zoom));
			Point viewPoint = Engine.VectorToCell(
				new Vector2((camera.Position.X + camera.Viewport.Width) * (1 / camera.Zoom),
							(camera.Position.Y + camera.Viewport.Height) * (1 / camera.Zoom)));
			var min = new Point();
			var max = new Point();
			min.X = Math.Max(0, cameraPoint.X - 1);
			min.Y = Math.Max(0, cameraPoint.Y - 1);
			max.X = Math.Min(viewPoint.X + 1, Width);
			max.Y = Math.Min(viewPoint.Y + 1, Height);
			var destination = new Rectangle(0, 0, Engine.TileWidth, Engine.TileHeight);
			Tile tile;

			for (int y = min.Y; y < max.Y; y++)
			{
				destination.Y = y * Engine.TileHeight;
				for (int x = min.X; x < max.X; x++)
				{
					tile = GetTile(x, y);
					if (tile.TileIndex == -1 || tile.Tileset == -1)
						continue;

					destination.X = x * Engine.TileWidth;
					spriteBatch.Draw(
						tilesets[tile.Tileset].Texture,
						destination,
						tilesets[tile.Tileset].SourceRectangles[tile.TileIndex],
						Color.White);
				}
			}
		}

		public Tile GetTile(int x, int y)
		{
			return this[x, y];
		}

		public void SetTile(int x, int y, Tile tile)
		{
			this[x, y] = tile;
		}

		public void SetTile(int x, int y, int tileIndex, int tileset = 0)
		{
			SetTile(x, y, new Tile(tileIndex, tileset));
		}

		public void SetRandom(Tile tile)
		{
			int x = _rand.Next(0, _map.GetLength(0));
			int y = _rand.Next(0, _map.GetLength(1));
			this[x, y] = tile;
		}

		public void SetRandom(int tileIndex, int tileset = 0)
		{
			SetRandom(new Tile(tileIndex, tileset));
		}

		#endregion
	}
}
