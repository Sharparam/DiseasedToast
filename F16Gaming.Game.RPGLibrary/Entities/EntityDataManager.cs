using System.Collections.Generic;

namespace F16Gaming.Game.RPGLibrary.Entities
{
	public class EntityDataManager
	{
		#region Fields

		private readonly Dictionary<string, EntityData> _entityData = new Dictionary<string, EntityData>();

		#endregion

		#region Properties

		public Dictionary<string, EntityData> EntityData
		{
			get { return _entityData; }
		}

		#endregion

		#region Constructors
		#endregion

		#region Methods
		#endregion
	}
}
