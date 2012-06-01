using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.Items
{
	public class GameItemManager
	{
		#region Fields

		private readonly Dictionary<string, GameItem> _items = new Dictionary<string, GameItem>();

		#endregion

		#region Properties

		public Dictionary<string, GameItem> Items
		{
			get { return _items; }
		}

		public static SpriteFont Font { get; private set; }

		#endregion

		#region Constructors

		public GameItemManager(SpriteFont font)
		{
			Font = font;
		}

		#endregion

		#region Methods
		#endregion
	}
}
