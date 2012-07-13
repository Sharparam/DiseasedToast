using System;
using System.Collections.Generic;
using DiseasedToast.Components;
using F16Gaming.Game.RPGLibrary.Characters;
using F16Gaming.Game.RPGLibrary.Controls;
using F16Gaming.Game.RPGLibrary.Engine;
using F16Gaming.Game.RPGLibrary.Entities;
using F16Gaming.Game.RPGLibrary.GameManagement;
using F16Gaming.Game.RPGLibrary.Sprites;
using F16Gaming.Game.RPGLibrary.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DiseasedToast.GameScreens
{
	internal class LoadGameScreen : BaseGameState
	{
		#region Fields

		private PictureBox _background;
		private ListBox _loadListBox;
		private LinkLabel _loadLink;
		private LinkLabel _exitLink;

		#endregion

		#region Properties
		#endregion

		#region Constructors

		public LoadGameScreen(MainGame game, GameStateManager manager) : base(game, manager)
		{

		}

		#endregion

		#region XNA Methods

		protected override void LoadContent()
		{
			base.LoadContent();

			ContentManager content = Game.Content;

			_background = new PictureBox(content.Load<Texture2D>(@"Backgrounds\Title"), GameRef.ScreenRectangle);
			ControlManager.Add(_background);

			_loadLink = new LinkLabel {Text = "Select game", Position = new Vector2(50, 150)};
			_loadLink.Selected += LoadLinkSelected;
			ControlManager.Add(_loadLink);

			_exitLink = new LinkLabel {Text = "Back"};
			_exitLink.Position = new Vector2(50, 150 + _exitLink.Font.LineSpacing);
			_exitLink.Selected += ExitLinkSelected;
			ControlManager.Add(_exitLink);

			_loadListBox = new ListBox(content.Load<Texture2D>(@"GUI\ListBoxImage"), content.Load<Texture2D>(@"GUI\RightArrowUp"), false) {Position = new Vector2(400, 150)};
			_loadListBox.Selected += LoadListBoxSelected;
			_loadListBox.Leave += LoadListBoxLeave;

			for (int i = 0; i < 20; i++)
				_loadListBox.Items.Add("Game Number: " + i);

			ControlManager.Add(_loadListBox);

			ControlManager.NextControl();
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

			ControlManager.Draw(GameRef.SpriteBatch);

			GameRef.SpriteBatch.End();
		}

		#endregion

		#region Methods

		private void LoadLinkSelected(object sender, EventArgs e)
		{
			Log.Debug("LoadLink selected, switching focus to list...");
			ControlManager.AcceptInput = false;
			_loadLink.HasFocus = false;
			_loadListBox.HasFocus = true;
		}

		private void ExitLinkSelected(object sender, EventArgs e)
		{
			Log.Debug("ExitLink selected, popping game state...");
			//StateManager.PopState();
			Transition(ChangeType.Pop);
		}

		private void LoadListBoxSelected(object sender, EventArgs e)
		{
			Log.Debug("List item selected!");
			_loadLink.HasFocus = true;
			_loadListBox.HasFocus = false;
			ControlManager.AcceptInput = true;

			//StateManager.ChangeState(GameRef.GamePlayScreen);
			//Transition(ChangeType.Change, GameRef.GamePlayScreen);
			//CreatePlayer();
			//CreateWorld();
		}

		private void LoadListBoxLeave(object sender, EventArgs e)
		{
			Log.Debug("ListBox left, restoring focus...");
			_loadLink.HasFocus = true;
			ControlManager.AcceptInput = true;
		}

		private void CreatePlayer()
		{
			Log.Info("Creating player...");
			var animations = new Dictionary<AnimationKey, Animation>
			{
				{AnimationKey.South, new Animation(3)},
				{AnimationKey.West, new Animation(3, 32, 32, 0, 1)},
				{AnimationKey.East, new Animation(3, 32, 32, 0, 2)},
				{AnimationKey.North, new Animation(3, 32, 32, 0, 3)}
			};

			var sprite = new AnimatedSprite(GameRef.Content.Load<Texture2D>(@"Sprites\Player\malefighter"), animations);
			var entity = new Entity("Encelwyn", DataManager.EntityData["Fighter"], EntityGender.Male, EntityType.Character);
			var character = new Character(entity, sprite);
			GamePlayScreen.Player = new Player(GameRef, character);

			Log.Debug("Player created!");
		}

		private void CreateWorld()
		{
			Log.Info("Creating world...");
			GameRef.World.ChangeLevel("test");

			GamePlayScreen.World = GameRef.World;
			Log.Debug("World created!");
		}

		#endregion
	}
}
