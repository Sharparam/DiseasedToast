using F16Gaming.Game.RPGLibrary.Entities;
using F16Gaming.Game.RPGLibrary.Items;
using F16Gaming.Game.RPGLibrary.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Characters
{
	public class Character
	{
		#region Fields
		#endregion Fields

		#region Properties

		public Entity Entity { get; protected set; }
		public AnimatedSprite Sprite { get; protected set; }

		// Armor properties

		public GameItem Head { get; protected set; }
		public GameItem Body { get; protected set; }
		public GameItem Hands { get; protected set; }
		public GameItem Feet { get; protected set; }

		// Weapon/Shield properties

		public GameItem MainHand { get; protected set; }
		public GameItem OffHand { get; protected set; }

		public int FreeHands { get; protected set; }

		#endregion Properties

		#region Constructors

		public Character(Entity entity, AnimatedSprite sprite)
		{
			Entity = entity;
			Sprite = sprite;
		}

		#endregion Constructors

		#region Abstract and Virtual Methods

		public virtual void Update(GameTime gameTime)
		{
			Entity.Update(gameTime.ElapsedGameTime);
			Sprite.Update(gameTime);
		}

		public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			Sprite.Draw(gameTime, spriteBatch);
		}

		public virtual bool Equip(GameItem item)
		{
			bool success = false;

			return success;
		}

		public virtual bool Unequip(GameItem item)
		{
			bool success = false;

			return success;
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
