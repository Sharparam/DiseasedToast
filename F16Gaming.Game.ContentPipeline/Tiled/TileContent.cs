using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;

namespace F16Gaming.Game.Content.Pipeline.Tiled
{
	[ContentSerializerRuntimeType("DiseasedToast.Tile, DiseasedToast")]
	public class TileContent
	{
		public ExternalReference<Texture2DContent> Texture;
		public Rectangle SourceRectangle;
		public SpriteEffects SpriteEffects;
	}
}
