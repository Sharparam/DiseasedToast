using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.Input;

namespace XRpgLibrary.Controls
{
	public class ControlManager : List<Control>
	{
		#region Events

		public event EventHandler FocusChanged;

		private void OnFocusChanged(object sender, EventArgs e = null)
		{
			if (FocusChanged != null)
				FocusChanged(sender, e);
		}

		#endregion

		#region Fields

		private int _selectedControl;
		private static SpriteFont _font;
		private bool _acceptInput = true;

		#endregion

		#region Properties

		public static SpriteFont Font
		{
			get { return _font; }
		}

		public bool AcceptInput
		{
			get { return _acceptInput; }
			set { _acceptInput = value; }
		}

		#endregion

		#region Constructors

		public ControlManager(SpriteFont font)
		{
			_font = font;
		}

		public ControlManager(SpriteFont font, int capacity) : base(capacity)
		{
			_font = font;
		}

		public ControlManager(SpriteFont font, IEnumerable<Control> collection) : base(collection)
		{
			_font = font;
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime, PlayerIndex playerIndex = PlayerIndex.One)
		{
			if (Count <= 0)
				return;

			foreach (Control c in this)
			{
				if (c.Enabled)
					c.Update(gameTime);

				if (c.HasFocus)
					c.HandleInput(playerIndex);
			}

			if (!_acceptInput)
				return;

			if (InputHandler.ButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
				InputHandler.ButtonPressed(Buttons.DPadUp, playerIndex) ||
				InputHandler.KeyPressed(Keys.Up))
				PreviousControl();

			if (InputHandler.ButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
				InputHandler.ButtonPressed(Buttons.DPadDown, playerIndex) ||
				InputHandler.KeyPressed(Keys.Down))
				NextControl();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Control c in this.Where(c => c.Visible))
				c.Draw(spriteBatch);
		}

		public void NextControl()
		{
			MoveControl(1);
		}

		public void PreviousControl()
		{
			MoveControl(-1);
		}

		private void MoveControl(int amount)
		{
			if (Count <= 0 || amount == 0)
				return;

			int currentControl = _selectedControl;
			this[_selectedControl].HasFocus = false;

			do
			{
				_selectedControl += amount;
				if (_selectedControl < 0)
					_selectedControl = Count - 1;
				else if (_selectedControl == Count)
					_selectedControl = 0;

				if (this[_selectedControl].TabStop && this[_selectedControl].Enabled)
				{
					OnFocusChanged(this[_selectedControl]);

					break;
				}
			} while (currentControl != _selectedControl);

			this[_selectedControl].HasFocus = true;
		}

		#endregion
	}
}
