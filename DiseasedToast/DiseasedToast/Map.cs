using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using F16Gaming.Game.RPGLibrary.Engine.Mapping;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiseasedToast
{

// ReSharper disable UnassignedField.Global
// ReSharper disable ConvertToConstant.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable ClassNeverInstantiated.Global

	public class Tile
	{
		public Texture2D Texture;
		public Rectangle SourceRectangle;
		public SpriteEffects SpriteEffects;
	}

	public class Layer
	{
		public string Name;
		public string Type;
		public int Width;
		public int Height;
		public float Opacity = 1.0f;
		public bool Visible = true;
		public Dictionary<string, string> Properties = new Dictionary<string, string>();
	}

	public class TileLayer : Layer
	{
		public Tile[] Tiles;
	}

	public class MapObjectLayer : Layer
	{
		public List<MapObject> Objects = new List<MapObject>();
		public Color Color = Color.White;
	}

	public class MapObject
	{
		public byte ObjectType;
		public string Name = string.Empty;
		public string Type = string.Empty;
		public Rectangle Bounds;
		public int GID;
		public List<Vector2> Points = new List<Vector2>();
		public Dictionary<string, string> Properties = new Dictionary<string, string>();
	}

	public class Map
	{
		public string Filename;
		public string Directory;
		public string Version = string.Empty;
		public byte Orientation;
		public int Width;
		public int Height;
		public int TileWidth;
		public int TileHeight;
		public readonly Dictionary<string, string> Properties = new Dictionary<string, string>();

		public readonly List<Layer> Layers = new List<Layer>();

		internal F16Gaming.Game.RPGLibrary.Engine.Mapping.Map Convert()
		{
			//var map = new F16Gaming.Game.RPGLibrary.Engine.Mapping.Map(Filename, Directory, Version, Orientation, Width, Height, TileWidth, TileHeight, Properties, Layers);

			var layers = new List<F16Gaming.Game.RPGLibrary.Engine.Mapping.Layer>();

			for (int layerIndex = 0; layerIndex < Layers.Count; layerIndex++)
			{
				Layer layer = Layers[layerIndex];
				F16Gaming.Game.RPGLibrary.Engine.Mapping.Layer resultLayer;

				string name = layer.Name;
				string type = layer.Type;
				int width = layer.Width;
				int height = layer.Height;
				float opacity = layer.Opacity;
				bool visible = layer.Visible;
				float layerDepth = 1.0f - (F16Gaming.Game.RPGLibrary.Engine.Mapping.Map.LayerDepthSpacing * layerIndex);
				IDictionary<string, string> properties = layer.Properties;

				if (layer.Type == "layer")
				{
					var tlc = layer as TileLayer;
					Debug.Assert(tlc != null, "Layer was of type " + layer.GetType() + " when assumed to be of type TileLayer!");
					var tiles = new F16Gaming.Game.RPGLibrary.Engine.Mapping.Tile[tlc.Tiles.Length];
					for (int i = 0; i < tlc.Tiles.Length; i++)
					{
						if (tlc.Tiles[i] == null)
							tiles[i] = null;
						else
							tiles[i] = new F16Gaming.Game.RPGLibrary.Engine.Mapping.Tile(tlc.Tiles[i].Texture, tlc.Tiles[i].SourceRectangle, tlc.Tiles[i].SpriteEffects);
					}
					resultLayer = new F16Gaming.Game.RPGLibrary.Engine.Mapping.TileLayer(name, type, width, height, opacity, visible, layerDepth, properties, tiles);
				}
				else if (layer.Type == "objectgroup")
				{
					var mol = layer as MapObjectLayer;
					Debug.Assert(mol != null, "Layer was of type " + layer.GetType() + " when assumed to be of type MapObjectLayer!");
					var objects = mol.Objects.Select(
						mapObject =>
						new F16Gaming.Game.RPGLibrary.Engine.Mapping.MapObject(
							mapObject.Name,
							mapObject.Type,
							(MapObjectType) mapObject.ObjectType,
							mapObject.Bounds,
							mapObject.GID,
							mapObject.Points,
							mapObject.Properties
							)
						).ToList();
					resultLayer = new F16Gaming.Game.RPGLibrary.Engine.Mapping.MapObjectLayer(name, type, width, height, opacity, visible, layerDepth, properties, objects, mol.Color);
				}
				else
				{
					throw new Exception("Unsupported layer type: " + layer.Type);
				}

				layers.Add(resultLayer);
			}

			return new F16Gaming.Game.RPGLibrary.Engine.Mapping.Map(Filename, Directory, Version, (Orientation) Orientation, Width, Height,
			                                                        TileWidth, TileHeight, Properties, layers);
		}
	}

// ReSharper restore ClassNeverInstantiated.Global
// ReSharper restore FieldCanBeMadeReadOnly.Global
// ReSharper restore MemberCanBePrivate.Global
// ReSharper restore ConvertToConstant.Global
// ReSharper restore UnassignedField.Global

}
