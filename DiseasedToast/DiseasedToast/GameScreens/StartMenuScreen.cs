using System;
using System.Linq;
using F16Gaming.Game.RPGLibrary.Controls;
using F16Gaming.Game.RPGLibrary.GameManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DiseasedToast.GameScreens
{
	internal class StartMenuScreen : BaseGameState
	{
		#region Fields

		private PictureBox _background;
		private PictureBox _arrow;
		private PictureBox _arrowLeft;
		private LinkLabel _startGame;
		private LinkLabel _loadGame;
		private LinkLabel _exitGame;
		private float _maxItemWidth;

		#endregion

		#region Properties
		#endregion

		#region Constructors

		public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
		{

		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			base.LoadContent();

			ContentManager content = Game.Content;

			_background = new PictureBox(content.Load<Texture2D>(@"Backgrounds\Title"), GameRef.ScreenRectangle);
			ControlManager.Add(_background);

			var arrowTexture = content.Load<Texture2D>(@"GUI\LeftArrowUp");
			_arrow = new PictureBox(arrowTexture, 0, 0);
			ControlManager.Add(_arrow);

			var leftArrowTexture = content.Load<Texture2D>(@"GUI\RightArrowUp");
			_arrowLeft = new PictureBox(leftArrowTexture, 0, 0);
			ControlManager.Add(_arrowLeft);

			_startGame = new LinkLabel {Text = "The story begins"};
			_startGame.Size = _startGame.Font.MeasureString(_startGame.Text);
			_startGame.Selected += MenuItemSelected;
			ControlManager.Add(_startGame);

			_loadGame = new LinkLabel {Text = "The story continues"};
			_loadGame.Size = _loadGame.Font.MeasureString(_loadGame.Text);
			_loadGame.Selected += MenuItemSelected;
			ControlManager.Add(_loadGame);

			_exitGame = new LinkLabel {Text = "The story ends"};
			_exitGame.Size = _exitGame.Font.MeasureString(_exitGame.Text);
			_exitGame.Selected += MenuItemSelected;
			ControlManager.Add(_exitGame);

			ControlManager.NextControl();

			ControlManager.FocusChanged += ControlManagerFocusChanged;

			var position = new Vector2(350, 500);

			foreach (Control c in ControlManager.Where(c => c is LinkLabel))
			{
				if (c.Size.X > _maxItemWidth)
					_maxItemWidth = c.Size.X;

				c.Position = position;
				position.Y += c.Size.Y + 5.0f;
			}

			ControlManagerFocusChanged(_startGame, null);
		}

		public override void Update(GameTime gameTime)
		{
			ControlManager.Update(gameTime, PlayerIndexInControl);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			GameRef.SpriteBatch.Begin();

			base.Draw(gameTime);

			ControlManager.Draw(GameRef.SpriteBatch);

			GameRef.SpriteBatch.End();
		}

		#endregion

		#region Methods

		private void ControlManagerFocusChanged(object sender, EventArgs e)
		{
			//Log.Debug("ControlManagerFocusChanged");
			var control = sender as Control;
			if (control == null)
				return;

			var position = new Vector2(control.Position.X + _maxItemWidth + 10.0f, control.Position.Y + 4.0f);
			_arrow.SetPosition(position);
			var positionLeft = new Vector2(control.Position.X - 40.0f, control.Position.Y + 4.0f);
			_arrowLeft.SetPosition(positionLeft);
		}

		private void MenuItemSelected(object sender, EventArgs e)
		{
			Log.Debug("MenuItemSelected");
			if (sender == _startGame)
			{
				Log.Info("Entering character generator screen...");
				//StateManager.PushState(GameRef.CharacterGeneratorScreen);
				Transition(ChangeType.Push, GameRef.CharacterGeneratorScreen);
			}
			else if (sender == _loadGame)
			{
				Log.Info("Entering load game screen...");
				//StateManager.PushState(GameRef.LoadGameScreen);
				Transition(ChangeType.Push, GameRef.LoadGameScreen);
			}
			else if (sender == _exitGame)
			{
				Log.Info("Exiting game...");
				GameRef.Exit();
			}
			Log.Debug("MenuItemSelected ## END ##");
		}

		#endregion
	}
}
