namespace XRpgLibrary.Configuration
{
	public class Controls
	{
		public Keyboard Keyboard = new Keyboard();
		public GamePad GamePad = new GamePad();

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
