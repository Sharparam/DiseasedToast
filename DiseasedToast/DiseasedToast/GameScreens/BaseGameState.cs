using System;
using F16Gaming.Game.RPGLibrary.Controls;
using F16Gaming.Game.RPGLibrary.GameManagement;
using F16Gaming.Game.RPGLibrary.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DiseasedToast.GameScreens
{
	internal abstract class BaseGameState : GameState
	{
		#region Fields

		protected readonly log4net.ILog Log;

		protected readonly MainGame GameRef;
		protected ControlManager ControlManager;
		protected readonly PlayerIndex PlayerIndexInControl;
		protected BaseGameState TransitionTo;
		protected bool Transitioning;
		protected ChangeType ChangeType;
		protected TimeSpan TransitionTimer;
		protected TimeSpan TransitionDelay = TimeSpan.FromSeconds(0.5);

		#endregion

		#region Properties
		#endregion

		#region Constructors

		protected BaseGameState(Game game, GameStateManager manager) : base(game, manager)
		{
			Log = LogManager.GetLogger(this);
			Log.Debug("Constructing GameState... (" + GetType() + ")");
			Log = LogManager.GetLogger(this);
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
			if (Transitioning)
			{
				TransitionTimer += gameTime.ElapsedGameTime;
				if (TransitionTimer >= TransitionDelay)
				{
					Transitioning = false;
					ControlManager.AcceptInput = true;
					switch(ChangeType)
					{
						case ChangeType.Change:
							StateManager.ChangeState(TransitionTo);
							break;
						case ChangeType.Pop:
							StateManager.PopState();
							break;
						case ChangeType.Push:
							StateManager.PushState(TransitionTo);
							break;
					}
				}
			}

			GameRef.AudioManager.Update(gameTime);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}

		public virtual void Transition(ChangeType change, BaseGameState gameState = null)
		{
			ControlManager.AcceptInput = false;
			Transitioning = true;
			ChangeType = change;
			TransitionTo = gameState;
			TransitionTimer = TimeSpan.Zero;
		}

		#endregion
	}
}
