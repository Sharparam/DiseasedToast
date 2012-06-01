namespace RpgLibrary.Skills
{
	public struct Reagent
	{
		#region Fields

		public string Name;
		public ushort AmountRequired;

		#endregion Fields

		#region Properties
		#endregion Properties

		#region Constructors

		public Reagent(string name, ushort amount)
		{
			Name = name;
			AmountRequired = amount;
		}

		#endregion Constructors

		#region Methods
		#endregion Methods
	}
}
