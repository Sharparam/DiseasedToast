using System;

using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.Engine
{
	public class Text : IEquatable<Text>
	{
		private const float FadeDelay = 0.01f;
		private const float FadeMod = 0.05f;

		private readonly log4net.ILog _log;
		private readonly Rectangle _bounds;

		private bool _active;
		private float _elapsed;
		private float _opacity;
		private float _mod;

		public string Name { get; private set; }
		public string Type { get; private set; }
		public string Title { get; private set; }
		public string Subtitle { get; private set; }

		public bool Active { get { return _active; } }

		public float Opacity
		{
			get { return _opacity; }
			private set { _opacity = MathHelper.Clamp(value, 0.0f, 1.0f); }
		}

		public Text(Rectangle bounds, string name, string type, string title, string subtitle = null)
		{
			_log = Logging.LogManager.GetLogger(this);
			_bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
			Name = name;
			Type = type;
			Title = title;
			Subtitle = subtitle;
			FadeIn();
			Hide();
			Disable();
			_elapsed = 0.0f;
			_log.DebugFormat("New text object created: {0} ({1}) Title: \"{2}\", subtitle: \"{3}\"", Name, Type, Title, Subtitle);
		}

		public bool Equals(Text text)
		{
			return Name == text.Name && Type == text.Type;
		}

		public bool EqualText(Text text)
		{
			bool title = Title == text.Title;
			bool sub = Subtitle == text.Subtitle;
			return title && sub;
		}

		public void Update(GameTime gameTime)
		{
			if (!Active || (_mod > 0.0f && Opacity >= 1.0f) || (_mod < 0.0f && Opacity <= 0.0f))
				return;

			_elapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (_elapsed >= FadeDelay)
			{
				_elapsed -= FadeDelay;
				Opacity += _mod;
			}
		}

		public bool Intersects(Rectangle rect)
		{
			return rect.Intersects(_bounds);
		}

		public void Enable()
		{
			_active = true;
			_log.DebugFormat("{0} has been enabled.", Name);
		}

		public void Disable()
		{
			_active = false;
			_log.DebugFormat("{0} has been disabled.", Name);
		}

		public void Show()
		{
			Opacity = 1.0f;
			_log.Debug("Show() called, setting opacity to 1.0");
		}

		public void Hide()
		{
			Opacity = 0.0f;
			_log.Debug("Hide() called, setting opacity to 0.0");
		}

		public void FadeIn()
		{
			_mod = FadeMod;
			_log.Debug("FadeIn() called");
		}

		public void FadeOut()
		{
			_mod = -FadeMod;
			_log.Debug("FadeOut() called");
		}
	}
}
