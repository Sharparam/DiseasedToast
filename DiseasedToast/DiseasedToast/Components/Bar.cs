using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DiseasedToast.Components
{
	internal class Bar
	{
		private readonly Vector2 _position;
		private Rectangle _sourceRect;
		private float _fill = 1.0f;
		private readonly Texture2D _barTexture;
		private readonly Texture2D _emptyTexture;

		public Vector2 Position { get { return _position; } }

		internal Bar(Texture2D barTexture, Texture2D emptyTexture, Vector2 position, float fill = 1.0f)
		{
			_barTexture = barTexture;
			_emptyTexture = emptyTexture;
			_position = position;
			_fill = fill;
			_sourceRect = new Rectangle(0, 0, (int) (_barTexture.Width * _fill), _barTexture.Height);
		}

		public void Update(float fill)
		{
			_fill = fill;
			_sourceRect.Width = (int) (_barTexture.Width * _fill);
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Draw(spriteBatch, Vector2.Zero);
		}

		public void Draw(SpriteBatch spriteBatch, Vector2 offset)
		{
			spriteBatch.Draw(_emptyTexture, _position + offset, Color.White);
			spriteBatch.Draw(_barTexture, _position + offset, _sourceRect, Color.White);
		}
	}
}
