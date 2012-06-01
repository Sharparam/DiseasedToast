﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary.Input;

namespace XRpgLibrary.Controls
{
	public sealed class LinkLabel : Label
	{
		#region Fields

		#endregion

		#region Properties

		public Color SelectedColor { get; set; }

		#endregion

		#region Constructors

		public LinkLabel()
		{
			SelectedColor = Color.Red;
			TabStop = true;
			ControlFocus = false;
			ControlPosition = Vector2.Zero;
		}

		#endregion

		#region Abstract Methods

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(Font, Text, Position, HasFocus ? SelectedColor : Color);
		}

		public override void HandleInput(PlayerIndex playerIndex = PlayerIndex.One)
		{
			if (!HasFocus)
				return;

			if (InputHandler.KeyReleased(Keys.Enter) ||
				InputHandler.ButtonReleased(Buttons.A, playerIndex))
				OnSelected();
		}

		#endregion

		#region Methods

		#endregion
	}
}
