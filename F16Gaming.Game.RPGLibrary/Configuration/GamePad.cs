using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace F16Gaming.Game.RPGLibrary.Configuration
{
	public class GamePad
	{
		public readonly Dictionary<string, Button> Mapping = new Dictionary<string, Button>();

		public Buttons this[string key]
		{
			get { return Get(key); }
			set { Set(key, value); }
		}

		public Buttons Get(string key)
		{
			if (Mapping.ContainsKey(key))
				return Mapping[key].Value;
			throw new InvalidOperationException("Button is not defined: " + key);
		}

		public void SetDefault(string key, Buttons value)
		{
			if (Mapping.ContainsKey(key))
				Mapping[key].SetDefault(value);
		}

		public void Set(string key, Buttons value)
		{
			if (Mapping.ContainsKey(key))
				Mapping[key].Set(value);
			else
				Mapping.Add(key, new Button(value));
		}

		public void Unset(string key)
		{
			if (Mapping.ContainsKey(key))
				Mapping[key].Unset();
		}

		public void Remove(string key)
		{
			if (Mapping.ContainsKey(key))
				Mapping.Remove(key);
		}

		public void Reset()
		{
			foreach (var key in Mapping.Values)
				key.Reset();
		}
	}
}
