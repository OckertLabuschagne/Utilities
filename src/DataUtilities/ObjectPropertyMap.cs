using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

using i = SEFI.Infrastructure.Common.Interfaces;
using e = SEFI.Infrastructure.Common.Enums;
using h = SEFI.Infrastructure.Common.DataUtilities;
namespace SEFI.Infrastructure.Common
{
	public class ObjectPropertyMap
	{
		public List<PropertyMap> PropertyMaps { get; protected set; }

		public ObjectPropertyMap ()
		{
			PropertyMaps = new List<PropertyMap>();
		}
		public ObjectPropertyMap(string databaseObect, bool isStoredProcedure, params PropertyMap[] propertyMaps)
			: this()
		{
			DatabaseObject = databaseObect;
			IsStoredProcedure = isStoredProcedure;
			foreach (PropertyMap map in propertyMaps)
				PropertyMaps.Add(map);
		}

		public string DatabaseObject { get; set; }
		public bool IsStoredProcedure { get; set; }
		public void PopulateObject(object target, IDataReader reader)
		{
			foreach (PropertyMap map in PropertyMaps)
				map.SetValue(target, reader);
		}

		public i.IFilters GetKeyFilters(object value)
		{
			Filters retval = new Filters();
			bool isFirst = true;
			List<PropertyMap> keyMaps = PropertyMaps.Where(m => m.IsPartOfKey).ToList();
			foreach (PropertyMap map in keyMaps)
			{
				PropertyInfo property = value.GetType().GetProperty(map.PropertyName);
				string dbObjectName = map.Join == null ? DatabaseObject : map.Join.TableName;
				if (property != null)
				{
					object val = property.GetValue(value, null);
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
					string dbObjectName = map.Join == null ? string.IsNullOrEmpty(map.DbObjectName) ? DatabaseObject : map.DbObjectName : map.Join.TableName;
					retVal.Append($"[{dbObjectName}].[{map.FieldName}]");
				}
				return retVal.ToString();
			}
		}

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
					string dbObjectName = map.Join == null ? DatabaseObject : map.Join.TableName;
					retVal.Append($"[{map.FieldName}]");
				}
				return retVal.ToString();
			}
		}

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
					string dbObjectName = map.Join == null ? DatabaseObject : map.Join.TableName;
					retVal.Append($"[{dbObjectName}].[{map.FieldName}]");
				}
				return retVal.ToString();
			}
		}

		public virtual Filters GetFilters(object filterObject)
		{
			List<KeyValuePair<string, object>> fields = new List<KeyValuePair<string, object>>();

			foreach (PropertyInfo property in filterObject.GetType().GetProperties())
				fields.Add(new KeyValuePair<string, object>(property.Name, property.GetValue(filterObject, null)));
			return GetFilters(false, fields.ToArray());
		}

		public virtual Filters GetFilters(bool includeTableName = false, params KeyValuePair<string, object>[] fields )
		{
			bool isFirst = true;
			Filters retVal = new Filters();
			foreach(KeyValuePair<string, object> field in fields)
			{
				PropertyMap map = PropertyMaps.Where(m => m.PropertyName == field.Key).FirstOrDefault();
				if(map != null)
				{
					string dbObjectName = map.Join == null ? DatabaseObject : map.Join.TableName;
					Filter filter = new Filter
					{
						Name = $"By {map.PropertyName}",
						FieldName = includeTableName ? $"[{dbObjectName}].[{map.FieldName}]" : map.PropertyName,
						Operator = e.ComparisonOperator.Equal,
						Value = new ValueObject
						{
							Value = field.Value,
							DbType = map.DbType,
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
	}
}
