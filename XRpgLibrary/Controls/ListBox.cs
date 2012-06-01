using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary.Input;

namespace XRpgLibrary.Controls
{
	public class ListBox : Control
	{
		#region Events

		public event EventHandler SelectionChanged;
		public event EventHandler Enter;
		public event EventHandler Leave;

		#endregion

		#region Fields

		private readonly List<string> _items = new List<string>();
		private int _startItem;
		private int _lineCount;
		private readonly Texture2D _image;
		private readonly Texture2D _cursor;
		private Color _selectedColor = Color.Red;
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

		public override bool HasFocus
		{
			get { return ControlFocus; }
			set
			{
				InputHandler.Flush();

				ControlFocus = value;

				if (ControlFocus)
				{
					_selectedItem = _startItem;
					OnEnter();
				}
				else
				{
					_selectedItem = -1;
					OnLeave();
				}
			}
		}

		#endregion

		#region Constructors

		public ListBox(Texture2D background, Texture2D cursor, bool startActive = true)
		{
			ControlFocus = false;
			TabStop = false;
			_image = background;
			_cursor = cursor;
			ControlSize = new Vector2(_image.Width, _image.Height);
			_lineCount = _image.Height / Font.LineSpacing;
			_startItem = 0;
			_selectedItem = startActive ? _startItem : -1;
			Color = Color.Black;
		}

		#endregion

		#region Abstract Methods

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(_image, ControlPosition, Color.White);
			for (int i = 0; i < _lineCount; i++)
			{
				if (_startItem + i >= _items.Count)
					break;

				if (_startItem + i == _selectedItem)
				{
					spriteBatch.DrawString(
						Font,
						_items[_startItem + i],
						new Vector2(ControlPosition.X, ControlPosition.Y + i * Font.LineSpacing),
						_selectedColor);

					spriteBatch.Draw(_cursor, new Vector2(ControlPosition.X - (_cursor.Width + 2), ControlPosition.Y + i * Font.LineSpacing + 5),
					                 Color.White);
				}
				else
				{
					spriteBatch.DrawString(
						Font,
						_items[_startItem + i],
						new Vector2(ControlPosition.X, 2 + ControlPosition.Y + i * Font.LineSpacing),
						Color);
				}
			}
		}

		public override void HandleInput(PlayerIndex playerIndex = PlayerIndex.One)
		{
			if (!HasFocus)
				return;

			if (InputHandler.KeyReleased(Keys.Down) ||
				InputHandler.ButtonReleased(Buttons.LeftThumbstickDown, playerIndex))
			{
				if (_selectedItem < _items.Count - 1)
				{
					_selectedItem++;
					if (_selectedItem >= _startItem + _lineCount)
						_startItem = _selectedItem - _lineCount + 1;

					OnSelectionChanged();
				}
			}
			else if (InputHandler.KeyReleased(Keys.Up) ||
				InputHandler.ButtonReleased(Buttons.LeftThumbstickUp, playerIndex))
			{
				if (_selectedItem > 0)
				{
					_selectedItem--;
					if (_selectedItem < _startItem)
						_startItem = _selectedItem;

					OnSelectionChanged();
				}
			}

			if (InputHandler.KeyReleased(Keys.Enter) ||
				InputHandler.ButtonReleased(Buttons.A, playerIndex))
			{
				Console.WriteLine("ENTER PRESSED IN LISTBOX");
				HasFocus = false;
				OnSelected();
			}
			else if (InputHandler.KeyReleased(Keys.Escape) ||
				InputHandler.ButtonReleased(Buttons.B, playerIndex))
			{
				HasFocus = false;
				OnLeave();
			}
		}

		#endregion

		#region Methods

		protected virtual void OnSelectionChanged(EventArgs e = null)
		{
			if (SelectionChanged != null)
				SelectionChanged(this, e);
		}

		protected virtual void OnEnter(EventArgs e = null)
		{
			if (Enter != null)
				Enter(this, e);
		}

		protected virtual void OnLeave(EventArgs e = null)
		{
			if (Leave != null)
				Leave(this, e);
		}

		#endregion
	}
}
