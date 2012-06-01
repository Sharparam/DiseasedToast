using System.Collections.Generic;

namespace RpgLibrary.World
{
	public class MapData
	{
		public string MapName;
		public MapLayerData[] Layers;
		public TilesetData[] Tilesets;

		private MapData()
		{ }

		public MapData(string mapName, List<TilesetData> tilesets, List<MapLayerData> layers)
		{
			MapName = mapName;
			Tilesets = tilesets.ToArray();
			Layers = layers.ToArray();
		}
	}
}
