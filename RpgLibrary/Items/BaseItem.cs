using System;
using System.Linq;

namespace RpgLibrary.Items
{
	public abstract class BaseItem : IEquatable<BaseItem>
	{
		#region Fields

		private const string ItemStringFormat = "{0}: {1}, {2}, {3}";

		#endregion

		#region Properties

		public string Name { get; protected set; }		
		public string Type { get; protected set; }
		public int Price { get; protected set; }
		public float Weight { get; protected set; }
		public bool Equipped { get; protected set; }
		public string[] AllowedClasses { get; protected set; }

		#endregion

		#region Constructors

		public BaseItem(string name, string type, int price = 0, float weight = 0.0f, params string[] allowedClasses)
		{
			Name = name;
			Type = type;
			Price = price;
			Weight = weight;
			Equipped = false;

			AllowedClasses = new string[allowedClasses.Length];
			for (int i = 0; i < AllowedClasses.Length; i++)
				AllowedClasses[i] = allowedClasses[i];
		}

		#endregion

		#region Abstract Methods

		public abstract object Clone();

		public override string ToString()
		{
			return string.Format(ItemStringFormat, Name, Type, Price, Weight);
		}

		#endregion

		#region Methods

		public bool Equals(BaseItem item)
		{
			if (item == null)
				return false;

			return item.Name == Name && item.Type == Type;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			var item = obj as BaseItem;
			return Equals(item);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode() - Type.GetHashCode();
		}

		public static bool operator == (BaseItem item1, BaseItem item2)
		{
			if ((object)item1 == null || (object)item2 == null)
				return Equals(item1, item2);

			return item1.Equals(item2);
		}

		public static bool operator != (BaseItem item1, BaseItem item2)
		{
			if (item1 == null || item2 == null)
				return !Equals(item1, item2);

			return !item1.Equals(item2);
		}

		public virtual bool CanEquip(string c)
		{
			return AllowedClasses.Contains(c);
		}

		#endregion
	}
}
