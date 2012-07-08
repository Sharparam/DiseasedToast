namespace F16Gaming.Game.RPGLibrary.World
{
	public struct Tile
	{
		public int TileIndex;
		public int TilesetIndex;

		public Tile(int tileIndex, int tilesetIndex)
		{
			TileIndex = tileIndex;
			TilesetIndex = tilesetIndex;
		}
	}
}