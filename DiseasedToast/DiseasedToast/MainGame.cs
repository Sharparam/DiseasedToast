using System;
using System.IO;
using DiseasedToast.Configuration;
using DiseasedToast.GameScreens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgLibrary.Serializing;
using XRpgLibrary.Audio;
using XRpgLibrary.Configuration;
using XRpgLibrary.Input;
using XRpgLibrary.GameManagement;

namespace DiseasedToast
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class MainGame : Game
	{
		#region Fields

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

		#region Constructors

		public MainGame()
		{
			_log = RpgLibrary.Logging.LogManager.GetLogger(this);

			Activated += GameActivated;
			Deactivated += GameDeactivated;

			_log.Info("Setting graphics settings...");

			_graphics = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = ScreenWidth,
				PreferredBackBufferHeight = ScreenHeight
			};

			_log.Info(string.Format("Screen size set to: [W]{0} x [H]{1}", ScreenWidth, ScreenHeight));

			//_graphics.SynchronizeWithVerticalRetrace = false;

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
		}

		protected override void UnloadContent()
		{
			
		}

		protected override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

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
