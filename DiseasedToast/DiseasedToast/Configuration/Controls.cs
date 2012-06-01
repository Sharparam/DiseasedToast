using Microsoft.Xna.Framework.Input;

namespace DiseasedToast.Configuration
{
	internal static class Keyboard
	{
		public const Keys MoveForward = Keys.W;
		public const Keys MoveBackwards = Keys.S;
		public const Keys MoveLeft = Keys.A;
		public const Keys MoveRight = Keys.D;

		public const Keys ArrowUp = Keys.Up;
		public const Keys ArrowDown = Keys.Down;
		public const Keys ArrowLeft = Keys.Left;
		public const Keys ArrowRight = Keys.Right;

		public const Keys ZoomIn = Keys.PageUp;
		public const Keys ZoomOut = Keys.PageDown;
		public const Keys ToggleCamera = Keys.F;
		public const Keys ResetCamera = Keys.C;
	}

	internal static class GamePad
	{
		public const Buttons MoveForward = Buttons.LeftThumbstickUp;
		public const Buttons MoveBackwards = Buttons.LeftThumbstickDown;
		public const Buttons MoveLeft = Buttons.LeftThumbstickLeft;
		public const Buttons MoveRight = Buttons.LeftThumbstickRight;

		public const Buttons ArrowUp = Buttons.DPadUp;
		public const Buttons ArrowDown = Buttons.DPadDown;
		public const Buttons ArrowLeft = Buttons.DPadLeft;
		public const Buttons ArrowRight = Buttons.DPadRight;

		public const Buttons ZoomIn = Buttons.LeftShoulder;
		public const Buttons ZoomOut = Buttons.RightShoulder;
		public const Buttons ToggleCamera = Buttons.RightStick;
		public const Buttons ResetCamera = Buttons.LeftStick;
	}
}
