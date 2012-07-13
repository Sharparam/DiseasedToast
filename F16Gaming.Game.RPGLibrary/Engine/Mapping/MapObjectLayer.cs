using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.Engine.Mapping
{
	public class MapObjectLayer : Layer
	{
		public List<MapObject> Objects { get; private set; }
		public Color Color { get; private set; }

		public MapObjectLayer(string name, string type, int width, int height, float opacity, bool visible, float layerDepth, IEnumerable<KeyValuePair<string, string>> properties, IList<MapObject> objects, Color color)
			: base(name, type, width, height, opacity, visible, layerDepth, properties)
		{
			Objects = new List<MapObject>();
			foreach (var mapObject in objects)
				Objects.Add(new MapObject(mapObject.Name, mapObject.Type, mapObject.ObjectType, mapObject.Bounds, mapObject.GID,
				                          mapObject.Points, mapObject.Properties));

			Color = color;
		}
	}
}
