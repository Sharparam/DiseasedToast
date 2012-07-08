using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Conversation
{
	public class ConversationManager
	{
		#region Fields

		private readonly Dictionary<string, Conversation> _conversations;

		#endregion Fields

		#region Properties

		public Dictionary<string, Conversation> Conversations
		{
			get { return _conversations; }
		}

		#endregion Properties

		#region Constructors

		public ConversationManager()
		{
			_conversations = new Dictionary<string, Conversation>();
		}

		#endregion Constructors

		#region Methods
		#endregion Methods
	}
}
