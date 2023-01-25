using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

using ip = SEFI.Infrastructure.Common.Interfaces;
using SEFI.Infrastructure.Common.Enums;
using SEFI.Infrastructure.Common.DataUtilities;
namespace SEFI.Infrastructure.Common.Persistence
{
    public class SQLServerUtilities
    {
        public static SqlDbType GetSQLDbType(DbType dbType)
        {
            Dictionary<DbType, SqlDbType> map = new Dictionary<DbType, SqlDbType>()
            {
                { DbType.AnsiString, SqlDbType.NVarChar },
                { DbType.AnsiStringFixedLength, SqlDbType.NChar },
                { DbType.Binary, SqlDbType.VarBinary },
                { DbType.Boolean, SqlDbType.Bit },
                { DbType.Byte, SqlDbType.TinyInt },
                { DbType.Currency, SqlDbType.Money },
                { DbType.Date, SqlDbType.Date },
                { DbType.DateTime, SqlDbType.DateTime },
                { DbType.DateTime2, SqlDbType.DateTime2 },
                { DbType.DateTimeOffset, SqlDbType.DateTimeOffset },
                { DbType.Decimal, SqlDbType.Decimal },
                { DbType.Double, SqlDbType.Float },
                { DbType.Guid, SqlDbType.UniqueIdentifier },
                { DbType.Int16, SqlDbType.SmallInt },
                { DbType.Int32, SqlDbType.Int },
                { DbType.Int64, SqlDbType.BigInt },
                { DbType.Object, SqlDbType.Variant },
                { DbType.SByte, SqlDbType.TinyInt },
                { DbType.Single, SqlDbType.Float },
                { DbType.String, SqlDbType.VarChar },
                { DbType.StringFixedLength, SqlDbType.Char },
                { DbType.Time, SqlDbType.Time },
                { DbType.UInt16, SqlDbType.SmallInt },
                { DbType.UInt32, SqlDbType.Int },
                { DbType.UInt64, SqlDbType.BigInt },
                { DbType.VarNumeric, SqlDbType.Decimal },
                { DbType.Xml, SqlDbType.Xml }
            };
            
            return map[dbType];
        }

        public static SqlParameter[] GetParameters(ip.IFilter filter)
        {
            List<SqlParameter> retVal = new List<SqlParameter>();
            if(filter is ip.IFilters)
            {
                foreach (KeyValuePair<ip.IFilter, LogicOperator> f in (filter as ip.IFilters).FilterList)
                    retVal.AddRange(GetParameters(f.Key));
            }
            else
            {
                SqlParameter param;
                switch (filter.Operator)
                {
                    case ComparisonOperator.Between:
                        Array vals = filter.Value.Value as Array;
                        param = new SqlParameter($"@{filter.Name}_Val1", vals.GetValue(0));
                        retVal.Add(param);
                        param = new SqlParameter($"@{filter.Name}_Val2", vals.GetValue(1));
                        retVal.Add(param);
                        break;
                    case ComparisonOperator.Equal:
                    case ComparisonOperator.NotEqual:
                    case ComparisonOperator.GreaterThan:
                    case ComparisonOperator.GreaterThanOrEqual:
                    case ComparisonOperator.SmallerThan:
                    case ComparisonOperator.SmallerThanOrEqual:
                    case ComparisonOperator.Like:
                        param = new SqlParameter($"@{filter.Name}", filter.Value.Value);
                        retVal.Add(param);
                        break;
                    case ComparisonOperator.In:
                        Array values = filter.Value.Value as Array;
                        for(int i = 0; i < values.Length; i++)
                        {
                            param = new SqlParameter($"@{filter.Name}_Val{i}", values.GetValue(i));
                            retVal.Add(param);
                        }
                        break;
                    case ComparisonOperator.IsNotNull:
                    case ComparisonOperator.IsNull:
                        break;
                }
            }
            return retVal.ToArray();
        }

        public static string GetParameterizedWhere(ip.IFilter filter)
        {
            return $"WHERE({GetParameterizedWhereClauses(filter)})";
        }

        public static string GetParameterizedWhereClauses(ip.IFilter filter)
        {
            StringBuilder retVal = new StringBuilder();
            if (filter is ip.IFilters)
            {
                foreach (KeyValuePair<ip.IFilter, LogicOperator> f in (filter as ip.IFilters).FilterList)
                {
                    if (f.Value != LogicOperator.Empty)
                    {
                        retVal.Append($" {Enum.GetName(typeof(LogicOperator), f.Value).ToUpper()} ");
                    }
                    retVal.Append($"({GetParameterizedWhereClauses(f.Key)})");
                }
            }
            else
            {
                switch (filter.Operator)
                {
                    case ComparisonOperator.Between:
                        retVal.Append($"{filter.FieldName} BETWEEN @{filter.Name}_Val1 AND @{filter.Name}_Val2");
                        break;
                    case ComparisonOperator.Equal:
                        retVal.Append($"{filter.FieldName} = @{filter.Name}");
                        break;
                    case ComparisonOperator.GreaterThan:
                        retVal.Append($"{filter.FieldName} > @{filter.Name}");
                        break;
                    case ComparisonOperator.GreaterThanOrEqual:
                        retVal.Append($"{filter.FieldName} >= @{filter.Name}");
                        break;
                    case ComparisonOperator.In:
                        retVal.Append($"{filter.FieldName} IN (");
                        for (int i = 0; i < filter.Value.Values.Length; i++)
                        {
                            retVal.Append($"{filter.Name}_Val{i + 1}");
                            if (i > 0)
                                retVal.Append(",");
                        } 
                        retVal.Append(")");
                        break;
                    case ComparisonOperator.IsNotNull:
                        retVal.Append($"{filter.FieldName} IS NULL");
                        break;
                    case ComparisonOperator.IsNull:
                        retVal.Append($"{filter.FieldName} IS NOT NULL");
                        break;
                    case ComparisonOperator.Like:
                        retVal.Append($"{filter.FieldName} LIKE (@{filter.Name})");
                        break;
                    case ComparisonOperator.NotEqual:
                        retVal.Append($"{filter.FieldName} <> @{filter.Name}");
                        break;
                    case ComparisonOperator.SmallerThan:
                        retVal.Append($"{filter.FieldName} < @{filter.Name}");
                        break;
                    case ComparisonOperator.SmallerThanOrEqual:
                        retVal.Append($"{filter.FieldName} <= @{filter.Name}");
                        break;
                }
            }
            return retVal.ToString();
        }

		public IDataReader GetData(SqlConnection connection, ip.IFilter filter)
		{
            return null;
		}

        public static string ScriptInsert<T>(T source, ObjectPropertyMap map, bool dropBeforeInsert = false, bool addIdentityInsert = false)
        {
            int recordCount = 0;
            StringBuilder script = new StringBuilder();
            if (dropBeforeInsert)
                script.AppendLine($"DELETE FROM {map.DatabaseObject}");
            if (addIdentityInsert)
                script.AppendLine($"SET IDENTITY_INSERT {map.DatabaseObject} ON");
            script.AppendLine($"INSERT INTO {map.DatabaseObject} ({map.InsertFieldList})");
            script.AppendLine("VALUES");
            if(source.GetType().IsGenericType)
            {
                MethodInfo toArrayMethod = source.GetType().GetMethod("ToArray", new Type[] { });
                Array sourceArray = (Array)toArrayMethod.Invoke(source, new object[] { });
                for (int i = 0; i < sourceArray.Length; i++)
                {
                    recordCount++;
                    object val = sourceArray.GetValue(i);
                    if(recordCount >= 1000)
                    {
                        script.AppendLine($"INSERT INTO {map.DatabaseObject} ({map.InsertFieldList})");
                        script.AppendLine("VALUES");
                        recordCount = 0;
                    }
                    else if (i > 0)
                        script.Append(",");
                    script.AppendLine($"({SQLServer.GetValueList(val, map)})");
                }
            }
            else if(source.GetType().IsArray)
            {
                Array sourceArray = (source as Array);
                for (int i = 0; i < sourceArray.Length; i++)
                {
                    recordCount++;
                    object val = sourceArray.GetValue(i);
                    if (recordCount >= 1000)
                    {
                        script.AppendLine($"INSERT INTO {map.DatabaseObject} ({map.InsertFieldList})");
                        script.AppendLine("VALUES");
                        recordCount = 0;
                    }
                    else if (i > 0)
                        script.Append(",");
                    script.AppendLine($"({SQLServer.GetValueList(val, map)})");
                }
            }
            else
            {
                script.AppendLine($"({SQLServer.GetValueList(source, map)})");
            }
            if (addIdentityInsert)
                script.Append($"SET IDENTITY_INSERT {map.DatabaseObject} OFF");
            return script.ToString();
        }
    }
}
