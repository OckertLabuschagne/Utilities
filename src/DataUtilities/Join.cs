using System;
using System.Collections.Generic;
using System.Text;

using SEFI.Infrastructure.Common.Enums;
namespace SEFI.Infrastructure.Common.DataUtilities
{
	public class Join
	{
		public string TableName { get; set; }
		public List<JoinField> JoinFields { get; set; }
		public SQLJoinTypes JoinType { get; set; }
	}
}
