using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Items
{
	public class Backpack
	{
		#region Fields

		private readonly List<GameItem> _items;

		#endregion

		#region Properties

		public List<GameItem> Items
		{
			get { return _items; }
		}

		public int Capacity
		{
			get { return _items.Count; }
		}

		#endregion

		#region Constructors

		public Backpack()
		{
			_items = new List<GameItem>();
		}

		#endregion

		#region Methods

		public void AddItem(GameItem item)
		{
			_items.Add(item);
		}

		public void RemoveItem(GameItem item)
		{
			_items.Remove(item);
		}

		#endregion
	}
}
