using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Configuration
{
	public class Keyboard
	{
		public readonly Dictionary<string, Key> Mapping = new Dictionary<string, Key>();

		public Keys Get(string key)
		{
			if (Mapping.ContainsKey(key))
				return Mapping[key].Value;
			throw new InvalidOperationException("Key is not defined: " + key);
		}

		public void SetDefault(string key, Keys value)
		{
			if (Mapping.ContainsKey(key))
				Mapping[key].SetDefault(value);
		}

		public void Set(string key, Keys value)
		{
			if (Mapping.ContainsKey(key))
				Mapping[key].Set(value);
			else
				Mapping.Add(key, new Key(value));
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
