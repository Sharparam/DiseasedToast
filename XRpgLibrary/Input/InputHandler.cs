using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Nuclex.Input;

namespace XRpgLibrary.Input
{
	public class InputHandler : GameComponent
	{
		#region Fields

		private readonly InputManager _inputManager;
		private static GamePadState[] _diStates;
		private static GamePadState[] _lastDiStates;

		#endregion

		#region Keyboard Fields

		private static KeyboardState _keyboardState;
		private static KeyboardState _lastKeyboardState;

		#endregion

		#region Game Pad Fields

		private static GamePadState[] _gamePadStates;
		private static GamePadState[] _lastGamePadStates;

		#endregion

		#region Mouse Fields

		private static MouseState _mouseState;
		private static MouseState _lastMouseState;

		#endregion

		#region Keyboard Properties

		public static KeyboardState KeyboardState
		{
			get { return _keyboardState; }
		}

		public static KeyboardState LastKeyboardState
		{
			get { return _lastKeyboardState; }
		}

		#endregion

		#region Game Pad Properties

		public static GamePadState[] GamePadStates
		{
			get { return _gamePadStates; }
		}

		public static GamePadState[] LastGamePadStates
		{
			get { return _lastGamePadStates; }
		}

		#endregion

		#region Mouse Properties

		public static MouseState MouseState
		{
			get { return _mouseState; }
		}

		#endregion

		#region Constructors

		public InputHandler(Game game) : base(game)
		{
			_inputManager = new InputManager(game.Services);

			_keyboardState = Keyboard.GetState();

			_gamePadStates = new GamePadState[Enum.GetValues(typeof(PlayerIndex)).Length];
			_diStates = new GamePadState[Enum.GetValues(typeof(ExtendedPlayerIndex)).Length];

			foreach (PlayerIndex index in Enum.GetValues(typeof(PlayerIndex)))
				_gamePadStates[(int) index] = GamePad.GetState(index);

			foreach (ExtendedPlayerIndex index in Enum.GetValues(typeof(ExtendedPlayerIndex)))
				_diStates[(int) index] = _inputManager.GetGamePad(index).GetState();

			_mouseState = Mouse.GetState();
		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();
		}

		public override void Update(GameTime gameTime)
		{
			_inputManager.Update();

			_lastKeyboardState = _keyboardState;
			_keyboardState = Keyboard.GetState();


			_lastGamePadStates = (GamePadState[]) _gamePadStates.Clone();
			foreach (PlayerIndex index in Enum.GetValues(typeof (PlayerIndex)))
				_gamePadStates[(int) index] = GamePad.GetState(index);

			_lastDiStates = (GamePadState[]) _diStates.Clone();
			foreach (ExtendedPlayerIndex index in Enum.GetValues(typeof(ExtendedPlayerIndex)))
				_diStates[(int) index] = _inputManager.GetGamePad(index).GetState();

			_lastMouseState = _mouseState;
			_mouseState = Mouse.GetState();

			base.Update(gameTime);
		}

		#endregion

		#region Methods

		public static void Flush()
		{
			_lastKeyboardState = _keyboardState;
			_lastGamePadStates = _gamePadStates;
			_lastDiStates = _diStates;
			_lastMouseState = _mouseState;
		}

		#endregion

		#region Keyboard Methods

		public static bool KeyReleased(Keys key)
		{
			return _keyboardState.IsKeyUp(key) && _lastKeyboardState.IsKeyDown(key);
		}

		public static bool KeyPressed(Keys key)
		{
			return _keyboardState.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key);
		}

		public static bool KeyDown(Keys key)
		{
			return _keyboardState.IsKeyDown(key);
		}

		#endregion

		#region Game Pad Methods

		public static bool ButtonReleased(Buttons button, PlayerIndex index = PlayerIndex.One)
		{
			bool xboxGamePad = _gamePadStates[(int) index].IsButtonUp(button) &&
			                   _lastGamePadStates[(int) index].IsButtonDown(button);
			bool diGamePad = _diStates[(int) ExtendedPlayerIndex.Five + (int) index].IsButtonUp(button) &&
			                 _lastDiStates[(int) ExtendedPlayerIndex.Five + (int) index].IsButtonDown(button);
			return xboxGamePad || diGamePad;
		}

		public static bool ButtonPressed(Buttons button, PlayerIndex index = PlayerIndex.One)
		{
			bool xboxGamePad = _gamePadStates[(int) index].IsButtonDown(button) &&
			                   _lastGamePadStates[(int) index].IsButtonUp(button);
			bool diGamePad = _diStates[(int) ExtendedPlayerIndex.Five + (int) index].IsButtonDown(button) &&
			                 _lastDiStates[(int) ExtendedPlayerIndex.Five + (int) index].IsButtonUp(button);
			return xboxGamePad || diGamePad;
		}

		public static bool ButtonDown(Buttons button, PlayerIndex index = PlayerIndex.One)
		{
			bool xboxGamePad = _gamePadStates[(int) index].IsButtonDown(button);
			bool diGamePad = _diStates[(int) ExtendedPlayerIndex.Five + (int) index].IsButtonDown(button);
			return xboxGamePad || diGamePad;
		}

		#endregion

		#region Mouse Methods

		public static bool MouseReleased(MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.Left:
					return _mouseState.LeftButton == ButtonState.Released && _lastMouseState.LeftButton == ButtonState.Pressed;
				case MouseButtons.Middle:
					return _mouseState.MiddleButton == ButtonState.Released && _lastMouseState.MiddleButton == ButtonState.Pressed;
				case MouseButtons.Right:
					return _mouseState.RightButton == ButtonState.Released && _lastMouseState.RightButton == ButtonState.Pressed;
				default:
					return false;
			}
		}

		public static bool MousePressed(MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.Left:
					return _mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
				case MouseButtons.Middle:
					return _mouseState.MiddleButton == ButtonState.Pressed && _lastMouseState.MiddleButton == ButtonState.Released;
				case MouseButtons.Right:
					return _mouseState.RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released;
				default:
					return false;
			}
		}

		public static bool MouseDown(MouseButtons button)
		{
			switch (button)
			{
				case MouseButtons.Left:
					return _mouseState.LeftButton == ButtonState.Pressed;
				case MouseButtons.Middle:
					return _mouseState.MiddleButton == ButtonState.Pressed;
				case MouseButtons.Right:
					return _mouseState.RightButton == ButtonState.Pressed;
				default:
					return false;
			}
		}

		#endregion
	}
}
