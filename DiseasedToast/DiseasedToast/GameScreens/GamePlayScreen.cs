using DiseasedToast.Components;
using DiseasedToast.Configuration;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.Audio;
using XRpgLibrary.Configuration;
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

			GameRef.SpriteBatch.End();
		}

		#endregion

		#region Abstract Methods
		#endregion
	}
}
