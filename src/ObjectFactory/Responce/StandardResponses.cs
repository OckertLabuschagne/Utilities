using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEFI.Models
{
	public static class StandardResponses
	{
		public static ResponseMessage ForbiddenError
		{
			get => new ResponseMessage
			{
				Code = "500",
				Type = "Error",
				Message = "You do not have the necessary permission for this operation."
			};
		}
		public static ResponseMessage NullNotAllowedError
		{
			get => new ResponseMessage
			{
				Code = "400",
				Type = "Error",
				Message = "The object cannot be null."
			};
		}

		public static ResponseMessage GetObjectCannotBeNullError(string objectName)
		{
			return new ResponseMessage
			{
				Code = "400",
				Type = "Error",
				Message = $"The {objectName} cannot be null."
			};
		}
	}
}
