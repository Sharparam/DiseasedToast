using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace F16Gaming.Game.Content.Pipeline.Tiled
{
	[ContentSerializerRuntimeType("DiseasedToast.Layer, DiseasedToast")]
	public class LayerContent
	{
		public string Name;
		public string Type;
		public int Width;
		public int Height;
		public float Opacity = 1.0f;
		public bool Visible = true;
		public readonly Dictionary<string, string> Properties = new Dictionary<string, string>();
	}
}
