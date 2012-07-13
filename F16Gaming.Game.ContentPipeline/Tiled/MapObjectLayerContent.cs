using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace F16Gaming.Game.Content.Pipeline.Tiled
{
	[ContentSerializerRuntimeType("DiseasedToast.MapObjectLayer, DiseasedToast")]
	public class MapObjectLayerContent : LayerContent
	{
		public readonly List<MapObjectContent> Objects = new List<MapObjectContent>();
		public Color Color = Color.White;
	}
}
