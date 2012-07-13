using System;
using DiseasedToast.Configuration;
using F16Gaming.Game.RPGLibrary.Characters;
using F16Gaming.Game.RPGLibrary.Engine;
using F16Gaming.Game.RPGLibrary.Input;
using F16Gaming.Game.RPGLibrary.Logging;
using F16Gaming.Game.RPGLibrary.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiseasedToast.Components
{
	public class Player
	{
		#region Fields

		private const int MouseDetectOffset = 25;
		private const float SprintSpeed = 100.0f;
		private const float CollisionOffsetX = 2.0f;
		private const float CollisionOffsetY = 1.0f;

		private Camera _camera;
		private readonly MainGame _gameRef;
		private readonly Character _char;
		private TimeSpan _elapsed = TimeSpan.Zero;
		private readonly TimeSpan _delay = TimeSpan.FromMilliseconds(10);
		private Point _mapSize;

		private bool _sprinting;

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

		public Character Character
		{
			get { return _char; }
		}

		#endregion

		#region Constructors

		public Player(MainGame game, Character character)
		{
			_gameRef = game;
			_camera = new Camera(_gameRef.ScreenRectangle, ControlsManager.Controls);
			_char = character;
			_mapSize = new Point(0, 0);
			_camera.SetMapSize(_mapSize.X, _mapSize.Y);
			
			LogManager.GetLogger(this).Debug("Player object created.");
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime, F16Gaming.Game.RPGLibrary.Engine.Mapping.Map map)
		{
			_camera.Update(gameTime);
			Sprite.Update(gameTime);

			if (InputHandler.KeyReleased(ControlsManager.Controls.Keyboard["ZoomIn"]) ||
				InputHandler.ButtonReleased(ControlsManager.Controls.GamePad["ZoomIn"]))
			{
				_camera.ZoomIn();
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}
			else if (InputHandler.KeyReleased(ControlsManager.Controls.Keyboard["ZoomOut"]) ||
				InputHandler.ButtonReleased(ControlsManager.Controls.GamePad["ZoomOut"]))
			{
				_camera.ZoomOut();
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}

			var motion = new Vector2();

			int mouseX = InputHandler.MouseState.X + (int)_camera.Position.X;
			int mouseY = InputHandler.MouseState.Y + (int)_camera.Position.Y;

			if (InputHandler.KeyDown(ControlsManager.Controls.Keyboard["MoveUp"]) ||
				InputHandler.ButtonDown(ControlsManager.Controls.GamePad["MoveUp"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseY + MouseDetectOffset < Sprite.Position.Y + Sprite.Height / 2.0f))
			{
				Sprite.CurrentAnimation = AnimationKey.North;
				motion.Y = -1;
			}
			else if (InputHandler.KeyDown(ControlsManager.Controls.Keyboard["MoveDown"]) ||
				InputHandler.ButtonDown(ControlsManager.Controls.GamePad["MoveDown"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseY - MouseDetectOffset > Sprite.Position.Y + Sprite.Height / 2.0f))
			{
				Sprite.CurrentAnimation = AnimationKey.South;
				motion.Y = 1;
			}

			if (InputHandler.KeyDown(ControlsManager.Controls.Keyboard["MoveLeft"]) ||
				InputHandler.ButtonDown(ControlsManager.Controls.GamePad["MoveLeft"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseX + MouseDetectOffset < Sprite.Position.X + Sprite.Width / 2.0f))
			{
				Sprite.CurrentAnimation = AnimationKey.West;
				motion.X = -1;
			}
			else if (InputHandler.KeyDown(ControlsManager.Controls.Keyboard["MoveRight"]) ||
				InputHandler.ButtonDown(ControlsManager.Controls.GamePad["MoveRight"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Left) && mouseX - MouseDetectOffset > Sprite.Position.X + Sprite.Width / 2.0f))
			{
				Sprite.CurrentAnimation = AnimationKey.East;
				motion.X = 1;
			}

			if (InputHandler.KeyDown(ControlsManager.Controls.Keyboard["Sprint"]) ||
				InputHandler.ButtonDown(ControlsManager.Controls.GamePad["Sprint"]))
				_sprinting = true;
			else
				_sprinting = false;

			if (motion != Vector2.Zero)
			{
				Sprite.IsAnimating = true;
				motion.Normalize();
				Vector2 newPos = Sprite.Position + (motion * (Sprite.Speed + (_sprinting ? SprintSpeed : 0)) * (float) gameTime.ElapsedGameTime.TotalSeconds);
				if (map.HasLayer("collision"))
				{
					var layer = map.GetLayer("collision") as F16Gaming.Game.RPGLibrary.Engine.Mapping.TileLayer;
					if (layer != null)
					{
						bool collideX = false;
						bool collideY = false;

						if (motion.X < 0)
						{
							// Check top-left corner
							Point tilePoint = map.VectorToCell(new Vector2(newPos.X + CollisionOffsetX, Sprite.Position.Y + CollisionOffsetY));
							collideX = layer[tilePoint.X, tilePoint.Y] != null;

							if (!collideX) // Check bottom-left corner
							{
								tilePoint = map.VectorToCell(new Vector2(newPos.X + CollisionOffsetX, Sprite.Position.Y + Sprite.Height - CollisionOffsetY));
								collideX = layer[tilePoint.X, tilePoint.Y] != null;
							}
						}
						else if (motion.X > 0)
						{
							// Check top-right corner
							Point tilePoint = map.VectorToCell(new Vector2(newPos.X + Sprite.Width - CollisionOffsetX, Sprite.Position.Y + CollisionOffsetY));
							collideX = layer[tilePoint.X, tilePoint.Y] != null;

							if (!collideX) // Check bottom-right corner
							{
								tilePoint = map.VectorToCell(new Vector2(newPos.X + Sprite.Width - CollisionOffsetX, Sprite.Position.Y + Sprite.Height - CollisionOffsetY));
								collideX = layer[tilePoint.X, tilePoint.Y] != null;
							}
						}

						if (motion.Y < 0)
						{
							// Check top-left corner
							Point tilePoint = map.VectorToCell(new Vector2(Sprite.Position.X + CollisionOffsetX, newPos.Y + CollisionOffsetY));
							collideY = layer[tilePoint.X, tilePoint.Y] != null;

							if (!collideY) // Check top-right corner
							{
								tilePoint = map.VectorToCell(new Vector2(Sprite.Position.X + Sprite.Width - CollisionOffsetX, newPos.Y + CollisionOffsetY));
								collideY = layer[tilePoint.X, tilePoint.Y] != null;
							}
						}
						else if (motion.Y > 0)
						{
							// Check bottom-left corner
							Point tilePoint = map.VectorToCell(new Vector2(Sprite.Position.X + CollisionOffsetX, newPos.Y + Sprite.Height - CollisionOffsetY));
							collideY = layer[tilePoint.X, tilePoint.Y] != null;

							if (!collideY) // Check bottom-right corner
							{
								tilePoint = map.VectorToCell(new Vector2(Sprite.Position.X + Sprite.Width - CollisionOffsetX, newPos.Y + Sprite.Height - CollisionOffsetY));
								collideY = layer[tilePoint.X, tilePoint.Y] != null;
							}
						}

						if (collideX)
							newPos.X = Sprite.Position.X;

						if (collideY)
							newPos.Y = Sprite.Position.Y;
					}
				}

				Sprite.Position = new Vector2(newPos.X, newPos.Y);
				Sprite.LockToMap(_mapSize.X, _mapSize.Y);
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}
			else
			{
				Sprite.IsAnimating = false;
			}

			if (InputHandler.KeyReleased(ControlsManager.Controls.Keyboard["ToggleCamera"]) ||
				InputHandler.ButtonReleased(ControlsManager.Controls.GamePad["ToggleCamera"]) ||
				InputHandler.MouseReleased(Nuclex.Input.MouseButtons.Right))
			{
				_camera.ToggleCameraMode();
				if (_camera.Mode == CameraMode.Follow)
					_camera.LockToSprite(Sprite);
			}

			if (_camera.Mode == CameraMode.Follow)
				return;

			if (InputHandler.KeyReleased(ControlsManager.Controls.Keyboard["ResetCamera"]) ||
			    InputHandler.ButtonReleased(ControlsManager.Controls.GamePad["ResetCamera"]) ||
			    InputHandler.MouseReleased(Nuclex.Input.MouseButtons.Middle))
			{
				_camera.LockToSprite(Sprite);
			}
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch, float depth = 0.0f)
		{
			_char.Draw(gameTime, spriteBatch, depth);
		}

		public void SetMapSize(int width, int height)
		{
			_mapSize = new Point(width, height);
			Camera.SetMapSize(width, height);
		}

		#endregion
	}
}
