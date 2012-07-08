using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Controls
{
	public class PictureBox : Control
	{
		#region Fields

		private Rectangle _sourceRect;
		private Rectangle _destRect;

		#endregion

		#region Properties

		public Texture2D Image { get; set; }

		public Rectangle SourceRectangle
		{
			get { return _sourceRect; }
			set { _sourceRect = value; }
		}

		public Rectangle DestinationRectangle
		{
			get { return _destRect; }
			set { _destRect = value; }
		}

		public override Vector2 Position
		{
			get { return new Vector2(_destRect.X, _destRect.Y); }
			set { SetPosition(value); }
		}

		#endregion

		#region Constructors

		public PictureBox(Texture2D image, int x, int y) : this(image, new Vector2(x, y))
		{ }

		public PictureBox(Texture2D image, Vector2 position) : this(image, new Rectangle((int) position.X, (int) position.Y, image.Width, image.Height))
		{ }

		public PictureBox(Texture2D image, Rectangle destination) : this(image, destination, new Rectangle(0, 0, image.Width, image.Height))
		{ }

		public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
		{
			Image = image;
			DestinationRectangle = destination;
			SourceRectangle = source;
			Color = Color.White;
		}

		#endregion

		#region Abstract Methods

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(Image, _destRect, _sourceRect, Color);
		}

		public override void HandleInput(PlayerIndex playerIndex = PlayerIndex.One)
		{

		}

		#endregion

		#region Methods

		public void SetPosition(Vector2 newPosition)
		{
			ControlPosition = newPosition;
			_destRect = new Rectangle(
				(int) ControlPosition.X,
				(int) ControlPosition.Y,
				_sourceRect.Width,
				_sourceRect.Height);
		}

		#endregion
	}
}
