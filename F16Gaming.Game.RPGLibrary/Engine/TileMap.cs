using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Engine
{
	public class TileMap
	{
		#region Fields

		private List<Tileset> _tilesets;
		private List<MapLayer> _mapLayers;

		private static int _mapWidth;
		private static int _mapHeight;

		#endregion

		#region Properties

		public static int WidthPixels
		{
			get { return _mapWidth * Engine.TileWidth; }
		}

		public static int HeightPixels
		{
			get { return _mapHeight * Engine.TileHeight; }
		}

		#endregion

		#region Constructors

		public TileMap(Tileset tileset, MapLayer layer) : this(new List<Tileset> { tileset }, new List<MapLayer> { layer })
		{ }

		public TileMap(List<Tileset> tilesets, List<MapLayer> layers)
		{
			_tilesets = tilesets;
			_mapLayers = layers;

			_mapWidth = _mapLayers[0].Width;
			_mapHeight = _mapLayers[0].Height;

			for (int i = 1; i < _mapLayers.Count; i++)
				if (_mapWidth != _mapLayers[i].Width || _mapHeight != _mapLayers[i].Height)
					throw new Exception("Map layer size exception");
		}

		#endregion

		#region Methods

		public void Draw(SpriteBatch spriteBatch, Camera camera)
		{
			foreach (var layer in _mapLayers)
				layer.Draw(spriteBatch, camera, _tilesets);
		}

		public void AddLayer(MapLayer layer)
		{
			if (layer.Width != _mapWidth && layer.Height != _mapHeight)
				throw new Exception("Map layer size exception");

			_mapLayers.Add(layer);
		}

		public void AddTileset(Tileset tileset)
		{
			_tilesets.Add(tileset);
		}

		#endregion
	}
}
