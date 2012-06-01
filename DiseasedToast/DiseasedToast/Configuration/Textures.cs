namespace DiseasedToast.Configuration
{
	internal static class Textures
	{
		public const string Backgrounds = "Backgrounds";
		public static string TitleBackground
		{
			get { return Backgrounds + @"\Title"; }
		}

		public const string GUI = "GUI";
		public static string LeftArrowUp
		{
			get { return GUI + @"\LeftArrowUp"; }
		}
		public static string RightArrowUp
		{
			get { return GUI + @"\RightArrowUp"; }
		}
		public static string StopBar
		{
			get { return GUI + @"\StopBar"; }
		}
		public static string ListBoxImage
		{
			get { return GUI + @"\ListBoxImage"; }
		}

		public const string Sprites = "Sprites";
		public static string PlayerSprites
		{
			get { return Sprites + @"\Player"; }
		}
		public static string MaleFighter
		{
			get { return PlayerSprites + @"\malefighter"; }
		}
		public static string MalePriest
		{
			get { return PlayerSprites + @"\malepriest"; }
		}
		public static string MaleRogue
		{
			get { return PlayerSprites + @"\malerogue"; }
		}
		public static string MaleWizard
		{
			get { return PlayerSprites + @"\malewizard"; }
		}
		public static string FemaleFighter
		{
			get { return PlayerSprites + @"\femalefighter"; }
		}
		public static string FemalePriest
		{
			get { return PlayerSprites + @"\femalepriest"; }
		}
		public static string FemaleRogue
		{
			get { return PlayerSprites + @"\femalerogue"; }
		}
		public static string FemaleWizard
		{
			get { return PlayerSprites + @"\femalewizard"; }
		}

		public const string Tilesets = "Tilesets";
		public static string GrassTileset
		{
			get { return Tilesets + @"\tileset1"; }
		}
		public static string CityTileset
		{
			get { return Tilesets + @"\tileset2"; }
		}
	}
}
