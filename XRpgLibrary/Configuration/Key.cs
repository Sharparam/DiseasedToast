using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Configuration
{
	public struct Key
	{
		private Keys? _value;

		public Keys Default;

		public Keys Value
		{
			get { return _value ?? Default; }
			set { _value = value; }
		}

		public Key(Keys defaultKey, Keys? value = null)
		{
			Default = defaultKey;
			_value = value;
		}

		public void Reset()
		{
			_value = Default;
		}

		public void Set(Keys value)
		{
			_value = value;
		}

		public void Unset()
		{
			_value = null;
		}

		public void SetDefault(Keys value)
		{
			Default = value;
		}
	}
}
