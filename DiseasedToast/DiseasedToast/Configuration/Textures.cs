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
