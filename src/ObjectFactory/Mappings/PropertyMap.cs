using System;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;

using SEFI.Enums;
using SEFI.DataUtilities.TSQL;
namespace SEFI.Mappings
{
    public class PropertyMap
    {
        string _UserFriendlyName = null;

        public string PropertyName { get; set; }
        public string DbObjectName { get; set; } = null;
        public string FieldName { get; set; }
        public string Alias { get; set; } = null;
        public bool IsRequired { get; set; } = false;
        public bool IsPartOfKey { get; set; } = false;
        public bool IsIdentity { get; set; } = false;
        public bool TrimString { get; set; } = false;
        public DbType? DbType { get; set; }
        public SqlDbType? SqlDbType { get; set; }
        public bool IsNullable { get; set; } = true;
        public bool IsUpdatable { get; set; } = true;
        public int FieldLength { get; set; } = 0;
        public int MinFieldLength { get; set; } = 0;
        public object ObjectMap { get; set; }
        public Join Join { get; set; } = null;
        public Type PropertyType { get; set; }
        public Type SourceType { get; set; }
        public string SourceKey { get; set; }
        public Type MustConvertToType { get; set; } = null;
        public AggregateFunctions? Aggregate { get; set; } = null;
        public string Expression { get; set; } = null;
        public object Value { get; set; } = null;
        public object MaxValue { get; set; } = null;
        public object MinValue { get; set; } = null;
        public string ValidationExpression { get; set; } = null;
        public string UserFriendlyName { get => _UserFriendlyName ?? PropertyName; }

        public PropertyMap HasFieldName(string name)
        {
            FieldName = name;
            return this;
        }

        public PropertyMap HasAlias(string alias)
        {
            Alias = alias;
            return this;
        }


        public PropertyMap HasDbType(DbType type)
        {
            DbType = type;
            return this;
        }

        public PropertyMap HasSqlDbType(SqlDbType type)
        {
            SqlDbType = type;
            return this;
        }

        public PropertyMap HasLength(int length)
        {
            FieldLength = length;
            return this;
        }

        public PropertyMap HasMinLength(int length)
        {
            MinFieldLength = length;
            return this;
        }

        public PropertyMap HasUserFriendlyName(string value)
        {
            _UserFriendlyName = value;
            return this;
        }

        public Join HasJoin(string foreignTableName)
        {
            Join = new Join().HasTableName(foreignTableName);
            return Join;
        }

        public Join HasJoin(string foreignTableName, string fieldName, string foreignFieldName, SQLJoinTypes joinType = SQLJoinTypes.INNER)
        {
            Join = new Join().HasTableName(foreignTableName).HasJoinFields(fieldName, foreignFieldName);
            Join.JoinType = joinType;
            return Join;
        }

        public PropertyMap HasValue(object value)
        {
            Value = value;
            return this;
        }

        public PropertyMap HasMaxValue(object value)
        {
            MaxValue = value;
            return this;
        }

        public PropertyMap HasMinValue(object value)
        {
            MinValue = value;
            return this;
        }

        public PropertyMap HasValidationExpression(string expression)
        {
            ValidationExpression = expression;
            return this;
        }

        public PropertyMap HasObjectMap(object objectMap)
        {
            ObjectMap = objectMap;
            return this;
        }

        public PropertyMap HasSourceType(Type sourceType)
        {
            SourceType = sourceType;
            return this;
        }

        public PropertyMap HasSourceKey(string key)
        {
            SourceKey = key;
            return this;
        }

        public PropertyMap Convert2Type(Type type)
        {
            MustConvertToType = type;
            return this;
        }

        public PropertyMap IsRequiredField(bool value)
        {
            IsRequired = value;
            return this;
        }

        public PropertyMap IsMemberOfKeyField(bool value)
        {
            IsPartOfKey = value;
            return this;
        }

        public PropertyMap AllowNull(bool value)
        {
            IsNullable = value;
            return this;
        }

        public PropertyMap IsIdentityField(bool value)
        {
            IsIdentity = value;
            return this;
        }

        public PropertyMap MustTrimString(bool value)
        {
            TrimString = value;
            return this;
        }

        public PropertyMap UseAggregate(AggregateFunctions value)
        {
            Aggregate = value;
            return this;
        }

        public PropertyMap UseExpression(string value)
        {
            Expression = value;
            return this;
        }

        public T GetValue<T>(IDataReader reader)
		{
			return (T)reader.GetValue(reader.GetOrdinal(FieldName));
		}
		
        public void SetValue(object target, IDataReader reader)
		{
			if (PropertyName.Contains('.'))
			{
				string objectPropertyName = PropertyName.Split('.').First();
				PropertyInfo property = target.GetType().GetProperty(objectPropertyName);
				if (property != null)
				{
					object objectProperty = property.GetValue(target);
					SetValue(PropertyName.Replace($"{objectPropertyName}.", ""), objectProperty, reader);
				}
			}
			else
			{
				PropertyInfo property = target.GetType().GetProperty(PropertyName);
				if (property != null)
					property.SetValue(target, reader.GetValue(reader.GetOrdinal(FieldName)));
			}
		}

        private void SetValue(string propertyName, object target, IDataReader reader)
		{
			if (propertyName.Contains('.'))
			{
				string objectPropertyName = propertyName.Split('.').First();
				PropertyInfo property = target.GetType().GetProperty(objectPropertyName);
				if (property != null)
				{
					object objectProperty = property.GetValue(target);
					SetValue(propertyName.Replace($"{objectPropertyName}.", ""), objectProperty, reader);
				}
			}
			else
			{
				PropertyInfo property = target.GetType().GetProperty(propertyName);
				if (property != null)
					property.SetValue(target, reader.GetValue(reader.GetOrdinal(FieldName)));
			}
		}
	}

    public class PropertyMaps : List<PropertyMap>
    {
        public new PropertyMaps Add(PropertyMap item)
        {
            base.Add(item);
            return this;
        }
    }
}
