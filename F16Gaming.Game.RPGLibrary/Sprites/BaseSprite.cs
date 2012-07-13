using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Sprites
{
	public class BaseSprite
	{
		#region Fields

		private Rectangle _sourceRectangle;
		private Vector2 _velocity;
		private float _speed = 100.0f;

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
			set { _speed = MathHelper.Clamp(value, 1.0f, 400.0f); }
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
				Position = new Vector2(tile.Value.X * Engine.Engine.TileWidth, tile.Value.Y * Engine.Engine.TileHeight);
		}

		#endregion Constructors

		#region Abstract and Virtual Methods

		public virtual void Update(GameTime gameTime)
		{
			
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch, float depth = 0.0f)
		{
			spriteBatch.Draw(Texture, Position, _sourceRectangle, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, depth);
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
