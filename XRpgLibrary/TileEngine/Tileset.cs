using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.TileEngine
{
	public class Tileset
	{
		#region Fields

		private readonly Rectangle[] _sourceRectangles;

		#endregion

		#region Properties

		public Texture2D Texture { get; private set; }

		public int TileWidth { get; private set; }

		public int TileHeight { get; private set; }

		public int TilesWide { get; private set; }

		public int TilesHigh { get; private set; }

		public Rectangle[] SourceRectangles
		{
			get { return (Rectangle[])_sourceRectangles.Clone(); }
		}

		#endregion

		#region Constructors

		public Tileset(Texture2D image, int tileWidth = 32, int tileHeight = 32) : this(image, image.Width / tileWidth, image.Height / tileHeight, tileWidth, tileHeight)
		{ }

		public Tileset(Texture2D image, int tilesWide, int tilesHigh, int tileWidth, int tileHeight)
		{
			Texture = image;
			TileWidth = tileWidth;
			TileHeight = tileHeight;
			TilesWide = tilesWide;
			TilesHigh = tilesHigh;

			int tiles = TilesWide * TilesHigh;

			_sourceRectangles = new Rectangle[tiles];

			int tile = 0;

			for (int y = 0; y < TilesHigh; y++)
			{
				for (int x = 0; x < TilesWide; x++)
				{
					_sourceRectangles[tile] = new Rectangle(
						x * TileWidth,
						y * TileHeight,
						TileWidth,
						TileHeight);
					tile++;
				}
			}
		}

		#endregion

		#region Methods
		#endregion
	}
}
