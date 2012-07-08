using System;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Items.Data;

namespace F16Gaming.Game.RPGLibrary.Items
{
	public class Container : BaseItem
	{
		#region Fields

		private static Random _rand = new Random();
		private ContainerData _data;

		#endregion

		#region Properties

		public bool IsTrapped
		{
			get { return _data.IsLocked; }
		}

		public bool IsLocked
		{
			get { return _data.IsLocked; }
		}

		public int Gold
		{
			get
			{
				if (_data.MinGold <= 0 && _data.MaxGold <= 0)
					return 0;

				int gold = _rand.Next(_data.MinGold, _data.MaxGold + 1);
				_data.MinGold = 0;
				_data.MaxGold = 0;
				return gold;
			}
		}

		#endregion

		#region Constructors

		public Container(ContainerData data) : base(data.Name, "")
		{
			_data = data;
		}

		#endregion

		#region Abstract and Virtual Methods

		public override object Clone()
		{
			var data = new ContainerData
			{
				Name = _data.Name,
				Difficulty = _data.Difficulty,
				IsTrapped = _data.IsTrapped,
				IsLocked = _data.IsLocked,
				TrapName = _data.TrapName,
				KeyName = _data.KeyName,
				KeyType = _data.KeyType,
				KeysRequired = _data.KeysRequired,
				MinGold = _data.MinGold,
				MaxGold = _data.MaxGold
			};

			foreach (KeyValuePair<string, string> pair in _data.ItemCollection)
				data.ItemCollection.Add(pair.Key, pair.Value);

			return new Container(data);
		}

		#endregion

		#region Methods
		#endregion
	}
}
