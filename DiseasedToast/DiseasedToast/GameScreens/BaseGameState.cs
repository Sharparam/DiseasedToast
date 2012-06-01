using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.Controls;
using XRpgLibrary.GameManagement;

namespace DiseasedToast.GameScreens
{
	internal abstract class BaseGameState : GameState
	{
		#region Fields

		protected readonly log4net.ILog Log;

		protected readonly MainGame GameRef;
		protected ControlManager ControlManager;
		protected PlayerIndex PlayerIndexInControl;

		#endregion

		#region Properties
		#endregion

		#region Constructors

		protected BaseGameState(Game game, GameStateManager manager) : base(game, manager)
		{
			Log = RpgLibrary.Logging.LogManager.GetLogger(this);
			Log.Debug("Constructing GameState... (" + GetType() + ")");
			Log = RpgLibrary.Logging.LogManager.GetLogger(this);
			GameRef = (MainGame) game;
			PlayerIndexInControl = PlayerIndex.One;
		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();
			Log.Info("Initialized!");
		}

		protected override void LoadContent()
		{
			ContentManager content = Game.Content;

			ControlManager = new ControlManager(content.Load<SpriteFont>(@"Fonts\ControlFont"));

			base.LoadContent();

			Log.Debug("Content loaded!");
		}

		public override void Update(GameTime gameTime)
		{
			GameRef.AudioManager.Update(gameTime);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}

		#endregion
	}
}
