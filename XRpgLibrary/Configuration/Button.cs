using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Configuration
{
	public class Button
	{
		private Buttons? _value;

		public Buttons Default;

		public Buttons Value
		{
			get { return _value ?? Default; }
			set { _value = value; }
		}

		public Button(Buttons defaultKey, Buttons? value = null)
		{
			Default = defaultKey;
			_value = value;
		}

		public void Reset()
		{
			_value = Default;
		}

		public void Set(Buttons value)
		{
			_value = value;
		}

		public void Unset()
		{
			_value = null;
		}

		public void SetDefault(Buttons value)
		{
			Default = value;
		}
	}
}
