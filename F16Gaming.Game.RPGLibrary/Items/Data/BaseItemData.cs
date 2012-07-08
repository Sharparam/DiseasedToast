namespace F16Gaming.Game.RPGLibrary.Items.Data
{
	public abstract class BaseItemData
	{
		#region Fields

		private const string ToStringFormat = "{0}: Type = {1}, Price = {2}, Weight = {3}";

		public string Name;
		public string Type;
		public int Price;
		public float Weight;
		public bool Equipped;
		public string[] AllowedClasses;

		#endregion

		#region Methods

		public override string ToString()
		{
			return string.Format(ToStringFormat, Name, Type, Price, Weight);
		}

		#endregion
	}
}
