namespace RpgLibrary.Items
{
	public class Key : BaseItem
	{
		#region Fields
		#endregion

		#region Properties
		#endregion

		#region Constructors

		public Key(string name, string type) : base(name, type)
		{

		}

		#endregion

		#region Abstract and Virtual Methods

		public override object Clone()
		{
			return new Key(Name, Type);
		}

		#endregion
	}
}
