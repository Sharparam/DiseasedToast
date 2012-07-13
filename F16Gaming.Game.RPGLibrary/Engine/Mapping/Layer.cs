using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Engine.Mapping
{
	public class Layer
	{
		public string Name { get; private set; }
		public string Type { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }
		public float Opacity { get; private set; }
		public bool Visible { get; private set; }
		public float LayerDepth { get; private set; }

		public Dictionary<string, string> Properties { get; private set; } 

		public Layer(string name, string type, int width, int height, float opacity, bool visible, float layerDepth, IEnumerable<KeyValuePair<string, string>> properties)
		{
			Name = name;
			Type = type;
			Width = width;
			Height = height;
			Opacity = opacity;
			Visible = visible;
			LayerDepth = layerDepth;
			
			Properties = new Dictionary<string, string>();
			foreach (var property in properties)
				Properties.Add(property.Key, property.Value);
		}

		public string GetProperty(string key)
		{
			if (Properties.ContainsKey(key))
				return Properties[key];
			
			return null;
		}
	}
}
