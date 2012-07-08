using Microsoft.Xna.Framework.Input;

namespace F16Gaming.Game.RPGLibrary.Configuration
{
	public class Button
	{
		private Buttons? _value;

		public Buttons Default;

		public Buttons Value
		{
			get { return _value == null ? Default : (Buttons) _value; }
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
