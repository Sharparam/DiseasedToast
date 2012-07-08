using System;

namespace F16Gaming.Game.RPGLibrary.Audio
{
	public class FMODException : Exception
	{
		private readonly FMOD.RESULT? _result;

		public FMOD.RESULT? Result { get { return _result; } }

		internal FMODException(string message) : this(null, message)
		{ }

		internal FMODException(string message, Exception innerException) : this(null, message, innerException)
		{ }

		internal FMODException(FMOD.RESULT? result, string message, Exception innerException = null) : base(message, innerException)
		{
			_result = result;
		}
	}
}
