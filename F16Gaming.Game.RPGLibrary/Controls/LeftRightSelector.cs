using System;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Controls
{
	public class LeftRightSelector : Control
	{
		#region Events

		public event EventHandler SelectionChanged;

		#endregion

		#region Fields

		private readonly List<string> _items = new List<string>();
		private readonly Texture2D _leftTexture;
		private readonly Texture2D _rightTexture;
		private readonly Texture2D _stopTexture;
		private Color _selectedColor = Color.Red;
		private int _maxItemWidth;
		private int _selectedItem;

		#endregion

		#region Properties

		public Color SelectedColor
		{
			get { return _selectedColor; }
			set { _selectedColor = value; }
		}

		public int SelectedIndex
		{
			get { return _selectedItem; }
			set { _selectedItem = (int) MathHelper.Clamp(value, 0.0f, _items.Count); }
		}

		public string SelectedItem
		{
			get { return _items[_selectedItem]; }
		}

		public List<string> Items
		{
			get { return _items; }
		}

		#endregion

		#region Constructors

		public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
		{
			_leftTexture = leftArrow;
			_rightTexture = rightArrow;
			_stopTexture = stop;
			TabStop = true;
			Color = Color.White;
		}

		#endregion

		#region Abstract Methods

		public override void Update(GameTime gameTime)
		{

		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Vector2 drawTo = ControlPosition;

			spriteBatch.Draw(_selectedItem != 0 ? _leftTexture : _stopTexture, drawTo, Color.White);

			drawTo.X += _leftTexture.Width + 5.0f;

			float itemWidth = Font.MeasureString(_items[_selectedItem]).X;
			float offset = (_maxItemWidth - itemWidth) / 2;

			drawTo.X += offset;

			spriteBatch.DrawString(Font, _items[_selectedItem], drawTo, ControlFocus ? _selectedColor : Color);

			drawTo.X += -1 * offset + _maxItemWidth + 5.0f;

			spriteBatch.Draw(_selectedItem != _items.Count - 1 ? _rightTexture : _stopTexture, drawTo, Color.White);
		}

		public override void HandleInput(PlayerIndex playerIndex)
		{
			if (_items.Count <= 0)
				return;

			if (InputHandler.ButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
				InputHandler.ButtonReleased(Buttons.DPadLeft, playerIndex) ||
				InputHandler.KeyReleased(Keys.Left))
			{
				MoveSelection(-1);
			}

			if (InputHandler.ButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
				InputHandler.ButtonReleased(Buttons.DPadRight, playerIndex) ||
				InputHandler.KeyReleased(Keys.Right))
			{
				MoveSelection(1);
			}
		}

		#endregion

		#region Methods

		private void OnSelectionChanged()
		{
			if (SelectionChanged != null)
				SelectionChanged(this, null);
		}

		public void SetItems(string[] items, int maxWidth)
		{
			_items.Clear();
			foreach (var item in items)
				_items.Add(item);

			_maxItemWidth = maxWidth;
		}

		private void MoveSelection(int amount)
		{
			if (amount == 0)
				return;

			_selectedItem += amount;
			if (_selectedItem < 0)
				_selectedItem = 0;
			else if (_selectedItem >= _items.Count)
				_selectedItem = _items.Count - 1;

			OnSelectionChanged();
		}

		#endregion
	}
}
