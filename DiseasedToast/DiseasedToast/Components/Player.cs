using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.Characters;
using XRpgLibrary.Input;
using XRpgLibrary.Sprites;
using XRpgLibrary.TileEngine;

namespace DiseasedToast.Components
{
	public class Player
	{
		#region Fields

		private const int MouseDetectOffset = 25;

		private Camera _camera;
		private readonly MainGame _gameRef;
		private readonly Character _char;
		private TimeSpan _elapsed = TimeSpan.Zero;
		private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(10);

		#endregion

		#region Properties

		public Camera Camera
		{
			get { return _camera; }
			set { _camera = value; }
		}

		public AnimatedSprite Sprite
		{
			get { return _char.Sprite; }
		}

		#endregion

		#region Constructors

		public Player(MainGame game, Character character)
		{
			_gameRef = game;
			_camera = new Camera(_gameRef.ScreenRectangle);
			_char = character;
			
			RpgLibrary.Logging.LogManager.GetLogger(this).Debug("Player object created.");
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime)
		{
			_elapsed += gameTime.ElapsedGameTime;
			_camera.Update(gameTime);
			Sprite.Update(gameTime);

			if (InputHandler.KeyReleased(Keys.PageUp) ||
				InputHandler.ButtonReleased(Buttons.LeftShoulder))
			{
				_camera.ZoomIn();
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}
			else if (InputHandler.KeyReleased(Keys.PageDown) ||
				InputHandler.ButtonReleased(Buttons.RightShoulder))
			{
				_camera.ZoomOut();
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}

			if (_elapsed >= _delay)
			{
				var motion = new Vector2();

				int mouseX = InputHandler.MouseState.X + (int)_camera.Position.X;
				int mouseY = InputHandler.MouseState.Y + (int)_camera.Position.Y;

				if (InputHandler.KeyDown(Keys.W) ||
					InputHandler.ButtonDown(Buttons.LeftThumbstickUp) ||
					(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseY + MouseDetectOffset < Sprite.Position.Y + Sprite.Height / 2.0f))
				{
					Sprite.CurrentAnimation = AnimationKey.North;
					motion.Y = -1;
				}
				else if (InputHandler.KeyDown(Keys.S) ||
					InputHandler.ButtonDown(Buttons.LeftThumbstickDown) ||
					(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseY - MouseDetectOffset > Sprite.Position.Y + Sprite.Height / 2.0f))
				{
					Sprite.CurrentAnimation = AnimationKey.South;
					motion.Y = 1;
				}

				if (InputHandler.KeyDown(Keys.A) ||
					InputHandler.ButtonDown(Buttons.LeftThumbstickLeft) ||
					(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseX + MouseDetectOffset < Sprite.Position.X + Sprite.Width / 2.0f))
				{
					Sprite.CurrentAnimation = AnimationKey.West;
					motion.X = -1;
				}
				else if (InputHandler.KeyDown(Keys.D) ||
					InputHandler.ButtonDown(Buttons.LeftThumbstickRight) ||
					(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseX - MouseDetectOffset > Sprite.Position.X + Sprite.Width / 2.0f))
				{
					Sprite.CurrentAnimation = AnimationKey.East;
					motion.X = 1;
				}

				if (motion != Vector2.Zero)
				{
					Sprite.IsAnimating = true;
					motion.Normalize();
					Sprite.Position += motion * Sprite.Speed;
					Sprite.LockToMap();
					if (_camera.Mode == CameraMode.Follow)
						_camera.LockToSprite(Sprite);
				}
				else
				{
					Sprite.IsAnimating = false;
				}

				_elapsed = TimeSpan.Zero;
			}

			if (InputHandler.KeyReleased(Keys.F) ||
				InputHandler.ButtonReleased(Buttons.RightTrigger) ||
				InputHandler.MouseReleased(Nuclex.Input.MouseButtons.Right))
			{
				_camera.ToggleCameraMode();
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}

			if (_camera.Mode == CameraMode.Follow)
				return;

			if (InputHandler.KeyReleased(Keys.C) ||
			    InputHandler.ButtonReleased(Buttons.LeftTrigger) ||
			    InputHandler.MouseReleased(Nuclex.Input.MouseButtons.Middle))
			{
				_camera.LockToSprite(Sprite);
			}
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			_char.Draw(gameTime, spriteBatch);
		}

		#endregion
	}
}
