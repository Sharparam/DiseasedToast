using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary.Items;
using XRpgLibrary.Characters;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.World
{
	public class Level
	{
		#region Fields

		private readonly TileMap _map;
		private readonly List<Character> _characters;
		private readonly List<ItemSprite> _containers; 

		#endregion

		#region Properties

		public TileMap Map
		{
			get { return _map; }
		}

		public List<Character> Characters
		{
			get { return _characters; }
		}

		public List<ItemSprite> Containers
		{
			get { return _containers; }
		}

		#endregion

		#region Constructors

		public Level(TileMap map)
		{
			_map = map;
			_characters = new List<Character>();
			_containers = new List<ItemSprite>();
		}

		#endregion

		#region Methods

		public void Update(GameTime gameTime)
		{
			foreach (var c in _characters)
				c.Update(gameTime);

			foreach (var s in _containers)
				s.Update(gameTime);
		}

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
		{
			_map.Draw(spriteBatch, camera);

			foreach (var c in _characters)
				c.Draw(gameTime, spriteBatch);

			foreach (var s in _containers)
				s.Draw(gameTime, spriteBatch);
		}

		#endregion
	}
}
