using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Engine.Mapping
{
	public class TileLayer : Layer
	{
		public Tile[] Tiles { get; private set; }

		public Tile this[int x, int y]
		{
			get
			{
				int index = y * Width + x;
				
				if (index + 1 > Tiles.Length)
					return null;

				return Tiles[y * Width + x];
			}
		}

		public TileLayer(string name, string type, int width, int height, float opacity, bool visible, float layerDepth, IDictionary<string, string> properties, Tile[] tiles)
			: base(name, type, width, height, opacity, visible, layerDepth, properties)
		{
			Tiles = new Tile[tiles.Length];
			for (int i = 0; i < tiles.Length; i++)
			{
				if (tiles[i] == null)
					Tiles[i] = null;
				else
					Tiles[i] = new Tile(tiles[i].Texture, tiles[i].SourceRectangle, tiles[i].SpriteEffects);
			}
		}
	}
}
