using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using F16Gaming.Game.RPGLibrary.Engine.Mapping;

namespace F16Gaming.Game.RPGLibrary.Engine
{
	public class TextManager
	{
		private readonly log4net.ILog _log;
		private readonly List<Text> _texts;

		private Text _activeText;

		public TextManager(Map map)
		{
			_log = Logging.LogManager.GetLogger(this);
			_log.Info("TextManager is loading map text entries...");
			_texts = new List<Text>();
			_activeText = null;

			if (!map.HasLayer("text"))
			{
				_log.Info("No text layer detected on map, aborting...");
				return;
			}

			foreach (var obj in map.FindObjects((l, o) => l.Name == "text"))
			{
				string title = obj.Properties.ContainsKey("title") ? obj.Properties["title"] : "<No Title>";

				string subtitle = obj.Properties.ContainsKey("subtitle") ? obj.Properties["subtitle"] : null;

				_log.DebugFormat("Adding new text {0} of type {1}", obj.Name, obj.Type);
				_texts.Add(new Text(obj.Bounds, obj.Name, obj.Type, title, subtitle));
			}

			_log.Debug("TextManager initialized!");
		}

		public Text GetIntersecting(Rectangle rect)
		{
			return _texts.FirstOrDefault(t => t.Intersects(rect));
		}

		private IEnumerable<Text> GetAllIntersecting(Rectangle rect)
		{
			return _texts.Where(t => t.Intersects(rect));
		}

		public Text GetActive()
		{
			return _activeText;
		}

		public void Update(GameTime gameTime, Rectangle playerRect)
		{
			Text intersecting = GetIntersecting(playerRect);

			if (intersecting == null || (_activeText != null && !_activeText.Intersects(playerRect)))
				foreach (var text in _texts.Where(t => t.Active))
					text.Disable();
			else
				foreach (var text in _texts.Where(t => t.Active && !t.Intersects(playerRect)))
					text.Disable();

			intersecting = null;

			foreach (var text in GetAllIntersecting(playerRect))
			{
				// We want to get the first intersecting text object that the player has not already been inside
				if (!text.Active)
				{
					text.Enable();
					intersecting = text;
				}
			}

			var active = GetActive();
			if (intersecting != null)
			{
				_activeText = intersecting;
				if (active == null || !active.EqualText(intersecting))
				{
					_activeText.Hide();
					_activeText.FadeIn();
				}
				else
				{
					_activeText.Show();
				}
			}

			active = GetActive();

			if (active != null)
				active.Update(gameTime);
		}
	}
}
