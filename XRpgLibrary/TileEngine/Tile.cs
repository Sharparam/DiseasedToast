namespace XRpgLibrary.TileEngine
{
	public class Tile
	{
		#region Fields

		#endregion

		#region Properties

		public int TileIndex { get; private set; }

		public int Tileset { get; private set; }

		#endregion

		#region Constructors

		public Tile(int tileIndex = -1, int tileset = -1)
		{
			TileIndex = tileIndex;
			Tileset = tileset;
		}

		#endregion
	}
}
