using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using SEFI.Infrastructure.Common.DataUtilities;
using SEFI.Infrastructure.Common.Interfaces;
namespace SEFI.Infrastructure.Common.Factory
{
	public class ObjectFactory
	{
		public static T CreateObject<T>(IDbConnection connection, ObjectPropertyMap objectPropertyMap, IFilters filters = null)
		{
            T retVal;

            IDataReader reader = SQLServer.GetData(connection, objectPropertyMap, filters);
            if (reader.Read())
            {
                retVal = CreateObject<T>(reader, objectPropertyMap.PropertyMaps);
            }
            else
                retVal = default(T);
            reader.Close();
            reader.Dispose();
            return retVal;
        }

        public static T CreateObject<T>(IDataReader reader, List<PropertyMap> propertyMaps = null)
		{
			Type returnType = typeof(T);
			if (returnType.IsGenericType)
				return CreateGenericObject<T>(reader, propertyMaps);
			if (returnType.IsArray)
				return CreateArray<T>(reader, propertyMaps);
			if (returnType.IsAbstract || returnType.IsInterface)
				throw new InvalidOperationException($"Cannot create an instance of type \"{returnType.FullName}\"");
			T retVal = (T)returnType.Assembly.CreateInstance(returnType.FullName);
			if (retVal == null)
				throw new NullReferenceException($"The instance of \"{returnType.FullName}\" failed to instantiate");
			if (propertyMaps != null)
			{
				foreach (PropertyMap map in propertyMaps)
				{
					PropertyInfo property = returnType.GetProperty(map.PropertyName);
					if (property == null)
						throw new Exception($"Invalid property mapping. Type \"{returnType.FullName}\" does not have a property called \"{map.PropertyName}\"");
					object value = reader.GetValue(reader.GetOrdinal(map.FieldName));
                    if (value is DBNull)
                        continue;
                    property.SetValue(retVal, value, null);
				}
			}
			else
			{
				foreach(PropertyInfo property in returnType.GetProperties())
				{
					int ord = reader.GetOrdinal(property.Name);
					if(ord > -1)
					{
						property.SetValue(retVal, reader[property.Name], null);
					}
				}
			}
			return retVal;
		}

		public static T CreateGenericObject<T>(IDataReader reader, List<PropertyMap> propertyMaps)
		{
			Type returnType = typeof(T);
			Type elementType = returnType.GetGenericArguments().Last();
			//Type[] genericTypeArguments = objectType.GetGenericArguments();
			//Type returnType = objectType.MakeGenericType(genericTypeArguments);
			if (returnType.IsAbstract || returnType.IsInterface)
				throw new InvalidOperationException($"Cannot create an instance of type \"{returnType.FullName}\"");
			T retVal = (T)Activator.CreateInstance(returnType);
			MethodInfo method = typeof(ObjectFactory).GetMethod("CreateObject", new[] { typeof(IDataReader), typeof(List<PropertyMap>) });
			MethodInfo genericMethod = method.MakeGenericMethod(elementType);
			MethodInfo addMethod = returnType.GetMethod("Add");
			do
			{
				object element = genericMethod.Invoke(null, new object[] { reader, propertyMaps });
				if (returnType.GetGenericArguments().Length == 1)
				{
					addMethod.Invoke(retVal, new object[] { element });
				}
				else
				{
					throw new NotImplementedException();
				}
			} while (reader.Read());
			return retVal;
		}

		public static T CreateArray<T>(IDataReader reader, List<PropertyMap> propertyMaps)
		{
			Type returnType = typeof(T);
			Type elementType = returnType.GetElementType();
			MethodInfo method = typeof(ObjectFactory).GetMethod("CreateList", new[] { typeof(IDataReader), typeof(List<PropertyMap>) });
			MethodInfo genericMethod = method.MakeGenericMethod(elementType);
			var listObject = genericMethod.Invoke(null, new[] { typeof(IDataReader), typeof(List<PropertyMap>) });
			MethodInfo toArrayMethod = listObject.GetType().GetMethod("ToArray");
			return (T)toArrayMethod.Invoke(listObject, null);
		}

		public static T CreateList<T>(IDataReader reader, List<PropertyMap> propertyMaps)
		{
			Type returnType = typeof(T);
			Type elementType = returnType.GetElementType();
			T retVal = (T)returnType.Assembly.CreateInstance(returnType.FullName);
			if (returnType.IsAbstract || returnType.IsInterface)
				throw new InvalidOperationException($"Cannot create an instance of type \"{returnType.FullName}\"");
			MethodInfo method = typeof(ObjectFactory).GetMethod("CreateObject", new[] { typeof(IDataReader), typeof(List<PropertyMap>) });
			MethodInfo genericMethod = method.MakeGenericMethod(elementType);
			MethodInfo addMethod = returnType.GetMethod("Add");
			do
			{
				object element = genericMethod.Invoke(null, new object[] { reader, propertyMaps });
				addMethod.Invoke(retVal, new object[] { element });
			} while (reader.Read());
			return retVal;
		}
	}
}
