using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;

using i = SEFI.Interfaces;
using e = SEFI.Enums;
using h = SEFI.DataUtilities;
using SEFI.Extensions;
using SEFI.Classes;
namespace SEFI.Mappings
{
	public class ObjectPropertyMap<T>
	{
		public ObjectPropertyMap ()
		{
			PropertyMaps = new PropertyMaps();
		}

		public ObjectPropertyMap(string databaseObect, bool isStoredProcedure, params PropertyMap[] propertyMaps)
			: this()
		{
			DatabaseObject = databaseObect;
			IsStoredProcedure = isStoredProcedure;
			foreach (PropertyMap map in propertyMaps)
				PropertyMaps.Add(map);
		}

		public PropertyMaps PropertyMaps { get; protected set; }
		public string DatabaseObject { get; set; }
		public bool IsStoredProcedure { get; set; }
		public bool HasHierarchy { get => PropertyMaps.Where(m => m.ObjectMap != null).Any(); }
        public string GroupBy { get; set; } = null;
        public string OrderByFields { get => _OrderByFields.Count > 0 ? _OrderByFields.ToCSVString() : null;  }
        public string CustomSQL { get; set; }
        readonly List<string> _OrderByFields = new List<string>();

        public ObjectPropertyMap<T> AddOrderField(string fieldName)
        {
            _OrderByFields.Add(fieldName);
            return this;
        }

        /// <summary>
        /// A property method that use a LINQ expression to map a class' properties.
        /// Usage: ObjectPropertyMap&lt;Class&gt; classMap = new ObjectPropertyMap&lt;Class&gt;().Property(c => c.property).HasFieldName("FieldName");
        /// </summary>
        /// <typeparam name="TProperty">The property type</typeparam>
        /// <param name="propertyExpression">The LINQ expression identifying the class' property</param>
        /// <returns>A property map object for the specified property</returns>
        public PropertyMap Property<TProperty>(Expression<Func<T, TProperty>> propertyExpression)
        {
            MemberExpression body = propertyExpression.Body as MemberExpression;
            PropertyMap retVal = new PropertyMap
            {
                PropertyName = body.Member.Name,
                PropertyType = typeof(TProperty)
            };
            PropertyMaps.Add(retVal);
            return retVal;
        }

		public PropertyMap Property<S, TProperty>(Expression<Func<T, TProperty>> propertyExpression, Expression<Func<S, TProperty>> sourceExpression)
		{
			PropertyMap retVal = null;
			MemberExpression body = null;
			if (propertyExpression.Body is UnaryExpression)
			{
				UnaryExpression ubody = propertyExpression.Body as UnaryExpression;
				if (ubody.Operand is MemberExpression)
					body = ubody.Operand as MemberExpression;
			}
			else
				body = propertyExpression.Body as MemberExpression;
			if (sourceExpression.Body is MemberExpression)
			{
				MemberExpression sourceBody = sourceExpression.Body as MemberExpression;
				retVal = new PropertyMap
				{
					PropertyName = body.Member.Name,
					PropertyType = typeof(TProperty),
					FieldName = sourceBody.Member.Name,
					SourceType = typeof(S)
				};
			}
			else if (sourceExpression.Body is UnaryExpression)
			{
				UnaryExpression sourceExpr = sourceExpression.Body as UnaryExpression;
				MemberExpression sourceBody = sourceExpr.Operand as MemberExpression;
				retVal = new PropertyMap
				{
					PropertyName = body.Member.Name,
					PropertyType = typeof(TProperty),
					FieldName = sourceBody.Member.Name,
					SourceType = typeof(S)
				};
			}
			PropertyMaps.Add(retVal);
			return retVal;
		}

        /// <summary>
        /// Populate the provided object from the provided data reader using this mapping
        /// </summary>
        /// <param name="target">The target object to be populated</param>
        /// <param name="reader">The data reader containing the record</param>
		public void PopulateObject(object target, IDataReader reader)
		{
			foreach (PropertyMap map in PropertyMaps)
				map.SetValue(target, reader);
		}

        /// <summary>
        /// Get the filter(s) that can be used to find an object using the key propeties
        /// </summary>
        /// <param name="value">The object which values will be used for the filter values</param>
        /// <returns>An IFilter object containing one or more filter objects</returns>
		public i.IFilters GetKeyFilters(object value)
		{
			Filters retval = new Filters();
			bool isFirst = true;
			List<PropertyMap> keyMaps = PropertyMaps.Where(m => m.IsPartOfKey).ToList();
			foreach (PropertyMap map in keyMaps)
			{
				PropertyInfo property = value.GetType().GetProperty(map.PropertyName);
				string dbObjectName = map.Join == null ? DatabaseObject : map.Join.RightObjectName.ToString();
				if (property != null)
				{
					object val = property.GetValue(value);
                    if (val == null)
                    {
                        if (map.IsRequired)
                            throw new ArgumentNullException($"{nameof(value)}.{map.PropertyName}", $"{map.FieldName} is a required field");
                        continue;
                    }
					Filter filter = new Filter
					{
						Name = $"By {map.FieldName}",
						FieldName = $"[{dbObjectName}].[{map.FieldName}]",
						Operator = e.ComparisonOperator.Equal,
						Value = new ValueObject
						{
							Value = val,
							DbType = h.Helpers.GetDbType(property.PropertyType)
						}
					};
					e.LogicOperator o;
					if (isFirst)
					{
						isFirst = false;
						o = e.LogicOperator.Empty;
					}
					else
						o = e.LogicOperator.And;
					retval.FilterList.Add(new KeyValuePair<i.IFilter, e.LogicOperator>(filter, o));
				}
			}
			return retval;
		}

        /// <summary>
        /// Get a list of all the database fields mapped
        /// </summary>
		public string FieldList
		{
			get
			{
				StringBuilder retVal = new StringBuilder();
				bool isFirst = true;
				foreach(PropertyMap map in PropertyMaps)
				{
					if (isFirst)
						isFirst = false;
					else
						retVal.Append(",");
					string dbObjectName = map.Join == null ? string.IsNullOrEmpty(map.DbObjectName) ? DatabaseObject : map.DbObjectName : map.Join.RightObjectName.ToString();
                    string alias = string.IsNullOrEmpty(map.Alias) ? map.FieldName : map.Alias;
                    if (!string.IsNullOrEmpty(dbObjectName))
                        dbObjectName += ".";
                    if (map.Aggregate != null)
                    {
                        if (string.IsNullOrEmpty(map.Expression))
                            retVal.Append($"{map.Aggregate}({dbObjectName}{map.FieldName}) as {alias}");
                        else
                            retVal.Append($"{map.Aggregate}({map.Expression}) as {alias}");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(map.Expression))
                            retVal.Append($"{dbObjectName}{map.FieldName} as {alias}");
                        else
                            retVal.Append($"{map.Expression} as {alias}");
                    }
                }
				return retVal.ToString();
			}
		}

        public string FieldNames
        {
            get
            {
                StringBuilder retVal = new StringBuilder();
                bool isFirst = true;
                foreach (PropertyMap map in PropertyMaps)
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        retVal.Append(",");
                   retVal.Append(string.IsNullOrEmpty(map.Alias) ? map.FieldName : map.Alias);
                }
                return retVal.ToString();
            }
        }

        /// <summary>
        /// Get a list of fields that can be used in a SQL INSERT statement
        /// </summary>
		public string InsertFieldList
		{
			get
			{
				StringBuilder retVal = new StringBuilder();
				bool isFirst = true;
				foreach (PropertyMap map in PropertyMaps)
				{
					if (isFirst)
						isFirst = false;
					else
						retVal.Append(",");
					string dbObjectName = map.Join == null ? DatabaseObject : map.Join.RightObjectName.ToString();
					retVal.Append($"{map.FieldName}");
				}
				return retVal.ToString();
			}
		}

        /// <summary>
        /// Get a list of the field where the property is designated as key property
        /// </summary>
		public string KeyFieldList
		{
			get
			{
				StringBuilder retVal = new StringBuilder();
				bool isFirst = true;
				List<PropertyMap> keyMaps = PropertyMaps.Where(m => m.IsPartOfKey).ToList();
				foreach (PropertyMap map in keyMaps)
				{
					if (isFirst)
						isFirst = false;
					else
						retVal.Append(",");
					string dbObjectName = map.Join == null ? DatabaseObject : map.Join.RightObjectName.ToString();
					retVal.Append($"{dbObjectName}.{map.FieldName}");
				}
				return retVal.ToString();
			}
		}

        /// <summary>
        /// Gets a filter for every mapped property
        /// </summary>
        /// <param name="filterObject">The object which values are to be used</param>
        /// <returns>A Filters object containing a filter for each mapped property</returns>
		public virtual Filters GetFilters(object filterObject)
		{
			List<KeyValuePair<string, object>> fields = new List<KeyValuePair<string, object>>();

			foreach (PropertyInfo property in filterObject.GetType().GetProperties())
				fields.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(filterObject)));
			return GetFilters(false, fields.ToArray());
		}

        /// <summary>
        /// Gets the filter(s) for the provided fields
        /// </summary>
        /// <param name="includeTableName">A flag indicating whether the table name should be included Default = false</param>
        /// <param name="fields">An array of key value pairs havint the property name as the key and the filter value as the value</param>
        /// <returns>A Filters object containing a filter for each provided property</returns>
		public virtual Filters GetFilters(bool includeTableName = false, params KeyValuePair<string, object>[] fields )
		{
			bool isFirst = true;
			Filters retVal = new Filters();
			foreach(KeyValuePair<string, object> field in fields)
			{
				PropertyMap map = PropertyMaps.Where(m => m.PropertyName == field.Key).FirstOrDefault();
				if(map != null)
				{
					string dbObjectName = map.Join == null ? DatabaseObject : map.Join.RightObjectName.ToString();
					Filter filter = new Filter
					{
						Name = $"By {map.FieldName}",
						FieldName = includeTableName ? $"{dbObjectName}.{map.FieldName}" : map.FieldName,
						Operator = e.ComparisonOperator.Equal,
						Value = new ValueObject
						{
							Value = field.Value,
							DbType = map.DbType.Value,
							SqlDbType = map.SqlDbType.Value,
							Size = map.FieldLength
						}
					};
					e.LogicOperator o;
					if (isFirst)
					{
						isFirst = false;
						o = e.LogicOperator.Empty;
					}
					else
						o = e.LogicOperator.And;
					retVal.FilterList.Add(new KeyValuePair<i.IFilter, e.LogicOperator>(filter, o));
				}
			}
			return retVal;
		}

        public ObjectPropertyMap<T> HasCustomSQL(string customSQL)
        {
            CustomSQL = customSQL;
            return this;
        }

		public string GetKey( T value)
		{
			Type type = typeof(T);
			List<string> keyFields = new List<string>();
			foreach(PropertyMap map in PropertyMaps)
			{
				if (map.IsPartOfKey)
				{
					PropertyInfo property = type.GetProperty(map.PropertyName);
					object val = property.GetValue(value);
					keyFields.Add(val?.ToString() ?? "");
				}
			}
			return string.Join("|", keyFields.ToArray());
		}
	}
}
