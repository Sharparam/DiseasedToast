namespace RpgLibrary.Items
{
	public class Reagent : BaseItem
	{
		#region Fields
		#endregion Fields

		#region Properties
		#endregion Properties

		#region Constructors

		public Reagent(string name, string type, int price, float weight) : base(name, type, price, weight, null)
		{
			
		}

		#endregion Constructors

		#region Abstract Methods

		public override object Clone()
		{
			return new Reagent(Name, Type, Price, Weight);
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
