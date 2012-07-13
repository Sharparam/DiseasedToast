using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Engine.Mapping
{
	public class Tile
	{
		public Texture2D Texture { get; private set; }
		public Rectangle SourceRectangle { get; private set; }
		public SpriteEffects SpriteEffects { get; private set; }

		public Tile(Texture2D texture, Rectangle sourceRect, SpriteEffects effects)
		{
			Texture = texture;
			SourceRectangle = new Rectangle(sourceRect.X, sourceRect.Y, sourceRect.Width, sourceRect.Height);
			SpriteEffects = effects;
		}
	}
}
