using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Conversation;
using RpgLibrary.Entities;
using RpgLibrary.Quests;
using XRpgLibrary.Sprites;

namespace XRpgLibrary.Characters
{
	public class NonPlayerCharacter : Character
	{
		#region Fields

		private readonly List<Conversation> _conversations;
		private readonly List<Quest> _quests;

		#endregion Fields

		#region Properties

		public List<Conversation> Conversations
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
			_conversations = new List<Conversation>();
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
