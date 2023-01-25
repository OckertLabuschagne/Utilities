using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

using i = SEFI.Interfaces;
using SEFI.Enums;
using SEFI.Mappings;
using SEFI.Exceptions;
namespace SEFI.DataUtilities
{
    public class SQLServer
    {
        /// <summary>
        /// Translate the Db Type to a Sql Db Type
        /// </summary>
        /// <param name="dbType">The Db Type to translate</param>
        /// <returns>The Sql Db Type</returns>
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

        /// <summary>
        /// Translate a system type to a Sql Db Type
        /// </summary>
        /// <param name="type">The system type to translate</param>
        /// <param name="forUnicode">A flag indicating whether the translation is for unicode characters (Default is true)</param>
        /// <returns>The Sql Db Type</returns>
		public static SqlDbType GetSQLDbType(Type type, bool forUnicode = true)
        {
            Dictionary<Type, SqlDbType> map = new Dictionary<Type, SqlDbType>()
            {
                { typeof(string), forUnicode ? SqlDbType.NVarChar : SqlDbType.VarChar },
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
            if (type.IsEnum)
                return SqlDbType.Int;
            return map[type];
        }

        /// <summary>
        /// Gets the string describing a data type in SQL script for a property map
        /// </summary>
        /// <param name="map">The property map to use</param>
        /// <returns>The string describing the type SQL script</returns>
		public static string GetTypeString(PropertyMap map)
        {
            switch (map.DbType)
            {
                case DbType.AnsiString:
                case DbType.AnsiStringFixedLength:
                case DbType.String:
                case DbType.StringFixedLength:
                    return $"{Enum.GetName(typeof(SqlDbType), GetSQLDbType(map.DbType.Value)).ToUpper()}({map.FieldLength})";
                default:
                    return Enum.GetName(typeof(SqlDbType), GetSQLDbType(map.DbType.Value)).ToUpper();
            }
        }

        /// <summary>
        /// Translate an object that implements the IFilter interfacet to an array of IDbDataParameter 
        /// </summary>
        /// <param name="filter">The IFilter object</param>
        /// <returns>The array of parameters</returns>
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
                    case ComparisonOperator.Contains:
                    case ComparisonOperator.StartsWith:
                    case ComparisonOperator.EndsWith:
                        param = new SqlParameter($"@{filter.FieldName}", filter.Value.Value);
                        retVal.Add(param);
                        break;
                    case ComparisonOperator.In:
                        Array values = filter.Value.Value as Array;
                        for (int i = 0; i < values.Length; i++)
                        {
                            param = new SqlParameter($"@{filter.FieldName}_Val{i + 1}", values.GetValue(i));
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

        /// <summary>
        /// Get an array of IDbDataParameter for the values mapped of an object
        /// </summary>
        /// <typeparam name="T">The type of the object that is passed</typeparam>
        /// <param name="value">The objects to be used for the parameter values</param>
        /// <param name="map">The object property map to use</param>
        /// <param name="includeNull">A flag indicating whether null value parameters should be included in the array</param>
        /// <returns>The array of parameters</returns>
		public static IDbDataParameter[] GetParameters<T>(object value, ObjectPropertyMap<T> map, bool includeNull = false)
        {
            List<IDbDataParameter> retVal = new List<IDbDataParameter>();
            foreach (PropertyMap pMap in map.PropertyMaps)
            {
                try
                {
                    object pVal = GetValue(value, pMap.PropertyName);
                    SqlParameter param = new SqlParameter { ParameterName = $"@{pMap.FieldName}", Value = pVal != null ? pVal : DBNull.Value };

                    if (pMap.SqlDbType.HasValue)
                    {
                        param.SqlDbType = pMap.SqlDbType.Value;
                    }
                    else
                    {
                        switch (pMap.DbType.Value)
                        {
                            case DbType.Date:
                            case DbType.DateTime:
                            case DbType.DateTime2:
                                if (pVal != null)
                                {
                                    if ((DateTime)pVal < new DateTime(1753, 1, 1))
                                    {
                                        if (pMap.IsNullable)
                                            pVal = null;
                                    }
                                }
                                break;
                        }
                        if (pVal != null)
                        {
                            param.DbType = Helpers.GetDbType(pVal.GetType());
                            param.SqlDbType = GetSQLDbType(pVal.GetType());
                        }
                        else if (includeNull && pMap.IsNullable)
                        {
                            param.DbType = pMap.DbType.Value;
                            param.SqlDbType = GetSQLDbType(pMap.DbType.Value);
                        }
                    }
                    retVal.Add(param);
                }
                catch (Exception excp)
                {
                    throw new Exception($"Error getting parameter for {pMap.FieldName}" ,excp);
                }
            }
            return retVal.ToArray();
        }

        /// <summary>
        /// Translate an object implementing the IFilter interface to a parameterized SQL script conditional statements.
        /// </summary>
        /// <param name="filter">The object implementing the IFilter interface to be translated</param>
        /// <returns>The SQL condition clause script</returns>
		public static string GetParameterizedConditionStatements(i.IFilter filter)
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
                    retVal.Append($"({GetParameterizedConditionStatements(f.Key)})");
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
                            if (i > 0)
                                retVal.Append(",");
                            retVal.Append($"@{paramName}_Val{i + 1}");
                        }
                        retVal.Append(")");
                        break;
                    case ComparisonOperator.IsNotNull:
                        retVal.Append($"{filter.FieldName} IS NOT NULL");
                        break;
                    case ComparisonOperator.IsNull:
                        retVal.Append($"{filter.FieldName} IS NULL");
                        break;
                    case ComparisonOperator.Like:
                        retVal.Append($"{filter.FieldName} LIKE (@{paramName})");
                        break;
                    case ComparisonOperator.Contains:
                        retVal.Append($"{filter.FieldName} LIKE ('%' + @{paramName} + '%')");
                        break;
                    case ComparisonOperator.StartsWith:
                        retVal.Append($"{filter.FieldName} LIKE (@{paramName} + '%')");
                        break;
                    case ComparisonOperator.EndsWith:
                        retVal.Append($"{filter.FieldName} LIKE ('%' + @{paramName})");
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

        /// <summary>
        /// Translate an object implementing the IFilter interface to a parameterized SQL script where clause. 
        /// </summary>
        /// <param name="filter">The object implementing the IFilter interface to be translated</param>
        /// <returns>The SQL where clause script</returns>
		public static string GetParameterizedWhere(i.IFilter filter)
        {
            return $"WHERE({GetParameterizedConditionStatements(filter)})";
        }

        public static string GetParameterizedConditionStatements<T>(i.IFilter filter, ObjectPropertyMap<T> map)
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
                    retVal.Append($"({GetParameterizedConditionStatements(f.Key)})");
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
                            if (i > 0)
                                retVal.Append(",");
                            retVal.Append($"@{paramName}_Val{i + 1}");
                        }
                        retVal.Append(")");
                        break;
                    case ComparisonOperator.IsNotNull:
                        retVal.Append($"{filter.FieldName} IS NOT NULL");
                        break;
                    case ComparisonOperator.IsNull:
                        retVal.Append($"{filter.FieldName} IS NULL");
                        break;
                    case ComparisonOperator.Like:
                        retVal.Append($"{filter.FieldName} LIKE (@{paramName})");
                        break;
                    case ComparisonOperator.Contains:
                        retVal.Append($"{filter.FieldName} LIKE ('%' + @{paramName} + '%')");
                        break;
                    case ComparisonOperator.StartsWith:
                        retVal.Append($"{filter.FieldName} LIKE (@{paramName} + '%')");
                        break;
                    case ComparisonOperator.EndsWith:
                        retVal.Append($"{filter.FieldName} LIKE ('%' + @{paramName})");
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

        public static string GetParameterizedWhere<T>(i.IFilter filter, ObjectPropertyMap<T> map)
        {
            if (filter == null)
                return "";
            if(filter is i.IFilters)
            {
                if ((filter as i.IFilters).FilterList.Count == 0)
                    return "";
            }
            return $"WHERE({GetParameterizedConditionStatements(filter, map)})";
        }

        /// <summary>
        /// Translate a property map object into a Sql parameter name string
        /// </summary>
        /// <typeparam name="T">The type for which the map was created</typeparam>
        /// <param name="map">The object property map</param>
        /// <returns>A comma sepetated string of the parmeter names</returns>
		public static string GetValuesParameterNameString<T>(ObjectPropertyMap<T> map)
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

        /// <summary>
        /// Translate a property map object to a TSQL declare string
        /// </summary>
        /// <typeparam name="T">The type for which the map was created</typeparam>
        /// <param name="value">The objects to be used for the parameter values</param>
        /// <param name="map">The object property map</param>
        /// <returns>The TSQL declare clause for the value</returns>
		public static string GetValuesParameterDeclareString<T>(object value, ObjectPropertyMap<T> map)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.Append("DECLARE ");

            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                object val = GetValue(value, pmap);
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(",");
                retVal.AppendLine($"@{pmap.FieldName} {GetTypeString(pmap)} = {GetSqlSafeValueString(val, pmap)}");
            }
            return retVal.ToString();
        }

        public static string GetJoinString<T>(ObjectPropertyMap<T> map)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine();
            List<PropertyMap> joinMaps = map.PropertyMaps.Where(m => m.Join != null).ToList();
            if(joinMaps.Count == 0)
                return string.Empty;
            foreach (PropertyMap pMap in joinMaps)
            {
                retVal.AppendLine(pMap.Join.ToString());
            }
            return retVal.ToString();
        }

        public static string GetGroupBy<T>(ObjectPropertyMap<T> map)
        {
            if(string.IsNullOrEmpty(map.GroupBy))
                return string.Empty;
            return $"\r\nGROUP BY {map.GroupBy}";
        }

        /// <summary>
        /// Gets an Update or Insert (Upsert) TSQL command for the provided value and mapping
        /// </summary>
        /// <typeparam name="T">The type of the value</typeparam>
        /// <param name="value">The value for which the script needs to be generated</param>
        /// <param name="map">The object's property mapping</param>
        /// <param name="useTransaction">A flag indicating whether the script should include the using of TSQL transactions</param>
        /// <returns>The TSQL script that will update or insert the database</returns>
		public static string GetUpsertSQL<T>(object value, ObjectPropertyMap<T> map, bool useTransaction = false, bool includeIdentityFields = false, bool includeSetToNull = true)
        {
            StringBuilder retVal = new StringBuilder();
            if (useTransaction)
                //Add transaction begin
                retVal.AppendLine("BEGIN TRANSACTION");

            string keyWhere = GetParameterizedWhere(map.GetKeyFilters(value));
            if (keyWhere != "WHERE()")
            {
                retVal.AppendLine($"IF EXISTS (SELECT {map.KeyFieldList} FROM {map.DatabaseObject} {keyWhere})");
                retVal.AppendLine($"UPDATE {map.DatabaseObject} SET");
                Type valueType = value.GetType();
                //Get the value for each non key property
                bool isFirst = true;
                foreach (PropertyMap pmap in map.PropertyMaps.Where(m => !m.IsPartOfKey).ToList())
                {
                    if (!includeIdentityFields && pmap.IsIdentity)
                        continue;
                    object pVal = GetValue(value, pmap.PropertyName);
                    //Add a set clause
                    //If the value is not null
                    if (includeSetToNull || pVal != null)
                    {
                        if (isFirst)
                            isFirst = false;
                        else
                            retVal.AppendLine(",");
                        retVal.Append($"{pmap.FieldName} = @{pmap.FieldName}");
                    }
                }
                retVal.AppendLine();
                retVal.AppendLine(GetParameterizedWhere(map.GetKeyFilters(value)));
                retVal.AppendLine("ELSE");
            }
            retVal.AppendLine($"INSERT INTO {map.DatabaseObject} ({GetFieldList(value, map, includeNulls: includeSetToNull)})");
            retVal.AppendLine($"VALUES ({GetValuesParamList(value, map, includeNulls: includeSetToNull)})");
            if (useTransaction)
            {
                //Add Transaction end
                retVal.AppendLine("IF @@ERROR <> 0 GOTO HandleError");
                //Add commit
                retVal.AppendLine("COMMIT TRANSACTION");
                //Add goto end
                retVal.AppendLine("GOTO Done");
                //Add rollback on error
                retVal.AppendLine("HandleError:");
                retVal.AppendLine("ROLLBACK TRANSACTION");
                //Add end
                retVal.AppendLine("Done:");
            }
            return retVal.ToString();
        }

        public static string GetDeleteSQL<T>(object value, ObjectPropertyMap<T> map)
        {
            return $"DELETE FROM {map.DatabaseObject} {GetParameterizedWhere(map.GetKeyFilters(value))}";
        }

        public static string GetWhereClauses(i.IFilter filter)
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
                    retVal.Append($"({GetWhereClauses(f.Key)})");
                }
            }
            else
            {
                switch (filter.Operator)
                {
                    case ComparisonOperator.Between:
                        retVal.Append($"{filter.FieldName} BETWEEN {GetSqlSafeValueString(filter.Value.Values[0], filter.Value.DbType.Value)} AND {GetSqlSafeValueString(filter.Value.Values[1], filter.Value.DbType.Value)}");
                        break;
                    case ComparisonOperator.Equal:
                        retVal.Append($"{filter.FieldName} = @{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)}");
                        break;
                    case ComparisonOperator.GreaterThan:
                        retVal.Append($"{filter.FieldName} > @{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)}");
                        break;
                    case ComparisonOperator.GreaterThanOrEqual:
                        retVal.Append($"{filter.FieldName} >= @{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)}");
                        break;
                    case ComparisonOperator.In:
                        retVal.Append($"{filter.FieldName} IN (");
                        for (int i = 0; i < filter.Value.Values.Length; i++)
                        {
                            retVal.Append($"{GetSqlSafeValueString(filter.Value.Values[i], filter.Value.DbType.Value)}");
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
                        retVal.Append($"{filter.FieldName} LIKE (@{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)})");
                        break;
                    case ComparisonOperator.NotEqual:
                        retVal.Append($"{filter.FieldName} <> @{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)}");
                        break;
                    case ComparisonOperator.SmallerThan:
                        retVal.Append($"{filter.FieldName} < @{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)}");
                        break;
                    case ComparisonOperator.SmallerThanOrEqual:
                        retVal.Append($"{filter.FieldName} <= @{GetSqlSafeValueString(filter.Value.Value, filter.Value.DbType.Value)}");
                        break;
                }
            }
            return retVal.ToString();
        }

        public static string GetHierachicalQuery<T>(ObjectPropertyMap<T> map)
        {
            StringBuilder retval = new StringBuilder(),
                selectString = new StringBuilder();
            List<string> appends = new List<string>();
            selectString.Append("SELECT ");
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                if (pmap.ObjectMap != null)
                {
                    StringBuilder relateString = new StringBuilder();
                    for (int i = 0; i < pmap.Join.JoinFields.Count; i++)
                    {
                        relateString.Append(i > 0 ? ", " : "");
                        relateString.Append($"{pmap.Join.JoinFields[i].FieldName} TO {pmap.Join.JoinFields[i].ForeignFieldName}");
                    }
                    //Call the generic method for the propery's object property mapping
                    MethodInfo method = typeof(SQLServer).GetMethod("GetHierachicalQuery");
                    MethodInfo genericMethod = method.MakeGenericMethod(pmap.ObjectMap.GetType());
                    string childQuery = genericMethod.Invoke(null, new object[] { pmap.ObjectMap }) as string;

                    appends.Add($"({{{childQuery}}} AS {pmap.PropertyName} RELATE {relateString})");
                }
                else
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        selectString.Append(", ");
                    selectString.Append(pmap.FieldLength);
                }
            }
            retval.AppendLine($"SHAPE {{{selectString}}} APPEND ");
            isFirst = true;
            foreach (string append in appends)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retval.Append(",");
                retval.AppendLine(append);
            }
            return retval.ToString();
        }

        public static IDataReader GetData<T>(IDbConnection connection, ObjectPropertyMap<T> map, i.IFilter filters = null, int? pageIndex = null, int? pageSize = null)
        {
            IDataReader retVal;
            if (map.HasHierarchy)
            {
                retVal = null;
                return retVal;
            }
            else if (!string.IsNullOrEmpty(map.CustomSQL))
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                IDbCommand command = connection.CreateCommand();
                string query;
                if (pageSize != null && pageIndex != null && !map.IsStoredProcedure)
                {
                    int startRow = (pageIndex.Value - 1) * pageSize.Value + 1;
                    if (filters == null)
                        query = $"SELECT {map.FieldNames} FROM (SELECT TOP 100 PERCENT ROW_NUMBER() OVER (ORDER BY {map.OrderByFields}) AS RowNumber, {map.FieldList}\r\nFROM (SELECT * FROM ({map.CustomSQL}) A {GetGroupBy(map)}) B) AS RowResults\r\nWHERE RowNumber >= {startRow} AND RowNumber < {startRow + pageSize} ORDER BY RowNumber";
                    else
                    {
                        query = $"SELECT {map.FieldNames} FROM (SELECT TOP 100 PERCENT ROW_NUMBER() OVER (ORDER BY {map.OrderByFields}) AS RowNumber, {map.FieldList}\r\nFROM (SELECT * FROM ({map.CustomSQL}) A\r\n{GetParameterizedWhere(filters)}{GetGroupBy(map)}) B) AS RowResults\r\nWHERE RowNumber >= {startRow} AND RowNumber < {startRow + pageSize} ORDER BY RowNumber";
                        IDbDataParameter[] parameters = GetParameters(filters);
                        foreach (IDbDataParameter parameter in parameters)
                            command.Parameters.Add(parameter);
                    }
                }
                else
                {
                    if (filters != null)
                    {
                        IDbDataParameter[] parameters = GetParameters(filters);
                        foreach (IDbDataParameter parameter in parameters)
                            command.Parameters.Add(parameter);
                        if (map.IsStoredProcedure)
                            query = map.DatabaseObject;
                        else
                            query = $"SELECT * FROM ({map.CustomSQL}) A\r\n{GetParameterizedWhere(filters)}";
                    }
                    else if (map.IsStoredProcedure)
                        query = map.DatabaseObject;
                    else
                        query = $"{map.CustomSQL}";
                }
                command.CommandType = map.IsStoredProcedure ? CommandType.StoredProcedure : command.CommandType = CommandType.Text;
                command.CommandText = query;
                retVal = command.ExecuteReader();
                return retVal;
            }
            else
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                IDbCommand command = connection.CreateCommand();
                string query;
                if (pageSize != null && pageIndex != null && !map.IsStoredProcedure)
                {
                    int startRow = (pageIndex.Value - 1) * pageSize.Value + 1;
                    if (filters == null)
                        query = $"SELECT {map.FieldNames} FROM (SELECT ROW_NUMBER() OVER (ORDER BY {map.OrderByFields}) AS RowNumber, {map.FieldList}\r\nFROM {map.DatabaseObject}{GetJoinString(map)}{GetGroupBy(map)}) AS RowResults\r\nWHERE RowNumber >= {startRow} AND RowNumber < {startRow + pageSize} ORDER BY RowNumber";
                    else
                    {
                        query = $"SELECT {map.FieldNames} FROM (SELECT ROW_NUMBER() OVER (ORDER BY {map.OrderByFields}) AS RowNumber, {map.FieldList}\r\nFROM {map.DatabaseObject}{GetJoinString(map)}\r\n{GetParameterizedWhere(filters)}{GetGroupBy(map)}) AS RowResults\r\nWHERE RowNumber >= {startRow} AND RowNumber < {startRow + pageSize} ORDER BY RowNumber";
                        IDbDataParameter[] parameters = GetParameters(filters);
                        foreach (IDbDataParameter parameter in parameters)
                            command.Parameters.Add(parameter);
                    }
                }
                else
                {
                    if (filters != null)
                    {
                        IDbDataParameter[] parameters = GetParameters(filters);
                        foreach (IDbDataParameter parameter in parameters)
                            command.Parameters.Add(parameter);
                        if (map.IsStoredProcedure)
                            query = map.DatabaseObject;
                        else
                            query = $"SELECT {map.FieldList}\r\nFROM {map.DatabaseObject}{GetJoinString(map)}\r\n{GetParameterizedWhere(filters)}{GetGroupBy(map)}";
                    }
                    else if (map.IsStoredProcedure)
                        query = map.DatabaseObject;
                    else
                        query = $"SELECT {map.FieldList}\r\nFROM {map.DatabaseObject}{GetJoinString(map)}{GetGroupBy(map)}";
                }
                command.CommandType = map.IsStoredProcedure ? CommandType.StoredProcedure : command.CommandType = CommandType.Text;
                command.CommandText = query;
                retVal = command.ExecuteReader();
                return retVal;
            }
        }

        public static string GetSelectSQL<T>(ObjectPropertyMap<T> map, i.IFilter filters = null, int? pageSize = null, int? pageIndex = null)
        {
            if (filters != null)
            {
                if (map.IsStoredProcedure)
                {
                    return map.DatabaseObject;
                }
                else if (pageSize != null && pageIndex != null && !map.IsStoredProcedure)
                {
                    int startRow = (pageIndex.Value - 1) * pageSize.Value + 1;
                    if (filters == null)
                        return $"SELECT {map.FieldNames} FROM (SELECT TOP 100 PERCENT ROW_NUMBER() OVER (ORDER BY {map.OrderByFields}) AS RowNumber, {map.FieldList}\r\nFROM (SELECT * FROM ({map.CustomSQL}) A {GetGroupBy(map)}) B) AS RowResults\r\nWHERE RowNumber >= {startRow} AND RowNumber < {startRow + pageSize} ORDER BY RowNumber";
                    else
                    {
                        return $"SELECT {map.FieldNames} FROM (SELECT TOP 100 PERCENT ROW_NUMBER() OVER (ORDER BY {map.OrderByFields}) AS RowNumber, {map.FieldList}\r\nFROM (SELECT * FROM ({map.CustomSQL}) A\r\n{GetParameterizedWhere(filters)}{GetGroupBy(map)}) B) AS RowResults\r\nWHERE RowNumber >= {startRow} AND RowNumber < {startRow + pageSize} ORDER BY RowNumber";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(map.CustomSQL))
                        return $"SELECT {map.FieldList}\r\nFROM ({map.CustomSQL}) a {GetJoinString(map)}{GetGroupBy(map)}\n{GetParameterizedWhere(filters)}";
                    return $"SELECT {map.FieldList}\r\nFROM {map.DatabaseObject}{GetJoinString(map)}{GetGroupBy(map)}\n{GetParameterizedWhere(filters)}";
                }
            }
            else
            {
                if (map.IsStoredProcedure)
                {
                    return map.DatabaseObject;
                }
                else
                {
                    return $"SELECT {map.FieldList}\r\nFROM {map.DatabaseObject}{GetJoinString(map)}{GetGroupBy(map)}";
                }
            }
        }

        private static object GetValue(object value, PropertyMap map)
        {
            if (value == null)
                return null;
            Type valueType = value.GetType();
            PropertyInfo property;
            string propertyName = map.PropertyName;
            if (propertyName.Contains('.'))
            {
                string[] parts = propertyName.Split('.');
                property = valueType.GetProperty(parts.First());
                if (property != null)
                {
                    object val = property.GetValue(value);
                    return GetValue(val, propertyName.Replace($"{parts.First()}.", ""));
                }
                throw new InvalidPropertyMapExpression(value, map);
            }
            else
            {
                property = valueType.GetProperty(propertyName);
                if (property != null)
                    return property.GetValue(value);
                throw new InvalidPropertyMapExpression(value, map);
            }
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
                    object val = property.GetValue(value);
                    return GetValue(val, propertyName.Replace($"{parts.First()}.", ""));
                }
                throw new InvalidExpressionException($"{valueType.FullName} does not contain a property named {parts.First()}");
            }
            else
            {
                PropertyInfo property = valueType.GetProperty(propertyName);
                if (property != null)
                    return property.GetValue(value);
                throw new InvalidExpressionException($"{valueType.FullName} does not contain a property named {propertyName}");
            }
        }

        private static string GetFieldList<T>(object value, ObjectPropertyMap<T> map, bool includeNulls = false, bool includeIdentityFields = false)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                if (!includeIdentityFields && pmap.IsIdentity)
                    continue;
                object pVal = GetValue(value, pmap.PropertyName);
                //If the value is not null
                if (pVal != null)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.Append(",");
                    retVal.Append(pmap.FieldName);
                }
                //Add a set clause
            }
            return retVal.ToString();
        }

        private static string GetValuesParamList<T>(object value, ObjectPropertyMap<T> map, bool includeNulls = false, bool includeIdentityFields = false)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (PropertyMap pmap in map.PropertyMaps)
            {
                if (!includeIdentityFields && pmap.IsIdentity)
                    continue;
                object pVal = GetValue(value, pmap.PropertyName);
                //If the value is not null
                if (pVal != null)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.Append(",");
                    retVal.Append($"@{pmap.FieldName}");
                }
                //Add a set clause
            }
            return retVal.ToString();
        }

        public static string GetSqlSafeValueString(object value, PropertyMap map)
        {
            return GetSqlSafeValueString(value, map.DbType.Value);
        }

        public static string GetSqlSafeValueString(object value, DbType dbType = DbType.Object)
        {
            SqlDbType valueType = dbType == DbType.Object ? GetSQLDbType(value.GetType()) : GetSQLDbType(dbType);
            switch (valueType)
            {
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.VarChar:
                case SqlDbType.NVarChar:
                    return $"'{(value as string).Replace("'", "''")}'";
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                case SqlDbType.Time:
                case SqlDbType.Timestamp:
                case SqlDbType.SmallDateTime:
                    return $"'{value:yyyy-MM-dd hh:mm:ss.fff}'";
                default:
                    return $"{value}";
            }
        }

        public static object DeleteData<T>(IDbConnection connection, ObjectPropertyMap<T> map, object value = null, i.IFilter filters = null, string preScript = null, string postScript = null)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (map == null)
                throw new ArgumentNullException(nameof(map));

            IDbCommand command = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command = connection.CreateCommand();

                string query;
                if (filters != null)
                {
                    IDbDataParameter[] parameters = GetParameters(filters);
                    foreach (IDbDataParameter parameter in parameters)
                        command.Parameters.Add(parameter);
                    
                    if (map.IsStoredProcedure)
                        query = map.DatabaseObject;
                    else
                        query = $"DELETE FROM {map.CustomSQL ?? map.DatabaseObject}\r\n{GetParameterizedWhere(filters)}";
                }
                else if (map.IsStoredProcedure)
                    query = map.DatabaseObject;
                else if(!string.IsNullOrEmpty(map.CustomSQL))
                    query = $"{map.CustomSQL}";
                else
                    query = GetDeleteSQL(value, map);

                command.CommandText = string.IsNullOrEmpty(preScript) ?
                    string.IsNullOrEmpty(postScript) ?
                        query
                        : $"{query}\r\r{postScript}"
                    : string.IsNullOrEmpty(postScript) ?
                        $"{preScript}\r\n{query}"
                        : $"{preScript}\r\n{query}\r\n{postScript}";

                command.CommandType = CommandType.Text;

                if (string.IsNullOrEmpty(postScript))
                    return command.ExecuteNonQuery();
                else
                    return command.ExecuteScalar();
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

        public static object SaveData<T>(object value, IDbConnection connection, ObjectPropertyMap<T> map, bool useTransaction = false, string preScript = null, string postScript = null)
        {
            IDbCommand command = null;
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
                command = connection.CreateCommand();
                command.CommandText =  string.IsNullOrEmpty(preScript) ? 
                    string.IsNullOrEmpty(postScript) ? 
                        GetUpsertSQL(value, map, useTransaction) 
                        : $"{GetUpsertSQL(value, map, useTransaction)}\r\r{postScript}"  
                    : string.IsNullOrEmpty(postScript) ? 
                        $"{preScript}\r\n{GetUpsertSQL(value, map, useTransaction)}"
                        : $"{preScript}\r\n{GetUpsertSQL(value, map, useTransaction)}\r\n{postScript}";
                command.CommandType = CommandType.Text;
                IDbDataParameter[] parameters =GetParameters(value, map, true);
                foreach (IDbDataParameter p in parameters)
                    command.Parameters.Add(p);
                if (string.IsNullOrEmpty(postScript))
                {
                    return command.ExecuteNonQuery();
                }
                else
                {
                    return command.ExecuteScalar();
                }
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
    }
}
