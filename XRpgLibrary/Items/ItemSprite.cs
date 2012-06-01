using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RpgLibrary.Items;

using XRpgLibrary.Sprites;

namespace XRpgLibrary.Items
{
	public class ItemSprite
	{
		#region Fields
		#endregion Fields

		#region Properties

		public BaseItem Item { get; private set; }
		public BaseSprite Sprite { get; private set; }

		#endregion Properties

		#region Constructors

		public ItemSprite(BaseItem item, BaseSprite sprite)
		{
			Item = item;
			Sprite = sprite;
		}

		#endregion Constructors

		#region Abstract and Virtual Methods

		public virtual void Update(GameTime gameTime)
		{
			Sprite.Update(gameTime);
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Sprite.Draw(gameTime, spriteBatch);
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
