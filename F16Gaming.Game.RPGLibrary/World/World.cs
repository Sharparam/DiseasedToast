using System;
using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Items;
using F16Gaming.Game.RPGLibrary.TileEngine;
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
		private int _currentLevel = -1;

		public List<Level> Levels
		{
			get { return _levels; }
		}

		public int CurrentLevel
		{
			get { return _currentLevel; }
			set
			{
				if (value < 0 || value >= _levels.Count)
					throw new IndexOutOfRangeException("Level index out of range!");

				if (_levels[value] == null)
					throw new NullReferenceException("Tried to set current level to NULL level!");

				_currentLevel = value;
			}
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
			_levels[_currentLevel].Draw(gameTime, spriteBatch, camera);
		}

		#endregion
	}
}
