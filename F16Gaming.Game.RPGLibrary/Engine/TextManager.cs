using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using F16Gaming.Game.RPGLibrary.Engine.Mapping;

namespace F16Gaming.Game.RPGLibrary.Engine
{
	public class TextManager
	{
		private List<Text> Texts;

		public TextManager(Map map)
		{
			var log = F16Gaming.Game.RPGLibrary.Logging.LogManager.GetLogger(this);
			log.Info("TextManager is loading map text entries...");
			Texts = new List<Text>();

			if (!map.HasLayer("text"))
			{
				log.Info("No text layer detected on map, aborting...");
				return;
			}

			foreach (var obj in map.FindObjects((l, o) => l.Name == "text"))
			{
				string title;
				if (obj.Properties.ContainsKey("title"))
					title = obj.Properties["title"];
				else
					title = "<No Title>";

				string subtitle;
				if (obj.Properties.ContainsKey("subtitle"))
					subtitle = obj.Properties["subtitle"];
				else
					subtitle = null;

				log.DebugFormat("Adding new text {0} of type {1}", obj.Name, obj.Type);
				Texts.Add(new Text(obj.Bounds, obj.Name, obj.Type, title, subtitle));
			}
		}

		public Text GetIntersecting(Rectangle rect)
		{
			return Texts.FirstOrDefault(t => t.Intersects(rect));
		}
	}
}
