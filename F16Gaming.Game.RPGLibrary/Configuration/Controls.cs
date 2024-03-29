﻿namespace F16Gaming.Game.RPGLibrary.Configuration
{
	public class Controls
	{
		public readonly Keyboard Keyboard = new Keyboard();
		public readonly GamePad GamePad = new GamePad();

		public void Reset()
		{
			ResetKeyboard();
			ResetGamePad();
		}

		public void ResetKeyboard()
		{
			Keyboard.Reset();
		}

		public void ResetGamePad()
		{
			GamePad.Reset();
		}
	}
}
