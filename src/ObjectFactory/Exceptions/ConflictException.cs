using System;

namespace SEFI.Exceptions
{
	[Serializable]
	public class ConflictException : ValidationException
	{
		public ConflictException() { }

		public ConflictException(string message) : base(message) { }

		public ConflictException(string message, Exception inner) : base(message, inner) { }

		protected ConflictException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
