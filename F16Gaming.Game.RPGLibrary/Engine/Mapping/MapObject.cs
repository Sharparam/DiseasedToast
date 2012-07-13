using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.Engine.Mapping
{
	public class MapObject
	{
		public string Name { get; private set; }
		public string Type { get; private set; }
		public MapObjectType ObjectType { get; private set; }
		public Rectangle Bounds { get; private set; }
		public int GID { get; private set; }
		public List<Vector2> Points { get; private set; }
		public Dictionary<string, string> Properties { get; private set; }

		public MapObject(string name, string type, MapObjectType objectType, Rectangle bounds, int gid, IEnumerable<Vector2> points, IEnumerable<KeyValuePair<string, string>> properties)
		{
			Name = name;
			Type = type;
			ObjectType = objectType;
			Bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
			GID = gid;

			Points = new List<Vector2>();
			foreach (var point in points)
				Points.Add(new Vector2(point.X, point.Y));

			Properties = new Dictionary<string, string>();
			foreach (var property in properties)
				Properties.Add(property.Key, property.Value);
		}
	}
}
