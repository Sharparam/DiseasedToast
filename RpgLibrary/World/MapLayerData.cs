namespace RpgLibrary.World
{
	public class MapLayerData
	{
		public string Name;
		public int Width;
		public int Height;
		public Tile[] Layer;

		private MapLayerData()
		{ }

		public MapLayerData(string name, int width, int height, int tileIndex = -1, int tileset = -1)
		{
			Name = name;
			Width = width;
			Height = height;
			Layer = new Tile[Height * Width];

			var tile = new Tile(tileIndex, tileset);

			for (int y = 0; y < height; y++)
				for (int x = 0; x < width; x++)
					SetTile(x, y, tile);
		}

		public void SetTile(int x, int y, Tile tile)
		{
			Layer[y * Width + x] = tile;
		}

		public void SetTile(int x, int y, int tileIndex, int tileset)
		{
			SetTile(x, y, new Tile(tileIndex, tileset));
		}

		public Tile GetTile(int x, int y)
		{
			return Layer[y * Width + x];
		}
	}
}
