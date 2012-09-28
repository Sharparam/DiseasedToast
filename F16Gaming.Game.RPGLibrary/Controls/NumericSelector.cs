using System;
using F16Gaming.Game.RPGLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Controls
{
	public class NumericSelector : Control
	{
		#region Events

		public event EventHandler SelectionChanged;

		#endregion

		#region Fields

		private int _width;
		private int _current;
		private int _minValue;
		private int _maxValue;
		private int _increment;

		private Texture2D _leftTexture;
		private Texture2D _rightTexture;
		private Texture2D _stopTexture;

		private Color _selectedColor = Color.Red;

		#endregion

		#region Properties

		public int Width
		{
			get { return _width; }
			set { _width = value; }
		}

		public int MinimumValue
		{
			get { return _minValue; }
			set { _minValue = value > _maxValue ? _maxValue : value; }
		}

		public int MaximumValue
		{
			get { return _maxValue; }
			set { _maxValue = value < _minValue ? _minValue : value; }
		}

		public int CurrentValue
		{
			get { return _current; }
			set
			{
				if (value < _minValue)
					_current = _minValue;
				else if (value > _maxValue)
					_current = _maxValue;
				else
					_current = value;
			}
		}

		public int Increment
		{
			get { return _increment; }
			set { _increment = value; }
		}

		public Color SelectedColor
		{
			get { return _selectedColor; }
			set { _selectedColor = value; }
		}

		#endregion

		#region Constructors
		
		public NumericSelector(
			Texture2D left,
			Texture2D right,
			Texture2D stop,
			int min = 0,
			int max = 100,
			int inc = 1,
			int width = 50,
			Color? color = null,
			Color? selected = null)
		{
			if (color == null)
				color = Color.White;
			if (selected == null)
				selected = Color.Red;

			_leftTexture = left;
			_rightTexture = right;
			_stopTexture = stop;
			_minValue = min;
			MaximumValue = max; // Use property to make sure valid number is set.
			_increment = inc;
			_width = width;
			Color = (Color) color;
			_selectedColor = (Color) selected;
		}

		#endregion

		#region Abstract and Virtual Methods

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(SpriteBatch spriteBatch, float opacity = 1.0f)
		{
			Vector2 drawTo = ControlPosition;

			spriteBatch.Draw(_current != _minValue ? _leftTexture : _stopTexture, drawTo, Color.White);

			drawTo.X += _leftTexture.Width + 5.0f;
			string currentValue = _current.ToString();
			float itemWidth = Font.MeasureString(currentValue).X;
			float offset = (Width - itemWidth) / 2;
			drawTo.X += offset;

			spriteBatch.DrawString(Font, currentValue, drawTo, ControlFocus ? _selectedColor : Color);

			drawTo.X += -1 * offset + _width + 5.0f;

			spriteBatch.Draw(_current != _maxValue ? _rightTexture : _stopTexture, drawTo, Color.White);
		}

		public override void HandleInput(PlayerIndex playerIndex = PlayerIndex.One)
		{
			if (InputHandler.KeyReleased(Keys.Left) ||
				InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
				InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex))
			{
				CurrentValue -= _increment;
			}
			else if (InputHandler.KeyReleased(Keys.Right) ||
				InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
				InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex))
			{
				CurrentValue += _increment;
			}
		}

		protected virtual void OnSelectionChanged(EventArgs e = null)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}

		#endregion
	}
}
