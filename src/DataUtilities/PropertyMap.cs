using System;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace SEFI.Infrastructure.Common
{
	public class PropertyMap
	{
		public string PropertyName { get; set; }
		public string DbObjectName { get; set; } = null;
		public string FieldName { get; set; }
		public bool IsRequired { get; set; } = false;
		public bool IsPartOfKey { get; set; } = false;
		public DbType DbType { get; set; }
		public int FieldLength { get; set; } = 0;
		public ObjectPropertyMap ObjectMap { get; set; }
		public DataUtilities.Join Join { get; set; } = null;
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
					object objectProperty = property.GetValue(target, null);
					SetValue(PropertyName.Replace($"{objectPropertyName}.", ""), objectProperty, reader);
				}
			}
			else
			{
				PropertyInfo property = target.GetType().GetProperty(PropertyName);
				if (property != null)
					property.SetValue(target, reader.GetValue(reader.GetOrdinal(FieldName)), null);
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
					object objectProperty = property.GetValue(target, null);
					SetValue(propertyName.Replace($"{objectPropertyName}.", ""), objectProperty, reader);
				}
			}
			else
			{
				PropertyInfo property = target.GetType().GetProperty(propertyName);
				if (property != null)
					property.SetValue(target, reader.GetValue(reader.GetOrdinal(FieldName)), null);
			}
		}
	}
}
