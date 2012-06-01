using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RpgLibrary.Items;

namespace XRpgLibrary.Items
{
	public class GameItem
	{
		#region Fields

		public Vector2 Position;

		private Texture2D _image;
		private Rectangle? _sourceRectangle;
		private readonly BaseItem _item;
		private Type _type;

		#endregion

		#region Properties

		public Texture2D Image
		{
			get { return _image; }
		}

		public Rectangle? SourceRectangle
		{
			get { return _sourceRectangle; }
			set { _sourceRectangle = value; }
		}

		public BaseItem Item
		{
			get { return _item; }
		}

		public Type Type
		{
			get { return _type; }
		}

		#endregion

		#region Constructors

		public GameItem(BaseItem item, Texture2D image, Rectangle? source = null)
		{
			_item = item;
			_image = image;
			_sourceRectangle = source;
			_type = item.GetType();
		}

		#endregion

		#region Methods

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_image, Position, _sourceRectangle, Color.White);
		}

		#endregion
	}
}
