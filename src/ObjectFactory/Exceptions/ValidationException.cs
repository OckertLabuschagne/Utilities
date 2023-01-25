using System;
using System.Collections.Generic;
using System.Linq;

namespace SEFI.Exceptions
{
	[Serializable]
	public class ValidationException : Exception
	{
		public ValidationException()
			: base("One or more validation failures have occurred.") { }

		public ValidationException(string message) : base(message) { }

		public ValidationException(string message, Exception inner) : base(message, inner) { }

		protected ValidationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

		public IDictionary<string, string[]> Failures { get; } = new Dictionary<string, string[]>();
	}
}
