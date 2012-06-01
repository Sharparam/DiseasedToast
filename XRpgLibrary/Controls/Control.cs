using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.Controls
{
	public abstract class Control
	{
		#region Events

		public event EventHandler Selected;

		#endregion

		#region Fields

		protected Vector2 ControlSize;
		protected Vector2 ControlPosition;
		protected bool ControlFocus;

		#endregion

		#region Properties

		public string Name { get; set; }

		public string Text { get; set; }

		public Vector2 Size
		{
			get { return ControlSize; }
			set { ControlSize = value; }
		}

		public virtual Vector2 Position
		{
			get { return ControlPosition; }
			set
			{
				ControlPosition = value;
				ControlPosition.Y = (int) ControlPosition.Y;
			}
		}

		public object Value { get; set; }

		public virtual bool HasFocus
		{
			get { return ControlFocus; }
			set { ControlFocus = value; }
		}

		public bool Enabled { get; set; }

		public bool Visible { get; set; }

		public bool TabStop { get; set; }

		public SpriteFont Font { get; set; }

		public Color Color { get; set; }

		public string Type { get; set; }

		#endregion

		#region Constructors

		protected Control()
		{
			Color = Color.White;
			Enabled = true;
			Visible = true;
			Font = ControlManager.Font;
		}

		#endregion

		#region Abstract Methods

		public abstract void Update(GameTime gameTime);
		public abstract void Draw(SpriteBatch spriteBatch);
		public abstract void HandleInput(PlayerIndex playerIndex = PlayerIndex.One);

		#endregion

		#region Virtual Methods

		protected virtual void OnSelected(EventArgs e = null)
		{
			if (Selected != null)
				Selected(this, e);
		}

		#endregion
	}
}
