using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Drawing;

using i = SEFI.Infrastructure.Common.Interfaces;
using SEFI.Infrastructure.Common.Enums;
using System.Data.Common;

namespace SEFI.Infrastructure.Common.DataUtilities
{
    public class SQLServer
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

        public static DbType GetDbType(string dbType)
        {
            Dictionary<string, DbType> map = new Dictionary<string, DbType>()
            {
                { "nvarchar", DbType.AnsiString},
                { "nchar", DbType.AnsiStringFixedLength},
                { "varchar", DbType.String},
                { "char", DbType.StringFixedLength},
                { "binary", DbType.Binary},
                { "bit", DbType.Boolean},
                { "byte", DbType.Byte},
                { "money", DbType.Currency},
                { "date", DbType.Date},
                { "datetime", DbType.DateTime},
                { "smalldatetime", DbType.DateTime },
                { "datetime2", DbType.DateTime2 },
                { "datetimeoffset", DbType.DateTimeOffset},
                { "decimal", DbType.Decimal},
                { "double", DbType.Double},
                { "uniqueidentifier", DbType.Guid},
                { "smallint", DbType.Int16},
                { "int", DbType.Int32},
                { "bigint", DbType.Int64},
                { "variant", DbType.Object},
                { "sbyte", DbType.SByte},
                { "single", DbType.Single},
                { "timestamp", DbType.Time},
                { "ubyte", DbType.UInt16},
                { "uint", DbType.UInt32},
                { "ubigint", DbType.UInt64},
                { "numeric", DbType.VarNumeric},
                { "image", DbType.Object},
                { "xml", DbType.Xml},
                {"ntext", DbType.AnsiString }
            };

            return map[dbType.ToLower()];
        }

        public static DbType GetDbType(Type type)
        {
            Dictionary<Type, DbType> map = new Dictionary<Type, DbType>()
            {
                { typeof(string), DbType.String},
                { typeof(DateTime), DbType.DateTime},
                { typeof(int), DbType.Int32},
                { typeof(decimal), DbType.Decimal},
                { typeof(bool), DbType.Boolean},
            };

            return map[type];
        }

        public static Type GetType(SqlDbType dbType)
        {
            Dictionary<SqlDbType, Type> map = new Dictionary<SqlDbType, Type>()
            {
                { SqlDbType.NVarChar, typeof(string) },
                { SqlDbType.NChar, typeof(string) },
                { SqlDbType.VarBinary, typeof(byte[]) },
                { SqlDbType.Bit, typeof(bool) },
                { SqlDbType.TinyInt, typeof(byte) },
                { SqlDbType.Money, typeof(decimal) },
                { SqlDbType.Date , typeof(DateTime) },
                { SqlDbType.DateTime, typeof(DateTime) },
                { SqlDbType.DateTime2, typeof(DateTime) },
                { SqlDbType.DateTimeOffset, typeof(DateTimeOffset) },
                { SqlDbType.Decimal, typeof(decimal) },
                { SqlDbType.Float, typeof(float) },
                { SqlDbType.UniqueIdentifier, typeof(Guid) },
                { SqlDbType.SmallInt, typeof(Int16) },
                { SqlDbType.Int, typeof(int) },
                { SqlDbType.BigInt, typeof(Int64) },
                { SqlDbType.Variant, typeof(object) },
                { SqlDbType.TinyInt, typeof(byte) },
                { SqlDbType.VarChar, typeof(string) },
                { SqlDbType.Char, typeof(string) },
                { SqlDbType.Time, typeof(DateTime) }
            };

            return map[dbType];
        }

        public static Type GetType(string dbType)
        {
            Dictionary<string, Type> map = new Dictionary<string, Type>()
            {
                {"image", typeof(Image) },
                {"nvarchar", typeof(string) },
                {"nchar", typeof(string) },
                {"varbinary", typeof(byte[]) },
                {"bit", typeof(bool) },
                {"numeric", typeof(decimal) },
                {"tinyint", typeof(byte) },
                {"money", typeof(decimal) },
                {"date", typeof(DateTime) },
                {"smalldatetime", typeof(DateTime) },
                {"datetime", typeof(DateTime) },
                {"datetime2", typeof(DateTime) },
                {"datetimeoffset", typeof(DateTimeOffset) },
                {"decimal", typeof(decimal) },
                {"float", typeof(float) },
                {"uniqueidentifier", typeof(Guid) },
                {"smallint", typeof(Int16) },
                {"int", typeof(int) },
                {"bigint", typeof(Int64) },
                {"variant", typeof(object) },
                {"varchar", typeof(string) },
                {"char", typeof(string) },
                {"time", typeof(DateTime) },
                {"timestamp", typeof(DateTime) },
                {"ntext", typeof(string) }
            };

            return map[dbType.ToLower()];
        }

        public static SqlDbType GetSQLDbType(Type type)
        {
            Dictionary<Type, SqlDbType> map = new Dictionary<Type, SqlDbType>()
            {
                { typeof(string), SqlDbType.NVarChar },
                { typeof(bool), SqlDbType.Bit },
                { typeof(Byte), SqlDbType.TinyInt },
                { typeof(DateTime), SqlDbType.DateTime },
                { typeof(Decimal), SqlDbType.Decimal },
                { typeof(Double), SqlDbType.Float },
                { typeof(Guid), SqlDbType.UniqueIdentifier },
                { typeof(Int16), SqlDbType.SmallInt },
                { typeof(Int32), SqlDbType.Int },
                { typeof(Int64), SqlDbType.BigInt },
                { typeof(SByte), SqlDbType.TinyInt },
                { typeof(Single), SqlDbType.Float },
                { typeof(UInt16), SqlDbType.SmallInt },
                { typeof(UInt32), SqlDbType.Int },
                { typeof(UInt64), SqlDbType.BigInt },
            };

            return map[type];
        }

        public static string GetTypeString(PropertyMap map)
        {
            switch (map.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return $"{Enum.GetName(typeof(SqlDbType), GetSQLDbType(map.DbType)).ToUpper()}({map.FieldLength})";
                default:
                    return Enum.GetName(typeof(SqlDbType), GetSQLDbType(map.DbType)).ToUpper();
            }
        }

        public static IDbDataParameter[] GetParameters(i.IFilter filter)
        {
            List<IDbDataParameter> retVal = new List<IDbDataParameter>();
            if (filter is i.IFilters)
            {
                foreach (KeyValuePair<i.IFilter, LogicOperator> f in (filter as i.IFilters).FilterList)
                    retVal.AddRange(GetParameters(f.Key));
            }
            else
            {
                SqlParameter param;
                switch (filter.Operator)
                {
                    case ComparisonOperator.Between:
                        Array vals = filter.Value.Value as Array;
                        param = new SqlParameter($"@{filter.FieldName}_Val1", vals.GetValue(0));
                        retVal.Add(param);
                        param = new SqlParameter($"@{filter.FieldName}_Val2", vals.GetValue(1));
                        retVal.Add(param);
                        break;
                    case ComparisonOperator.Equal:
                    case ComparisonOperator.NotEqual:
                    case ComparisonOperator.GreaterThan:
                    case ComparisonOperator.GreaterThanOrEqual:
                    case ComparisonOperator.SmallerThan:
                    case ComparisonOperator.SmallerThanOrEqual:
                    case ComparisonOperator.Like:
                        param = new SqlParameter($"@{filter.FieldName}", filter.Value.Value);
                        retVal.Add(param);
                        break;
                    case ComparisonOperator.In:
                        Array values = filter.Value.Value as Array;
                        for (int i = 0; i < values.Length; i++)
                        {
                            param = new SqlParameter($"@{filter.FieldName}_Val{i}", values.GetValue(i));
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

        public static IDbDataParameter[] GetParameters(object value, ObjectPropertyMap map, bool includeNull = false)
        {
            List<IDbDataParameter> retVal = new List<IDbDataParameter>();
            Type valueType = value.GetType();
            foreach (PropertyMap pMap in map.PropertyMaps)
            {
                object pVal = GetValue(value, pMap.PropertyName);
                if (pVal != null)
                {
                    SqlParameter param = new SqlParameter($"@{pMap.FieldName}", pVal);
                    retVal.Add(param);
                }
                if (includeNull)
                {
                    SqlParameter param = new SqlParameter($"@{pMap.FieldName}", DBNull.Value);
                    retVal.Add(param);
                }
            }
            return retVal.ToArray();
        }

        public static string GetParameterizedWhere(i.IFilter filter)
        {
            return $"WHERE({GetParameterizedWhereClauses(filter)})";
        }

        public static string GetValuesParameterNameString(ObjectPropertyMap map)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(",");
                retVal.Append($"@{pmap.FieldName}");
            }
            return retVal.ToString();
        }

        public static string GetValuesParameterDeclareString(object value, ObjectPropertyMap map)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(",");
                retVal.Append($"@{pmap.FieldName} {GetTypeString(pmap)} = {1}");
            }
            return retVal.ToString();
        }

        public static string GetJoinString(ObjectPropertyMap map)
        {
            StringBuilder retVal = new StringBuilder();
            List<PropertyMap> joinMaps = map.PropertyMaps.Where(m => m.Join != null).ToList();
            foreach (PropertyMap pMap in joinMaps)
            {
                retVal.AppendLine(GetJoinString(map.DatabaseObject, pMap.Join));
            }
            return retVal.ToString();
        }

        public static string GetJoinString(string tableName, Join join)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.Append($"{Enum.GetName(typeof(SQLJoinTypes), join.JoinType)} JOIN {join.TableName} ON ");
            bool isFirst = true;
            foreach (JoinField field in join.JoinFields)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(" AND ");
                retVal.Append($"{tableName}.{field.FieldName} = {join.TableName}.{field.ForeignFieldName}");
            }
            return retVal.ToString();
        }

        public static string GetUpsertSQL(object value, ObjectPropertyMap map)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine($"IF EXISTS (SELECT {map.KeyFieldList} FROM {map.DatabaseObject} {GetParameterizedWhere(map.GetKeyFilters(value))})");
            retVal.AppendLine($"UPDATE {map.DatabaseObject} SET");
            Type valueType = value.GetType();
            //Get the value for each non key property
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps.Where(m => !m.IsPartOfKey).ToList())
            {
                object pVal = GetValue(value, pmap.PropertyName);
                //If the value is not null
                if (pVal != null)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.AppendLine(",");
                    retVal.Append($"{pmap.FieldName} = @{pmap.FieldName}");
                }
                //Add a set clause
            }
            retVal.AppendLine();
            retVal.AppendLine(GetParameterizedWhere(map.GetKeyFilters(value)));
            retVal.AppendLine("ELSE");
            retVal.AppendLine($"INSERT INTO {map.DatabaseObject} ({GetFieldList(value, map)})");
            retVal.AppendLine($"VALUES ({GetValuesParamList(value, map)})");
            return retVal.ToString();
        }

        public static string GetParameterizedWhereClauses(i.IFilter filter)
        {
            StringBuilder retVal = new StringBuilder();
            if (filter is i.IFilters)
            {
                foreach (KeyValuePair<i.IFilter, LogicOperator> f in (filter as i.IFilters).FilterList)
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
                string paramName = filter.FieldName.Contains('.') ?
                    filter.FieldName.Split('.').Last().Trim('[', ']') :
                    filter.FieldName.Trim('[', ']');

                switch (filter.Operator)
                {
                    case ComparisonOperator.Between:
                        retVal.Append($"{filter.FieldName} BETWEEN @{filter.FieldName}_Val1 AND @{paramName}_Val2");
                        break;
                    case ComparisonOperator.Equal:
                        retVal.Append($"{filter.FieldName} = @{paramName}");
                        break;
                    case ComparisonOperator.GreaterThan:
                        retVal.Append($"{filter.FieldName} > @{paramName}");
                        break;
                    case ComparisonOperator.GreaterThanOrEqual:
                        retVal.Append($"{filter.FieldName} >= @{paramName}");
                        break;
                    case ComparisonOperator.In:
                        retVal.Append($"{filter.FieldName} IN (");
                        for (int i = 0; i < filter.Value.Values.Length; i++)
                        {
                            retVal.Append($"@{paramName}_Val{i + 1}");
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
                        retVal.Append($"{filter.FieldName} LIKE (@{paramName})");
                        break;
                    case ComparisonOperator.NotEqual:
                        retVal.Append($"{filter.FieldName} <> @{paramName}");
                        break;
                    case ComparisonOperator.SmallerThan:
                        retVal.Append($"{filter.FieldName} < @{paramName}");
                        break;
                    case ComparisonOperator.SmallerThanOrEqual:
                        retVal.Append($"{filter.FieldName} <= @{paramName}");
                        break;
                }
            }
            return retVal.ToString();
        }

        public static IDataReader GetData(IDbConnection connection, ObjectPropertyMap map, i.IFilter filters = null)
        {
            IDataReader retVal = null;
            if (connection.State != ConnectionState.Open)
                connection.Open();
            IDbCommand command = connection.CreateCommand();
            if (filters != null)
            {
                IDbDataParameter[] parameters = GetParameters(filters);
                if (map.IsStoredProcedure)
                {
                    command.CommandText = map.DatabaseObject;
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (IDbDataParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                    retVal = command.ExecuteReader();
                }
                else
                {
                    command.CommandText = $"SELECT {map.FieldList}\nFROM {map.DatabaseObject}\n{GetJoinString(map)}\n{GetParameterizedWhere(filters)}";
                    command.CommandType = CommandType.Text;
                    foreach (IDbDataParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                    retVal = command.ExecuteReader();
                }
            }
            else
            {
                if (map.IsStoredProcedure)
                {
                    command.CommandText = map.DatabaseObject;
                    command.CommandType = CommandType.StoredProcedure;
                    retVal = command.ExecuteReader();
                }
                else
                {
                    command.CommandText = $"SELECT {map.FieldList}\nFROM {map.DatabaseObject}\n{GetJoinString(map)}";
                    command.CommandType = CommandType.Text;
                    retVal = command.ExecuteReader();
                }
            }
            return retVal;
        }

        private static object GetValue(object value, string propertyName)
        {
            if (value == null)
                return null;
            Type valueType = value.GetType();
            if (propertyName.Contains('.'))
            {
                string[] parts = propertyName.Split('.');
                PropertyInfo property = valueType.GetProperty(parts.First());
                if (property != null)
                {
                    object val = property.GetValue(value, null);
                    return GetValue(val, propertyName.Replace($"{parts.First()}.", ""));
                }
                throw new InvalidExpressionException($"{valueType.FullName} does not contain a property named {parts.First()}");
            }
            else
            {
                PropertyInfo property = valueType.GetProperty(propertyName);
                if (property != null)
                    return property.GetValue(value, null);
                throw new InvalidExpressionException($"{valueType.FullName} does not contain a property named {propertyName}");
            }
        }

        private static string GetFieldList(object value, ObjectPropertyMap map, bool includeNulls = false)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps.Where(m => !m.IsPartOfKey).ToList())
            {
                object pVal = GetValue(value, pmap.PropertyName);
                //If the value is not null
                if (pVal != null)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.AppendLine(",");
                    retVal.Append(pmap.FieldName);
                }
                //Add a set clause
            }
            return retVal.ToString();
        }

        private static string GetValuesParamList(object value, ObjectPropertyMap map, bool includeNulls = false)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps.Where(m => !m.IsPartOfKey).ToList())
            {
                object pVal = GetValue(value, pmap.PropertyName);
                //If the value is not null
                if (pVal != null)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.AppendLine(",");
                    retVal.Append($"@{pmap.FieldName}");
                }
                //Add a set clause
            }
            return retVal.ToString();
        }

        public static string GetValueList(object value, ObjectPropertyMap map)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                object pVal = GetValue(value, pmap.PropertyName);
                if (isFirst)
                    isFirst = false;
                else
                    retVal.AppendLine(",");
                retVal.Append(GetSQLSaveString(pVal, pmap));
            }
            return retVal.ToString();
        }

        public static List<T> ParseValueString<T>(string valuesString, ObjectPropertyMap map)
        {
            List<T> values = new List<T>();
            StringBuilder valString = new StringBuilder();
            for (int i = 0; i < valuesString.Length; i++)
            {
                switch (valuesString[i])
                {
                    case '(':

                        break;
                    case ')': //Ignore if it is the last character
                        break;
                }
            }
            return values;
        }

        public static object[] ParseValueString(string valueString, ObjectPropertyMap map)
        {
            List<object> values = new List<object>();
            int objectIndex = 0;
            PropertyMap pmap = map.PropertyMaps[objectIndex];
            StringBuilder valString = new StringBuilder();
            bool betweenQuotes = false;
            for (int i = 0; i < valueString.Length; i++)
            {
                switch (valueString[i])
                {
                    case '(':
                        if (i > 0) //Ignore if it the first character
                            valString.Append(valueString[i]);
                        break;
                    case ')': //Ignore if it is the last character
                        if (i < valueString.Length - 1)
                            valString.Append(valueString[i]);
                        break;
                    case '\'': //Handle quotation marks
                        if (betweenQuotes && valueString[i + 1] == ',') // end of quoted value
                        {
                            betweenQuotes = false;
                        }
                        else if (!betweenQuotes)
                            betweenQuotes = true;
                        else if (valueString[i + 1] == '\'') //escaped quotation character
                        {
                            valString.Append("'");
                        }
                        break;
                    case ',':
                        if (betweenQuotes)
                        {
                            valString.Append(valueString[i]);
                        }
                        else //End of field
                        {
                            //Parse the value string
                            object value = Convert.ChangeType(valString.ToString(), GetType(GetSQLDbType(pmap.DbType)));
                            //Add the object to the return list
                            values.Add(value);
                            objectIndex++;
                            pmap = map.PropertyMaps[objectIndex];
                            valString.Clear();
                        }
                        break;
                    case '\n':
                    case '\r':
                        if (betweenQuotes)
                            valString.Append(valueString[i]);
                        break;
                    default:
                        valString.Append(valueString[i]);
                        break;
                }
                if (i == valueString.Length - 1) //end of record
                {
                    object value = Convert.ChangeType(valString.ToString(), GetType(GetSQLDbType(pmap.DbType)));
                    //Add the object to the return list
                    values.Add(value);
                }
            }
            return values.ToArray();
        }

        public static void SaveData(object value, IDbConnection connection, ObjectPropertyMap map)
        {
            IDbCommand command = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command = connection.CreateCommand();
                command.CommandText = GetUpsertSQL(value, map);
                command.CommandType = CommandType.Text;
                IDbDataParameter[] parameters = GetParameters(value, map);
                foreach (IDbDataParameter p in parameters)
                    command.Parameters.Add(p);
                command.ExecuteNonQuery();
            }
            catch (Exception excp)
            {
                if (command != null)
                    throw new Exception($"{command.CommandText}\nParameters :{command.Parameters.Count}\nInner Exception {excp.Message}", excp);
                else
                    throw excp;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
            }
        }

        public static Dictionary<string, DbType> GetSPParameters(IDbConnection connection, string spName)
        {
            Dictionary<string, DbType> retval = new Dictionary<string, DbType>();
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = $@"SELECT SCHEMA_NAME(SCHEMA_ID) AS[Schema]
    , SO.name AS[ObjectName]
    , SO.Type_Desc AS[ObjectType(UDF / SP)]
    , P.parameter_id AS[ParameterID]
    , P.name AS[ParameterName]
    , TYPE_NAME(P.user_type_id) AS[ParameterDataType]
    , P.max_length AS[ParameterMaxBytes]
    , P.is_output AS[IsOutPutParameter]
FROM sys.objects AS SO
INNER JOIN sys.parameters AS P ON SO.OBJECT_ID = P.OBJECT_ID
WHERE SO.name = '{spName}'";
                command.CommandType = CommandType.Text;
                IDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    retval.Add(reader.GetString(4),GetDbType(reader.GetString(5)));
                }
            }
            return retval;
        }

        public static DataTable GetSPSchema(IDbConnection connection, string spName, Dictionary<string, object> parameterValues, out IDataReader reader)
        {
            List<IDataParameter> parameters = new List<IDataParameter>();
            //get the parameters
            try
            {
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = $@"SELECT SCHEMA_NAME(SCHEMA_ID) AS[Schema]
    , SO.name AS[ObjectName]
    , SO.Type_Desc AS[ObjectType(UDF / SP)]
    , P.parameter_id AS[ParameterID]
    , P.name AS[ParameterName]
    , TYPE_NAME(P.user_type_id) AS[ParameterDataType]
    , P.max_length AS[ParameterMaxBytes]
    , P.is_output AS[IsOutPutParameter]
FROM sys.objects AS SO
INNER JOIN sys.parameters AS P ON SO.OBJECT_ID = P.OBJECT_ID
WHERE SO.name = '{spName}'";
                    command.CommandType = CommandType.Text;
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        IDataParameter parameter = new SqlParameter();
                        parameter.ParameterName = reader.GetString(4);
                        DbType dbType = GetDbType(reader.GetString(5));
                        parameter.DbType = dbType;
                        parameter.Value = parameterValues[parameter.ParameterName];
                        parameters.Add(parameter);
                    }
                }
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = spName;
                    command.CommandType = CommandType.StoredProcedure;
                    foreach (IDataParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                    reader = command.ExecuteReader();
                    return reader.GetSchemaTable();
                }
            }
            catch (Exception ex)
            {
                reader = null;
            }
            return null;
        }

        public static string GetSQLSaveString(object value, PropertyMap map)
        {
            if (value == null)
                return "NULL";
            if (value is DBNull)
                return "NULL";
            switch (map.DbType)
            {
                case DbType.Date:
                case DbType.DateTime:
                case DbType.DateTime2:
                    return $"'{value:yyyy-MM-dd HH:mm:ss}'";
                case DbType.Boolean:
                    return ((bool)value) ? "1" : "0";
                case DbType.Guid:
                    return $"'{value}'";
                case DbType.String:
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.StringFixedLength:
                    return $"'{value.ToString().Replace("'", "''")}'";
                default:
                    return $"{value}";
            }
        }
    }
}
