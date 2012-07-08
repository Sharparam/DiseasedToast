﻿using DiseasedToast.Components;
using DiseasedToast.Configuration;
using F16Gaming.Game.RPGLibrary.Audio;
using F16Gaming.Game.RPGLibrary.Controls;
using F16Gaming.Game.RPGLibrary.GameManagement;
using F16Gaming.Game.RPGLibrary.Input;
using F16Gaming.Game.RPGLibrary.TileEngine;
using F16Gaming.Game.RPGLibrary.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
		private const string LevelFormat = "LEVEL: #{0}. Now Playing: {1}";
		private const string PlayerFormat = "PLAYER[{0}]: HP( {1:000} / {2:000} ), POW( {3:000} / {4:000} ), STA( {5:000} / {6:000} )";
		private const string StatFormat = "STATS: ";
		private SpriteFont _debugFont;
		private Label _posLabel;
		private Label _levelLabel;
		private Label _playerLabel;
		private Label _pStatLabel;
		private Label _infoLabel;
		private Label _helpLabel;
		private bool _debugEnabled = true;
		private bool _showDebugHelp;
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

			_infoLabel = new Label
			{
				Enabled = true,
				Visible = true,
				Font = _debugFont,
				Name = "InfoLabel",
				Position = new Vector2(10, 500),
				Text = "KEYS: B = Battle Theme, M = Normal Theme",
				TabStop = false
			};
			_infoLabel.AutoSize();

			_helpLabel = new Label
			{
				Font = _debugFont,
				Name = "HelpLabel",
				Position = new Vector2(10, 700),
				Text = "H = Toggle Help"
			};
			_helpLabel.AutoSize();
#endif

			var song = GameRef.AudioManager.Song.LoadSong(@"Content\Music\Level0_bgm.mp3", "Level0_bgm", 0.1f);
			song.SetStartFade(new FadeInfo(0.0f, 0.1f));
			song.SetEndFade(new FadeInfo(0.1f, 0.0f, -0.01f));
			//GameRef.AudioManager.AddSong(new Song("Level0_bgm", Game.Content.Load<Microsoft.Xna.Framework.Media.Song>(@"Music\Level0_bgm"), 0.1f));
			//GameRef.AudioManager.AddSong(new Song("BattleTest", Game.Content.Load<Microsoft.Xna.Framework.Media.Song>(@"Music\BattleTest")));
			var bSong = GameRef.AudioManager.Song.LoadSong(@"Content\Music\BattleTest.mp3", "BattleTest");
			bSong.SetStartFade(new FadeInfo(0.0f, 1.0f));
			bSong.SetEndFade(new FadeInfo(1.0f, 0.0f, -0.01f));
			song.SetNext(bSong);
			bSong.SetNext(song);

			song.BeginStartFade();
			GameRef.AudioManager.Song.Play(song);
		}

		public override void Update(GameTime gameTime)
		{
			if (GameRef.HasFocus)
				_player.Update(gameTime);

			_healthBar.Update(MathHelper.Clamp(_player.Camera.Position.X / _player.Camera.Position.Y, 0.0f, 1.0f));
			_manaBar.Update(MathHelper.Clamp(_player.Camera.Position.Y / _player.Camera.Viewport.Height, 0.0f, 1.0f));
			_staminaBar.Update(MathHelper.Clamp(_player.Camera.Position.X / _player.Camera.Viewport.Width, 0.0f, 1.0f));

#if DEBUG
			UpdateDebug(gameTime);
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
			DrawDebug(gameTime);
#endif

			GameRef.SpriteBatch.End();
		}

		private void UpdateDebug(GameTime gameTime)
		{
			if (InputHandler.KeyReleased(Keys.F3))
				_debugEnabled = !_debugEnabled;

			if (!_debugEnabled)
				return;

			if (InputHandler.KeyReleased(Keys.H))
				_showDebugHelp = !_showDebugHelp;

			if (InputHandler.KeyReleased(Keys.B))
				GameRef.AudioManager.Song.GetSong("Level0_bgm").BeginEndFade();
			else if (InputHandler.KeyReleased(Keys.M))
				GameRef.AudioManager.Song.GetSong("BattleTest").BeginEndFade();

			_posLabel.Text = string.Format(PositionFormat, _player.Sprite.Position.X, _player.Sprite.Position.Y, _player.Sprite.Position.X / Engine.TileWidth, _player.Sprite.Position.Y / Engine.TileHeight);
			_levelLabel.Text = string.Format(LevelFormat, _world.CurrentLevel, GameRef.AudioManager.Song.NowPlaying.Name);
			_playerLabel.Text = string.Format(PlayerFormat, _player.Character.Entity.Name,
											  _player.Character.Entity.Health.Current, _player.Character.Entity.Health.Maximum,
											  _player.Character.Entity.Mana.Current, _player.Character.Entity.Mana.Maximum,
											  _player.Character.Entity.Stamina.Current, _player.Character.Entity.Stamina.Maximum);
		}

		private void DrawDebug(GameTime gameTime)
		{
			if (!_debugEnabled)
				return;

			_posLabel.Draw(GameRef.SpriteBatch);
			_levelLabel.Draw(GameRef.SpriteBatch);
			_playerLabel.Draw(GameRef.SpriteBatch);
			if (_showDebugHelp)
				_infoLabel.Draw(GameRef.SpriteBatch);
			_helpLabel.Draw(GameRef.SpriteBatch);
		}

		#endregion XNA Methods

		#region Abstract Methods
		#endregion

		#region Methods
		#endregion Methods
	}
}
