using DiseasedToast.Components;
using DiseasedToast.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.Audio;
using XRpgLibrary.Configuration;
using XRpgLibrary.Controls;
using XRpgLibrary.Input;
using XRpgLibrary.World;
using XRpgLibrary.TileEngine;
using XRpgLibrary.GameManagement;

namespace DiseasedToast.GameScreens
{
	internal class GamePlayScreen : BaseGameState
	{
		#region Fields

		private const int BarHorizontalOffset = 10;
		private const int BarVerticalOffset = 10;
		private const int BarLeftOffset = 200;

		private Engine _engine = new Engine(32, 32);
		private static Player _player;
		private static World _world;
		private Texture2D _pointer;
		private Bar _healthBar;
		private Bar _manaBar;
		private Bar _staminaBar;

#if DEBUG
		private const string PositionFormat = "Position: (REAL) < [X] {0:0000.00000} [Y] {1:0000.00000} > (ENGINE) < [X] {2:000.00000} [Y] {3:000.00000} >";
		private const string LevelFormat = "LEVEL: #{0}, ";
		private const string PlayerFormat = "PLAYER[{0}]: HP( {1:000} / {2:000} ), POW( {3:000} / {4:000} ), STA( {5:000} / {6:000} )";
		private const string StatFormat = "STATS: ";
		private SpriteFont _debugFont;
		private Label _posLabel;
		private Label _levelLabel;
		private Label _playerLabel;
		private Label _pStatLabel;
#endif

		#endregion

		#region Properties

		public static Player Player
		{
			get { return _player; }
			set { _player = value; }
		}

		public static World World
		{
			get { return _world; }
			set { _world = value; }
		}

		#endregion

		#region Constructors

		public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
		{
			Log.Info("Setting game world...");
			_world = new World(game, GameRef.ScreenRectangle);
		}

		#endregion

		#region XNA Methods

		public override void Initialize()
		{
			base.Initialize();

			Game.IsMouseVisible = true;
		}

		protected override void LoadContent()
		{
			base.LoadContent();

			_pointer = Game.Content.Load<Texture2D>(@"GUI\pointer");

			var emptyBar = Game.Content.Load<Texture2D>(@"GUI\EmptyBar");
			int barYPos = Game.GraphicsDevice.Viewport.Height - (emptyBar.Height + BarVerticalOffset);
			_healthBar = new Bar(Game.Content.Load<Texture2D>(@"GUI\HealthBar"), emptyBar, new Vector2(BarLeftOffset, barYPos));
			_manaBar = new Bar(Game.Content.Load<Texture2D>(@"GUI\ManaBar"), emptyBar, new Vector2(_healthBar.Position.X + emptyBar.Width + BarHorizontalOffset, barYPos));
			_staminaBar = new Bar(Game.Content.Load<Texture2D>(@"GUI\StaminaBar"), emptyBar, new Vector2(_manaBar.Position.X + emptyBar.Width + BarHorizontalOffset, barYPos));
#if DEBUG
			_debugFont = Game.Content.Load<SpriteFont>(@"Fonts\DebugFont");

			_posLabel = new Label
			{
				Enabled = true,
				Visible = true,
				Font = _debugFont,
				Name = "PositionLabel",
				Position = new Vector2(10, 10),
				Text = PositionFormat,
				TabStop = false
			};
			_posLabel.AutoSize();

			_levelLabel = new Label
			{
				Enabled = true,
				Visible = true,
				Font = _debugFont,
				Name = "LevelLabel",
				Position = new Vector2(10, _posLabel.Position.Y + _posLabel.Size.Y + 5),
				Text = LevelFormat,
				TabStop = false
			};
			_levelLabel.AutoSize();

			_playerLabel = new Label
			{
				Enabled = true,
				Visible = true,
				Font = _debugFont,
				Name = "PlayerLabel",
				Position = new Vector2(10, _levelLabel.Position.Y + _levelLabel.Size.Y + 5),
				Text = PlayerFormat,
				TabStop = false
			};
			_playerLabel.AutoSize();
#endif

			GameRef.AudioManager.AddSong(new Song("Village", Game.Content.Load<Microsoft.Xna.Framework.Media.Song>(@"Music\Village"), 0.1f));

			GameRef.AudioManager.FadeOutSong("Village", true);
		}

		public override void Update(GameTime gameTime)
		{
			if (GameRef.HasFocus)
				_player.Update(gameTime);

			_healthBar.Update(MathHelper.Clamp(_player.Camera.Position.X / _player.Camera.Position.Y, 0.0f, 1.0f));
			_manaBar.Update(MathHelper.Clamp(_player.Camera.Position.Y / _player.Camera.Viewport.Height, 0.0f, 1.0f));
			_staminaBar.Update(MathHelper.Clamp(_player.Camera.Position.X / _player.Camera.Viewport.Width, 0.0f, 1.0f));

#if DEBUG
			_posLabel.Text = string.Format(PositionFormat, _player.Sprite.Position.X, _player.Sprite.Position.Y, _player.Sprite.Position.X / Engine.TileWidth, _player.Sprite.Position.Y / Engine.TileHeight);
			_levelLabel.Text = string.Format(LevelFormat, _world.CurrentLevel);
			_playerLabel.Text = string.Format(PlayerFormat, _player.Character.Entity.Name,
			                                  _player.Character.Entity.Health.Current, _player.Character.Entity.Health.Maximum,
			                                  _player.Character.Entity.Mana.Current, _player.Character.Entity.Mana.Maximum,
			                                  _player.Character.Entity.Stamina.Current, _player.Character.Entity.Stamina.Maximum);
#endif

			_world.Update(gameTime);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			// World Drawing (moves with world)
			GameRef.SpriteBatch.Begin(
				SpriteSortMode.Deferred,
				BlendState.AlphaBlend,
				SamplerState.PointClamp,
				null,
				null,
				null,
				_player.Camera.Transformation);

			base.Draw(gameTime);

			_world.DrawLevel(gameTime, GameRef.SpriteBatch, _player.Camera);
			_player.Draw(gameTime, GameRef.SpriteBatch);

			GameRef.SpriteBatch.Draw(_pointer, new Vector2(InputHandler.MouseState.X, InputHandler.MouseState.Y) + _player.Camera.Position, Color.White);

			GameRef.SpriteBatch.End();

			// UI and other screen objects (static position on screen)
			GameRef.SpriteBatch.Begin();

			_healthBar.Draw(GameRef.SpriteBatch);
			_manaBar.Draw(GameRef.SpriteBatch);
			_staminaBar.Draw(GameRef.SpriteBatch);

#if DEBUG
			_posLabel.Draw(GameRef.SpriteBatch);
			_levelLabel.Draw(GameRef.SpriteBatch);
			_playerLabel.Draw(GameRef.SpriteBatch);
#endif

			GameRef.SpriteBatch.End();
		}

		#endregion

		#region Abstract Methods
		#endregion
	}
}
