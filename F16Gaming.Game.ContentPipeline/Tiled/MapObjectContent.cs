using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using TiledLib;

namespace F16Gaming.Game.Content.Pipeline.Tiled
{
	[ContentSerializerRuntimeType("DiseasedToast.MapObject, DiseasedToast")]
	public class MapObjectContent
	{
		public byte ObjectType;

		public string Name = string.Empty;
		public string Type = string.Empty;
		public Rectangle Bounds;
		public int GID;
		public readonly List<Vector2> Points = new List<Vector2>();
		public readonly Dictionary<string, string> Properties = new Dictionary<string, string>();
	}
}
