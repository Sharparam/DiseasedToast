namespace F16Gaming.Game.RPGLibrary.Items.Data
{
	public class KeyData
	{
		#region Fields

		private const string ToStringFormat = "{0}: {1}";

		public string Name;
		public string Type;

		#endregion Fields

		#region Properties
		#endregion Properties

		#region Constructors
		#endregion Constructors

		#region Methods

		public override string ToString()
		{
			return string.Format(ToStringFormat, Name, Type);
		}

		#endregion Methods
	}
}
