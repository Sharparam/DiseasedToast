using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Engine.Mapping
{
	public delegate bool MapObjectFinder(MapObjectLayer layer, MapObject mapObj);

	public delegate void DrawMethod(float depth);

	public class Map
	{
		/// <summary>
		/// The difference in layer depth between layers.
		/// </summary>
		/// <remarks>
		/// The algorithm for creating the LayerDepth for each layer when enumerating from
		/// back to front is:
		/// float layerDepth = 1f - (LayerDepthSpacing * i);
		/// </remarks>
		public const float LayerDepthSpacing = 0.001f;

		private readonly List<Layer> _layers;
		private readonly Dictionary<string, string> _properties;

		public string Filename { get; private set; }
		public string Directory { get; private set; }

		public string Version { get; private set; }
		public Orientation Orientation { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public int TileWidth { get; private set; }
		public int TileHeight { get; private set; }

		public int PixelsWide
		{
			get { return Width * TileWidth; }
		}

		public int PixelsHigh
		{
			get { return Height * TileHeight; }
		}

		public Map(string file, string dir, string version, Orientation orientation, int width, int height, int tileWidth, int tileHeight, IEnumerable<KeyValuePair<string, string>> properties, IEnumerable<Layer> layers)
		{
			Filename = file;
			Directory = dir;
			Version = version;
			Orientation = orientation;
			Width = width;
			Height = height;
			TileWidth = tileWidth;
			TileHeight = tileHeight;

			_properties = new Dictionary<string, string>();
			foreach (var property in properties)
				_properties.Add(property.Key, property.Value);

			_layers = new List<Layer>();
			foreach (var layer in layers)
			{
				if (layer is TileLayer)
				{
					var tl = layer as TileLayer;
					_layers.Add(new TileLayer(tl.Name, tl.Type, tl.Width, tl.Height, tl.Opacity, tl.Visible, tl.LayerDepth, tl.Properties, tl.Tiles));
				}
				else if (layer is MapObjectLayer)
				{
					var mol = layer as MapObjectLayer;
					_layers.Add(new MapObjectLayer(mol.Name, mol.Type, mol.Width, mol.Height, mol.Opacity, mol.Visible, mol.LayerDepth, mol.Properties, mol.Objects, mol.Color));
				}
				else
					throw new Exception("Unknown layer type: " + layer.GetType());
			}

			Debug.Assert(HasLayer("player"), "No player layer exists on map!\n\n" + Filename);
		}

		public void Draw(SpriteBatch spriteBatch, Camera camera, DrawMethod playerDraw = null)
		{
			Point cameraPoint = VectorToCell(camera.Position * (1 / camera.Zoom));
			Point viewPoint =
				VectorToCell(new Vector2((camera.Position.X + camera.Viewport.Width) * (1 / camera.Zoom),
										 (camera.Position.Y + camera.Viewport.Height) * (1 / camera.Zoom)));
			var min = new Point
			{
				X = Math.Max(0, cameraPoint.X - 1),
				Y = Math.Max(0, cameraPoint.Y - 1)
			};

			var destination = new Rectangle(0, 0, TileWidth, TileHeight);

			bool playerDrawn = false;

			foreach (var layer in _layers)
			{
				if (playerDraw != null && !playerDrawn && layer.Name == "player")
				{
					playerDraw(layer.LayerDepth);
					playerDrawn = true;
				}

				if (!layer.Visible)
					continue;

				var tileLayer = layer as TileLayer;
				
				if (tileLayer == null)
					continue;

				var max = new Point
				{
					X = Math.Min(viewPoint.X + 1, tileLayer.Width),
					Y = Math.Min(viewPoint.Y + 1, tileLayer.Height)
				};

				var color = new Color(1.0f, 1.0f, 1.0f, tileLayer.Opacity);

				for (int y = min.Y; y < max.Y; y++)
				{
					for (int x = min.X; x < max.X; x++)
					{
						Tile tile = tileLayer.Tiles[y * tileLayer.Width + x];
						
						if (tile == null)
							continue;

						destination.X = x * TileWidth;
						destination.Y = y * TileHeight - tile.SourceRectangle.Height + TileHeight;
						destination.Width = tile.SourceRectangle.Width;
						destination.Height = tile.SourceRectangle.Height;
						spriteBatch.Draw(
							tile.Texture,
							destination,
							tile.SourceRectangle,
							color,
							0.0f,
							Vector2.Zero,
							tile.SpriteEffects,
							layer.LayerDepth
						);
					}
				}
			}
		}

		public bool HasLayer(string name)
		{
			return _layers.Any(l => l.Name == name);
		}

		public Layer GetLayer(string name)
		{
			Layer layer = _layers.FirstOrDefault(l => l.Name == name);
			if (layer == null)
				throw new Exception("GetLayer() -> Layer \"" + name + "\" is NULL!");
			return layer;
		}

		public bool HasProperty(string key)
		{
			return _properties.ContainsKey(key);
		}

		public string GetProperty(string key)
		{
			if (HasProperty(key))
				return _properties[key];

			return null;
		}

		public MapObject FindObject(MapObjectFinder finder)
		{
			return _layers.OfType<MapObjectLayer>().Select(layer => layer.Objects.FirstOrDefault(obj => finder(layer, obj))).FirstOrDefault(mapObject => mapObject != null);
		}

		public IEnumerable<MapObject> FindObjects(MapObjectFinder finder)
		{
			return from layer in _layers.OfType<MapObjectLayer>() from mapObject in layer.Objects where finder(layer, mapObject) select mapObject;
		}

		public bool IsSolid(float x, float y)
		{
			return IsSolid(VectorToCell(new Vector2(x, y)));
		}

		public bool IsSolid(Vector2 position)
		{
			return IsSolid(VectorToCell(position));
		}

		public bool IsSolid(int x, int y)
		{
			return IsSolid(new Point(x, y));
		}

		public bool IsSolid(Point location)
		{
			if (!HasLayer("collision"))
				return false;

			var layer = GetLayer("collision") as TileLayer;

			if (layer == null)
				return false;

			return layer[location.X, location.Y] != null;
		}

		public Point VectorToCell(Vector2 position)
		{
			return new Point((int) position.X / TileWidth, (int) position.Y / TileHeight);
		}
	}
}
