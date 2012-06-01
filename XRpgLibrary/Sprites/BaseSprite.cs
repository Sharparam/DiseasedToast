using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.TileEngine;

namespace XRpgLibrary.Sprites
{
	public class BaseSprite
	{
		#region Fields

		private Rectangle _sourceRectangle;
		private Vector2 _velocity;
		private float _speed = 2.0f;

		protected readonly Texture2D Texture;
		protected Vector2 SpritePosition;

		#endregion Fields

		#region Properties

		public virtual int Width
		{
			get { return _sourceRectangle.Width; }
		}

		public virtual int Height
		{
			get { return _sourceRectangle.Height; }
		}

		public Rectangle Rectangle
		{
			get { return new Rectangle((int) Position.X, (int) Position.Y, Width, Height); }
		}

		public virtual float Speed
		{
			get { return _speed; }
			set { _speed = MathHelper.Clamp(value, 1.0f, 16.0f); }
		}

		public Vector2 Position
		{
			get { return SpritePosition; }
			set { SpritePosition = value; }
		}

		public Vector2 Velocity
		{
			get { return _velocity; }
			set
			{
				_velocity = value;
				if (_velocity != Vector2.Zero)
					_velocity.Normalize();
			}
		}

		#endregion Properties

		#region Constructors

		public BaseSprite(Texture2D texture, Rectangle? sourceRectangle = null)
		{
			Texture = texture;
			_sourceRectangle = sourceRectangle.HasValue ? sourceRectangle.Value : new Rectangle(0, 0, texture.Width, texture.Height);

			Position = Vector2.Zero;
			_velocity = Vector2.Zero;
		}

		public BaseSprite(Texture2D texture, Rectangle? sourceRectangle, Point? tile) : this(texture, sourceRectangle)
		{
			if (tile.HasValue)
				Position = new Vector2(tile.Value.X * Engine.TileWidth, tile.Value.Y * Engine.TileHeight);
		}

		#endregion Constructors

		#region Abstract and Virtual Methods

		public virtual void Update(GameTime gameTime)
		{
			
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Texture, Position, _sourceRectangle, Color.White);
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
