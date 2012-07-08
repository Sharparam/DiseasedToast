using System.Collections.Generic;
using F16Gaming.Game.RPGLibrary.Entities;
using F16Gaming.Game.RPGLibrary.Quests;
using F16Gaming.Game.RPGLibrary.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace F16Gaming.Game.RPGLibrary.Characters
{
	public class NonPlayerCharacter : Character
	{
		#region Fields

		private readonly List<Conversation.Conversation> _conversations;
		private readonly List<Quest> _quests;

		#endregion Fields

		#region Properties

		public List<Conversation.Conversation> Conversations
		{
			get { return _conversations; }
		}

		public List<Quest> Quests
		{
			get { return _quests; }
		}

		public bool HasConversation
		{
			get { return _conversations.Count > 0; }
		}

		public bool HasQuest
		{
			get { return _quests.Count > 0; }
		}

		#endregion Properties

		#region Constructors

		public NonPlayerCharacter(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
		{
			_conversations = new List<Conversation.Conversation>();
			_quests = new List<Quest>();
		}

		#endregion Constructors

		#region Abstract and Virtual Methods

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
		{
			base.Draw(gameTime, spriteBatch);
		}

		#endregion

		#region Methods
		#endregion Methods
	}
}
