namespace RpgLibrary
{
	public class RolePlayingGame
	{
		#region Properties

		public string Name;
		public string Description;

		#endregion

		#region Constructors

		public RolePlayingGame(string name, string description)
		{
			Name = name;
			Description = description;
		}

		#endregion
	}
}
