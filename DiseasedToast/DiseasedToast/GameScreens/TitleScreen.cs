using System;
using F16Gaming.Game.RPGLibrary.Audio;
using F16Gaming.Game.RPGLibrary.Controls;
using F16Gaming.Game.RPGLibrary.GameManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

			var smallFont = content.Load<SpriteFont>(@"Fonts\SmallFont");

			var copyLabel = new Label
			{
				Text = "Copyright (c) 2012 by Adam Hellberg",
				Color = Color.White,
				Font = smallFont
			};
			copyLabel.CenterHorizontal(GameRef.ScreenRectangle.Width, 690);

			ControlManager.Add(copyLabel);

			var musicLabel = new Label
			{
				Text = "Music Copyright (c) 2012 by Kevin van der Laan [Diseased Flame]",
				Color = Color.White,
				Font = smallFont
			};
			musicLabel.CenterHorizontal(GameRef.ScreenRectangle.Width, 720);

			ControlManager.Add(musicLabel);

			//GameRef.AudioManager.AddSong(new XRpgLibrary.Audio.Song("TitleScreen", content.Load<Song>(@"Music\TitleScreen")));
			//GameRef.AudioManager.PlaySong("TitleScreen");
			var song = GameRef.AudioManager.Song.GetSong("MenuTheme");
			song.SetStartFade(new FadeInfo(0.0f, 1.0f));
			song.SetEndFade(new FadeInfo(1.0f, 0.0f, -0.01f, TimeSpan.FromMilliseconds(15)));
			
			//GameRef.AudioManager.PlaySong(GameRef.AudioManager.AddSong(new F16Gaming.Game.RPGLibrary.Audio.Song("TitleScreen", content.Load<Song>(@"Music\TitleScreen"))).Name);
			GameRef.AudioManager.Song.Play(song);
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
			//StateManager.PushState(GameRef.StartMenuScreen);
			Transition(ChangeType.Push, GameRef.StartMenuScreen);
		}

		#endregion
	}
}
