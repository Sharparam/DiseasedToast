using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.Controls;
using XRpgLibrary.GameManagement;

namespace DiseasedToast.GameScreens
{
	internal class TitleScreen : BaseGameState
	{
		#region Fields

		private Texture2D _background;
		private LinkLabel _startLabel;

		#endregion

		#region Constructors

		public TitleScreen(MainGame game, GameStateManager manager) : base(game, manager)
		{

		}

		#endregion

		#region XNA Methods

		protected override void LoadContent()
		{
			ContentManager content = GameRef.Content;

			_background = content.Load<Texture2D>(@"Backgrounds\NewTitle");

			base.LoadContent();

			_startLabel = new LinkLabel
			{
				Text = "Press ENTER to begin",
				Color = Color.White,
				TabStop = true,
				HasFocus = true
			};

			_startLabel.CenterHorizontal(GameRef.ScreenRectangle.Width, 600);
			_startLabel.Selected += StartLabelSelected;

			ControlManager.Add(_startLabel);
			
			var musicLabel = new Label
			{
				Text = "Music Copyright (c) 2012 by Kevin van der Laan [Diseased Flame]",
				Color = Color.White,
				Font = content.Load<SpriteFont>(@"Fonts\SmallFont")
			};

			musicLabel.CenterHorizontal(GameRef.ScreenRectangle.Width, 720);

			ControlManager.Add(musicLabel);

			//GameRef.AudioManager.AddSong(new XRpgLibrary.Audio.Song("TitleScreen", content.Load<Song>(@"Music\TitleScreen")));
			//GameRef.AudioManager.PlaySong("TitleScreen");
			GameRef.AudioManager.PlaySong(GameRef.AudioManager.AddSong(new XRpgLibrary.Audio.Song("TitleScreen", content.Load<Song>(@"Music\TitleScreen"))).Name);
		}

		public override void Update(GameTime gameTime)
		{
			ControlManager.Update(gameTime);

			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			GameRef.SpriteBatch.Begin();

			base.Draw(gameTime);

			GameRef.SpriteBatch.Draw(
				_background,
				GameRef.ScreenRectangle,
				Color.White);

			ControlManager.Draw(GameRef.SpriteBatch);

			GameRef.SpriteBatch.End();
		}

		#endregion

		#region Methods

		private void StartLabelSelected(object sender, EventArgs e)
		{
			Log.Info("Pushing start menu screen...");
			StateManager.PushState(GameRef.StartMenuScreen);
		}

		#endregion
	}
}
