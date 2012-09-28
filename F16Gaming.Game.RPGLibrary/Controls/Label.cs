using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Controls
{
	public class Label : Control
	{
		#region Constructors

		public Label()
		{
			TabStop = false;
		}

		#endregion

		#region Abstract Methods

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(SpriteBatch spriteBatch, float opacity = 1.0f)
		{
			if (!Color.A.Equals(opacity))
				Color = new Color(Color.R, Color.G, Color.B, opacity);

			spriteBatch.DrawString(Font, Text, Position, Color);
		}

		public override void HandleInput(PlayerIndex playerIndex = PlayerIndex.One)
		{

		}

		#endregion

		#region Methods

		public void AutoSize()
		{
			Size = Font.MeasureString(Text);
		}

		public void CenterHorizontal(float width, float? yPos = null)
		{
			Position = new Vector2(width / 2 - Font.MeasureString(Text).X / 2, yPos == null ? Position.Y : (float) yPos);
		}

		#endregion
	}
}
