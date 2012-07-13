using System;
using System.IO;
using System.Linq;
using DiseasedToast.Configuration;
using DiseasedToast.GameScreens;
using F16Gaming.Game.RPGLibrary;
using F16Gaming.Game.RPGLibrary.Audio;
using F16Gaming.Game.RPGLibrary.GameManagement;
using F16Gaming.Game.RPGLibrary.Input;
using F16Gaming.Game.RPGLibrary.Logging;
using F16Gaming.Game.RPGLibrary.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DiseasedToast
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class MainGame : Game
	{
		#region Fields

		private const string MapsFolder = @"Content\Maps";
		private const string MusicFolder = @"Content\Music";

		private F16Gaming.Game.RPGLibrary.Engine.Mapping.Map _map;

		private readonly log4net.ILog _log;

		internal readonly AudioManager AudioManager;

		#endregion

		#region XNA Fields and Properties

		private readonly GraphicsDeviceManager _graphics;
		public SpriteBatch SpriteBatch { get; private set; }

		#endregion

		#region GameState Fields

		private readonly GameStateManager _stateManager;

		internal readonly TitleScreen TitleScreen;
		internal readonly StartMenuScreen StartMenuScreen;
		internal readonly CharacterGeneratorScreen CharacterGeneratorScreen;
		internal readonly SkillScreen SkillScreen;
		internal readonly LoadGameScreen LoadGameScreen;
		internal readonly GamePlayScreen GamePlayScreen;

		internal readonly ControlsManager ControlsManager;

		#endregion

		#region Screen Fields

		private const int ScreenWidth = 1024;
		private const int ScreenHeight = 768;

		public readonly Rectangle ScreenRectangle;

		#endregion

		#region Properties

		public bool HasFocus { get; private set; }

		#endregion

		#region Game Fields

		internal World World { get; private set; }

		#endregion Game Fields

		#region Constructors

		public MainGame()
		{
			_log = LogManager.GetLogger(this);

			Activated += GameActivated;
			Deactivated += GameDeactivated;

			_log.Info("Setting graphics settings...");

			_graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = ScreenWidth,
				PreferredBackBufferHeight = ScreenHeight
			};

			_log.Info(string.Format("Screen size set to: [W]{0} x [H]{1}", ScreenWidth, ScreenHeight));

			_graphics.SynchronizeWithVerticalRetrace = false;
			//IsFixedTimeStep = false;

			_graphics.ApplyChanges();

			ScreenRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);

			_log.Debug("Setting content root directory...");

			Content.RootDirectory = "Content";

			// Create necessary folders if they don't exist
			try
			{
				if (!Directory.Exists(Paths.SettingsFolder))
					Directory.CreateDirectory(Paths.SettingsFolder);
			}
			catch (IOException ex)
			{
				_log.Error("Failed to create necessary game folders. Exception details as follows...");
				_log.Fatal("IOException: " + ex.Message + Environment.NewLine + "Details:", ex);
				_log.Fatal("Game will now exit...");
				Exit();
			}

			_log.Info("Loading controls...");
			ControlsManager = new ControlsManager();
			_log.Debug("Controls loaded!");

			_log.Info("Creating components...");

			AudioManager = new AudioManager();

			_stateManager = new GameStateManager(this);
			TitleScreen = new TitleScreen(this, _stateManager);
			StartMenuScreen = new StartMenuScreen(this, _stateManager);
			CharacterGeneratorScreen = new CharacterGeneratorScreen(this, _stateManager);
			SkillScreen = new SkillScreen(this, _stateManager);
			LoadGameScreen = new LoadGameScreen(this, _stateManager);
			GamePlayScreen = new GamePlayScreen(this, _stateManager);

			Components.Add(new InputHandler(this));
			Components.Add(_stateManager);

			_log.Info("Components created!");

			
			LoadMusic();

			var menuSong = AudioManager.Song.GetSong("MenuTheme");
			menuSong.SetStartFade(new FadeInfo(0.0f, 1.0f, 0.01f, TimeSpan.FromMilliseconds(20)));
			menuSong.SetEndFade(new FadeInfo(1.0f, 0.0f, 0.01f, TimeSpan.FromMilliseconds(15)));

			_log.Debug("Changing to TitleScreen...");
			_stateManager.ChangeState(TitleScreen);
		}

		#endregion

		#region XNA Methods

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			SpriteBatch = new SpriteBatch(GraphicsDevice);

			DataManager.ReadAllData();

			LoadMaps();
		}

		private void LoadMaps()
		{
			World = new World(this, ScreenRectangle);
			if (!Directory.Exists(MapsFolder))
			{
				_log.FatalFormat("ERROR! Maps directory ({0}) not found!", MapsFolder);
				Environment.Exit(-1);
			}

			_log.InfoFormat("Loading maps from {0}...", Path.GetFullPath(MapsFolder));

			foreach (var file in Directory.GetFiles(MapsFolder))
			{
				string mapName = Path.GetFileNameWithoutExtension(file);
				
				if (string.IsNullOrEmpty(mapName))
					continue;

				_log.InfoFormat("Loading map: {0}", mapName);
				
				string contentPath = Path.Combine("Maps", mapName);

				var map = Content.Load<Map>(contentPath).Convert();

				World.CreateLevel(mapName, map);

				_log.DebugFormat("Map {0} loaded successfully!", mapName);
			}
		}

		private void LoadMusic()
		{
			if (!Directory.Exists(@"Content\Music"))
			{
				_log.Fatal("ERROR! Content\\Music directory not found!");
				Environment.Exit(-1);
			}

			foreach (var file in Directory.EnumerateFiles(MusicFolder, "*.*")
				.Where(s =>
					s.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)
				 || s.EndsWith(".ogg", StringComparison.OrdinalIgnoreCase)))
			{
				// TODO: Make a better way to parse this

				string name = Path.GetFileNameWithoutExtension(file);
				float volume = 1.0f;
				bool loop = true;
				uint loopPoint = 0;
				float? sfStartVolume = null;
				float? sfEndVolume = null;
				float sfModifier = 0.01f;
				uint sfDelay = 25;
				float? efStartVolume = null;
				float? efEndVolume = null;
				float efModifier = 0.01f;
				uint efDelay = 25;

				string infoFile = Path.Combine(MusicFolder, name + ".info");
				if (File.Exists(infoFile))
				{
					string[] content = File.ReadAllLines(infoFile);
					if (content.Length > 0) // Parse song info
					{
						string[] line = content[0].Split(';');

						if (line.Length > 0)
						{
							name = line[0];
						}

						if (line.Length > 1)
						{
							float vol;
							bool valid = float.TryParse(line[0], out vol);
							if (valid)
								volume = vol;
						}

						if (line.Length > 2)
						{
							loop = line[1].ToLower() == "true";
						}

						if (line.Length > 3)
						{
							uint lp;
							bool valid = uint.TryParse(line[2], out lp);
							if (valid)
								loopPoint = lp;
						}
					}

					if (content.Length > 1) // Parse start fade info
					{
						string[] line = content[1].Split(';');

						if (line.Length > 0)
						{
							float sVol;
							bool valid = float.TryParse(line[0], out sVol);
							if (valid)
								sfStartVolume = sVol;
						}

						if (line.Length > 1)
						{
							float eVol;
							bool valid = float.TryParse(line[1], out eVol);
							if (valid)
								sfEndVolume = eVol;
						}

						if (line.Length > 2)
						{
							float mod;
							bool valid = float.TryParse(line[2], out mod);
							if (valid)
								sfModifier = mod;
						}

						if (line.Length > 3)
						{
							uint d;
							bool valid = uint.TryParse(line[3], out d);
							if (valid)
								sfDelay = d;
						}
					}

					if (content.Length > 2) // Parse end fade info
					{
						string[] line = content[2].Split(';');

						if (line.Length > 0)
						{
							float sVol;
							bool valid = float.TryParse(line[0], out sVol);
							if (valid)
								efStartVolume = sVol;
						}

						if (line.Length > 1)
						{
							float eVol;
							bool valid = float.TryParse(line[1], out eVol);
							if (valid)
								efEndVolume = eVol;
						}

						if (line.Length > 2)
						{
							float mod;
							bool valid = float.TryParse(line[2], out mod);
							if (valid)
								efModifier = mod;
						}

						if (line.Length > 3)
						{
							uint d;
							bool valid = uint.TryParse(line[3], out d);
							if (valid)
								efDelay = d;
						}
					}
				}

				var song = AudioManager.Song.LoadSong(file, name, volume, loop, loopPoint);

				if (sfStartVolume.HasValue && sfEndVolume.HasValue)
					song.SetStartFade(new FadeInfo(sfStartVolume.Value, sfEndVolume.Value, sfModifier, TimeSpan.FromMilliseconds(sfDelay)));

				if (efStartVolume.HasValue && efEndVolume.HasValue)
					song.SetEndFade(new FadeInfo(efStartVolume.Value, efEndVolume.Value, efModifier, TimeSpan.FromMilliseconds(efDelay)));
			}
		}

		protected override void UnloadContent()
		{
			AudioManager.Dispose();
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			base.Draw(gameTime);
		}

		#endregion

		#region Event Handlers

		private void GameActivated(object sender, EventArgs e)
		{
			_log.Debug("!!! GAME ACTIVATED !!!");
			HasFocus = true;
		}

		private void GameDeactivated(object sender, EventArgs e)
		{
			_log.Debug("!!! GAME DEACTIVATED !!!");
			HasFocus = false;
		}

		#endregion
	}
}
