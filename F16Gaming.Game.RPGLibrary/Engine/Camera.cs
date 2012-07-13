using F16Gaming.Game.RPGLibrary.Input;
using F16Gaming.Game.RPGLibrary.Sprites;
using Microsoft.Xna.Framework;

namespace F16Gaming.Game.RPGLibrary.Engine
{
	public enum CameraMode { Free, Follow }

	public class Camera
	{
		#region Fields

		private Configuration.Controls _controls;
		private float _speed;
		private float _zoom;
		private Rectangle _viewport;
		private CameraMode _mode;
		private Point _mapSize;

		public Vector2 Position;

		#endregion

		#region Properties

		public float Speed
		{
			get { return _speed; }
			private set { _speed = MathHelper.Clamp(_speed, 1.0f, 16.0f); }
		}
		
		public float Zoom
		{
			get { return _zoom; }
			private set { _zoom = value; }
		}

		public CameraMode Mode
		{
			get { return _mode; }
		}

		public Matrix Transformation
		{
			get { return Matrix.CreateScale(_zoom) * Matrix.CreateTranslation(new Vector3(-Position, 0.0f)); }
		}

		public Rectangle Viewport
		{
			get { return new Rectangle(_viewport.X, _viewport.Y, _viewport.Width, _viewport.Height); }
		}

		#endregion

		#region Constructors

		public Camera(Rectangle viewport, Configuration.Controls controls) : this(viewport, controls, Vector2.Zero)
		{ }

		public Camera(Rectangle viewport, Configuration.Controls controls, Vector2 position, CameraMode mode = CameraMode.Follow)
		{
			_controls = controls;
			Speed = 4.0f;
			_zoom = 1.0f;
			_viewport = viewport;
			Position = position;
			_mode = mode;
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime)
		{
			if (_mode == CameraMode.Follow || _controls == null)
				return;

			Vector2 motion = Vector2.Zero;

			if (InputHandler.KeyDown(_controls.Keyboard["CameraLeft"]) ||
				InputHandler.ButtonDown(_controls.GamePad["CameraLeft"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Right) && InputHandler.MouseState.X + 1 < Viewport.Width / 2))
				motion.X = -Speed;
			else if (InputHandler.KeyDown(_controls.Keyboard["CameraRight"]) ||
				InputHandler.ButtonDown(_controls.GamePad["CameraRight"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Right) && InputHandler.MouseState.X - 1 > Viewport.Width / 2))
				motion.X = Speed;

			if (InputHandler.KeyDown(_controls.Keyboard["CameraUp"]) ||
				InputHandler.ButtonDown(_controls.GamePad["CameraUp"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Right) && InputHandler.MouseState.Y + 1 < Viewport.Height / 2))
				motion.Y = -Speed;
			else if (InputHandler.KeyDown(_controls.Keyboard["CameraDown"]) ||
				InputHandler.ButtonDown(_controls.GamePad["CameraDown"]) ||
				(InputHandler.MouseDown(Nuclex.Input.MouseButtons.Right) && InputHandler.MouseState.Y - 1 > Viewport.Height / 2))
				motion.Y = Speed;

			if (motion == Vector2.Zero)
				return;

			motion.Normalize();
			Position += motion * Speed;
			LockCamera();
		}

		public void LockCamera()
		{
			Position.X = MathHelper.Clamp(Position.X, 0, _mapSize.X * _zoom - _viewport.Width);
			Position.Y = MathHelper.Clamp(Position.Y, 0, _mapSize.Y * _zoom - _viewport.Height);
		}

		public void LockToSprite(AnimatedSprite sprite)
		{
			Position.X = (sprite.Position.X + sprite.Width / 2.0f) * _zoom - (_viewport.Width / 2.0f);
			Position.Y = (sprite.Position.Y + sprite.Height / 2.0f) * _zoom - (_viewport.Height / 2.0f);
			LockCamera();
		}

		public void ToggleCameraMode()
		{
			_mode = _mode == CameraMode.Follow ? CameraMode.Free : CameraMode.Follow;
		}

		public void SetCameraMode(CameraMode mode)
		{
			_mode = mode;
		}

		public void ZoomIn()
		{
			ModZoom(0.25f);
		}

		public void ZoomOut()
		{
			ModZoom(-0.25f);
		}

		private void ModZoom(float amount)
		{
			_zoom += amount;
			if (_zoom < 0.5f)
				_zoom = 0.5f;
			else if (_zoom > 2.5f)
				_zoom = 2.5f;

			Vector2 newPos = Position * _zoom;
			SnapToPosition(newPos);
		}

		private void SnapToPosition(Vector2 position)
		{
			Position.X = position.X - _viewport.Width / 2.0f;
			Position.Y = position.Y - _viewport.Height / 2.0f;
			LockCamera();
		}

		public void SetMapSize(int width, int height)
		{
			_mapSize = new Point(width, height);
		}

		#endregion
	}
}
