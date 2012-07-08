using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.TileEngine
{
	public class Engine
	{
		#region Fields

		private static int _tileWidth;
		private static int _tileHeight;

		#endregion

		#region Properties

		public static int TileWidth
		{
			get { return _tileWidth; }
		}

		public static int TileHeight
		{
			get { return _tileHeight; }
		}

		#endregion

		#region Constructors

		public Engine(int tileWidth, int tileHeight)
		{
			_tileWidth = tileWidth;
			_tileHeight = tileHeight;
		}

		#endregion

		#region Methods

		public static Point VectorToCell(Vector2 position)
		{
			return new Point((int) position.X / _tileWidth, (int) position.Y / _tileHeight);
		}

		#endregion
	}
}
