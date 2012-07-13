using System;
using System.Collections.Generic;
using System.Linq;
using F16Gaming.Game.RPGLibrary.Engine;
using F16Gaming.Game.RPGLibrary.Engine.Mapping;
using F16Gaming.Game.RPGLibrary.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.World
{
	public class World : DrawableGameComponent
	{
		#region Graphic Fields and Properties

		private readonly Rectangle _screenRect;

		public Rectangle ScreenRectangle
		{
			get { return _screenRect; }
		}

		#endregion

		#region Item Fields and Properties

		private ItemManager _itemManager = new ItemManager();

		#endregion

		#region Level Fields and Properties

		private readonly List<Level> _levels = new List<Level>();
		private Level _currentLevel;

		public Level CurrentLevel
		{
			get { return _currentLevel; }
		}

		#endregion

		#region Constructors

		public World(Microsoft.Xna.Framework.Game game, Rectangle screenRectangle) : base(game)
		{
			_screenRect = screenRectangle;
		}

		#endregion

		#region Methods

		public override void Update(GameTime gameTime)
		{
			
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);
		}

		public void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
		{
			_currentLevel.Draw(gameTime, spriteBatch, camera);
		}

		public Level CreateLevel(string name, Map map)
		{
			Level level = _levels.FirstOrDefault(l => l.Name == name);
			if (level != null)
				return level;
			level = new Level(name, map);
			_levels.Add(level);
			return level;
		}

		public void ChangeLevel(string name)
		{
			Level level = _levels.FirstOrDefault(l => l.Name == name);
			if (level != null)
			{
				Console.WriteLine("World CHANGED LEVEL TO: " + level.Name);
				_currentLevel = level;
			}
			else
			{
				Console.WriteLine("WARNING: ChangeLevel -> NULL LEVEL: " + name);
			}
		}

		public Level GetLevel(string name)
		{
			return _levels.FirstOrDefault(l => l.Name == name);
		}

		#endregion
	}
}
