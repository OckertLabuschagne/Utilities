using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace SEFI.DataUtilities
{
    public class Helpers
    {
        private static readonly Dictionary<Type, DbType> TypeMap = new Dictionary<Type, DbType>
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
            Type t = Nullable.GetUnderlyingType(type) ?? type;
            if (t.IsEnum)
                return DbType.Int32;
            else if (TypeMap.ContainsKey(t))
                return TypeMap[t];
            else
                throw new InvalidCastException($"Cannot map {t.FullName} to a DbType");
        }

        public static Type GetType(DbType type)
        {
            Dictionary<DbType, Type> map = new Dictionary<DbType, Type>
            {
                { DbType.AnsiString, typeof(string)}
                ,{ DbType.AnsiStringFixedLength, typeof(string)}
                ,{ DbType.Binary, typeof(object)}
                ,{ DbType.Boolean, typeof(bool)}
                ,{ DbType.Byte, typeof(byte)}
                ,{ DbType.Currency, typeof(decimal)}
                ,{ DbType.Date, typeof(DateTime)}
                ,{ DbType.DateTime, typeof(DateTime)}
                ,{ DbType.DateTime2, typeof(DateTime)}
                ,{ DbType.Decimal, typeof(decimal)}
                ,{ DbType.Double, typeof(double)}
                ,{ DbType.Guid, typeof(Guid)}
                ,{ DbType.Int16, typeof(Int16)}
                ,{ DbType.Int32, typeof(Int32)}
                ,{ DbType.Int64, typeof(Int64)}
                ,{ DbType.String, typeof(string)}
                ,{ DbType.StringFixedLength, typeof(string)}
                ,{ DbType.Time, typeof(DateTime)}
                ,{ DbType.UInt16, typeof(UInt16)}
                ,{ DbType.UInt32, typeof(UInt32)}
                ,{ DbType.UInt64, typeof(UInt64)}
                ,{ DbType.VarNumeric, typeof(decimal)}
            };
            return map[type];
        }
   }
}
