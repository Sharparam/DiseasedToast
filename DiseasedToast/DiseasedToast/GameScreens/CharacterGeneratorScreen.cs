using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RpgLibrary.Items;
using RpgLibrary.Skills;
using RpgLibrary.Entities;
using RpgLibrary.Items.Data;
using RpgLibrary.Serializing;

using XRpgLibrary.Items;
using XRpgLibrary.Input;
using XRpgLibrary.World;
using XRpgLibrary.Sprites;
using XRpgLibrary.Controls;
using XRpgLibrary.Characters;
using XRpgLibrary.TileEngine;
using XRpgLibrary.GameManagement;

using DiseasedToast.Components;

namespace DiseasedToast.GameScreens
{
	internal class CharacterGeneratorScreen : BaseGameState
	{
		#region Fields

		private const int SkillPointCount = 10;

		private LeftRightSelector _genderSelector;
		private LeftRightSelector _classSelector;
		private PictureBox _background;
		private PictureBox _characterImage;
		private Texture2D[,] _characterImages;
		private Texture2D _containers;

		private static readonly string[] Genders = new[]
		{
		    "Male",
		    "Female"
		};

		private string[] _classes;

		#endregion

		#region Properties

		public string SelectedGender
		{
			get { return _genderSelector.SelectedItem; }
		}

		public string SelectedClass
		{
			get { return _classSelector.SelectedItem; }
		}

		#endregion

		#region Constructors

		public CharacterGeneratorScreen(Game game, GameStateManager stateManager) : base(game, stateManager)
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

			_classes = new string[DataManager.EntityData.Count];
			int index = 0;
			foreach (var key in DataManager.EntityData.Keys)
			{
				_classes[index] = key;
				index++;
			}

			LoadImages();
			CreateControls();
			_containers = Game.Content.Load<Texture2D>(@"Sprites\Objects\containers");
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

		private void CreateControls()
		{
			Log.Debug("Loading controls...");
			var leftTexture = Game.Content.Load<Texture2D>(@"GUI\LeftArrowUp");
			var rightTexture = Game.Content.Load<Texture2D>(@"GUI\RightArrowUp");
			var stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

			_background = new PictureBox(Game.Content.Load<Texture2D>(@"Backgrounds\Title"), GameRef.ScreenRectangle);
			ControlManager.Add(_background);

			var label1 = new Label {Text = "Who will search for the Eyes of the Dragon?"};
			label1.AutoSize();
			label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X) / 2, 150);
			ControlManager.Add(label1);

			_genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
			_genderSelector.SetItems(Genders, 125);
			_genderSelector.Position = new Vector2(label1.Position.X, 200);
			_genderSelector.SelectionChanged += SelectionChanged;
			ControlManager.Add(_genderSelector);

			_classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
			_classSelector.SetItems(_classes, 125);
			_classSelector.Position = new Vector2(label1.Position.X, 250);
			_classSelector.SelectionChanged += SelectionChanged;
			ControlManager.Add(_classSelector);

			var acceptLabel = new LinkLabel {Text = "Accept this character", Position = new Vector2(label1.Position.X, 300)};
			acceptLabel.Selected += AcceptLabelSelected;
			ControlManager.Add(acceptLabel);

			_characterImage = new PictureBox(_characterImages[0, 0], new Rectangle(500, 200, 96, 96), new Rectangle(0, 0, 32, 32));
			ControlManager.Add(_characterImage);

			ControlManager.NextControl();
			Log.Debug("Loaded controls!");
		}

		private void LoadImages()
		{
			Log.Debug("Loading images...");
			_characterImages = new Texture2D[Genders.Length, _classes.Length];
			for (int g = 0; g < Genders.Length; g++)
				for (int c = 0; c < _classes.Length; c++)
					_characterImages[g, c] = Game.Content.Load<Texture2D>(@"Sprites\Player\" + Genders[g] + _classes[c]);
			Log.Debug("Loaded images!");
		}

		private void SelectionChanged(object sender, EventArgs e)
		{
			Log.Debug("Selection changed, updating character image.");
			_characterImage.Image = _characterImages[_genderSelector.SelectedIndex, _classSelector.SelectedIndex];
		}

		private void AcceptLabelSelected(object sender, EventArgs e)
		{
			Log.Debug("LinkLabel1 selected!");
			InputHandler.Flush();
			Log.Info("Creating player...");
			CreatePlayer();
			Log.Info("Creating world...");
			CreateWorld();
			Log.Info("Setting skill points...");
			GameRef.SkillScreen.SkillPoints = SkillPointCount;
			Log.Info("Changing to SkillScreen...");
			//StateManager.ChangeState(GameRef.SkillScreen);7
			Transition(ChangeType.Change, GameRef.SkillScreen);
			GameRef.SkillScreen.SetTarget(GamePlayScreen.Player.Character);
		}

		private void CreatePlayer()
		{
			var animations = new Dictionary<AnimationKey, Animation>
			{
				{AnimationKey.South, new Animation(3)},
				{AnimationKey.West, new Animation(3, 32, 32, 0, 1)},
				{AnimationKey.East, new Animation(3, 32, 32, 0, 2)},
				{AnimationKey.North, new Animation(3, 32, 32, 0, 3)}
			};

			var sprite = new AnimatedSprite(_characterImages[_genderSelector.SelectedIndex, _classSelector.SelectedIndex], animations);
			var gender = _genderSelector.SelectedIndex == 1 ? EntityGender.Female : EntityGender.Male;
			var entity = new Entity("Pat", DataManager.EntityData[_classSelector.SelectedItem], gender, EntityType.Character);

			foreach (var key in DataManager.SkillData.Keys)
			{
				var skill = Skill.FromSkillData(DataManager.SkillData[key]);
				entity.Skills.Add(key, skill);
			}

			var character = new Character(entity, sprite);
			GamePlayScreen.Player = new Player(GameRef, character);

			Log.Debug("Player created!");
		}

		private void CreateWorld()
		{
			var tileset = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset1"));
			var tileset2 = new Tileset(Game.Content.Load<Texture2D>(@"Tilesets\tileset2"));

			var tilesets = new List<Tileset> { tileset, tileset2 };

			var layer = new MapLayer(100, 100);
			var splatter = new MapLayer(100, 100);

			for (int y = 0; y < layer.Height; y++)
				for (int x = 0; x < layer.Width; x++)
					layer[x, y] = new Tile(0, 0);

			var rand = new Random();

			for (int i = 0; i < 100; i++)
				splatter.SetRandom(rand.Next(2, 14));

			splatter[1, 0] = new Tile(0, 1);
			splatter[2, 0] = new Tile(2, 1);
			splatter[3, 0] = new Tile(0, 1);

			var layers = new List<MapLayer> { layer, splatter };

			var map = new TileMap(tilesets, layers);
			var level = new Level(map);

			var chestData = Serializer.Deserialize<ContainerData>(@"Game\Containers\Plain Chest.container");

			var chest = new Container(chestData);

			var chestSprite = new BaseSprite(_containers, new Rectangle(0, 0, 32, 32), new Point(10, 10));

			var itemSprite = new ItemSprite(chest, chestSprite);

			level.Containers.Add(itemSprite);

			var world = new World(GameRef, GameRef.ScreenRectangle);
			world.Levels.Add(level);
			world.CurrentLevel = 0;

			GamePlayScreen.World = world;
			Log.Debug("World created!");
		}

		#endregion
	}
}
