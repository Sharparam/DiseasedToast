using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Characters;
using F16Gaming.Game.RPGLibrary.Engine;
using F16Gaming.Game.RPGLibrary.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using F16Gaming.Game.RPGLibrary.Engine.Mapping;

namespace F16Gaming.Game.RPGLibrary.World
{
	public class Level
	{
		#region Fields

		private readonly string _name;
		private readonly Map _map;
		private readonly List<Character> _characters;
		private readonly List<ItemSprite> _containers; 

		#endregion

		#region Properties

		public string Name
		{
			get { return _name; }
		}

		public Map Map
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

		internal Level(string name, Map map)
		{
			_name = name;
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
