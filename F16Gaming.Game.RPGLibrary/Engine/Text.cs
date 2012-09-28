using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.Engine
{
	public class Text
	{
		public const float FadeMod = 0.05f;
		public const float FadeDelay = 0.01f;

		private readonly Rectangle _bounds;

		private float _opacity;

		public string Name { get; private set; }
		public string Type { get; private set; }
		public string Title { get; private set; }
		public string SubTitle { get; private set; }

		public bool Active;
		public float Mod;
		public float Elapsed;

		public float Opacity
		{
			get { return _opacity; }
			set { _opacity = MathHelper.Clamp(value, 0.0f, 1.0f); }
		}

		public Text(Rectangle bounds, string name, string type, string title, string subtitle = null)
		{
			_bounds = new Rectangle(bounds.X, bounds.Y, bounds.Width, bounds.Height);
			Name = name;
			Type = type;
			Title = title;
			SubTitle = subtitle;
			Active = false;
			Opacity = 0.0f;
			Mod = FadeMod;
			Elapsed = 0.0f;
		}

		public void Update(GameTime gameTime)
		{
			if (!Active || (Mod > 0.0f && Opacity >= 1.0f) || (Mod < 0.0f && Opacity <= 0.0f))
				return;

			Elapsed += (float) gameTime.ElapsedGameTime.TotalSeconds;
			if (Elapsed >= FadeDelay)
			{
				Elapsed -= FadeDelay;
				Opacity += Mod;
			}
		}

		public bool Intersects(Rectangle rect)
		{
			return rect.Intersects(_bounds);
		}
	}
}
