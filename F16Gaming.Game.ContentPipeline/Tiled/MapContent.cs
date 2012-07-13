using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;

namespace F16Gaming.Game.Content.Pipeline.Tiled
{
	[ContentSerializerRuntimeType("DiseasedToast.Map, DiseasedToast")]
	public class MapContent
	{
		public string Filename;
		public string Directory;

		public string Version = string.Empty;
		public byte Orientation;
		public int Width;
		public int Height;
		public int TileWidth;
		public int TileHeight;
		public readonly Dictionary<string, string> Properties = new Dictionary<string, string>();

		public readonly List<LayerContent> Layers = new List<LayerContent>();
	}
}
