using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace SEFI.Infrastructure.Common.DataUtilities
{
	public class Helpers
	{
		private static Dictionary<Type, DbType> TypeMap = new Dictionary<Type, DbType>
		{
			{ typeof(bool), DbType.Boolean },
			{ typeof(string), DbType.String },
			{ typeof(DateTime), DbType.DateTime },
			{ typeof(decimal), DbType.Decimal },
			{ typeof(double), DbType.Double },
			{ typeof(Int16), DbType.Int16 },
			{ typeof(Int32), DbType.Int32 },
			{ typeof(Int64), DbType.Int64 },
			{ typeof(UInt16), DbType.UInt16 },
			{ typeof(UInt32), DbType.UInt32 },
			{ typeof(UInt64), DbType.UInt64 },
			{ typeof(Single), DbType.Single },
			{ typeof(Byte), DbType.Byte } ,
			{ typeof(Guid), DbType.Guid } ,
		};

		public static DbType GetDbType(Type type)
		{
			if (TypeMap.ContainsKey(type))
				return TypeMap[type];
			else
				throw new InvalidCastException($"connot map {type.FullName} to a BbType");
		}
	}
}
