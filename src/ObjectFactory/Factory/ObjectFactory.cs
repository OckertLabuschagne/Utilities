using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using SEFI.Mappings;
using SEFI.Interfaces;
using SEFI.DataUtilities;
using SEFI.Extensions;
namespace SEFI.Factory
{
	public class ObjectFactory
	{
		public static T CreateObject<T>(IDbConnection connection, ObjectPropertyMap<T> objectPropertyMap, IFilters filters = null)
		{
			IDataReader reader = SQLServer.GetData(connection, objectPropertyMap, filters);
			if (reader.Read())
				return CreateObject<T>(reader, objectPropertyMap.PropertyMaps);
			else
				return default(T);
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
            //If a property map was provided
			if (propertyMaps != null)
			{
                //For every property mapped
                foreach (PropertyMap map in propertyMaps)
                {
                    PropertyInfo property = returnType.GetProperty(map.PropertyName, map.PropertyType);
                    if (property == null)
                    {
                        //If the mapped object is a nullable type. Nullable is a generic type the first generic argyment is the value type - int? == Nullable<int>, try to get the property of the Nullable<T>.Value type
                        if (map.PropertyType.IsGenericType)
                        {
                            Type[] argumentTypes = map.PropertyType.GetGenericArguments();
                            if (argumentTypes.Any())
                                property = map.SourceType.GetProperty(map.FieldName, argumentTypes.First());
                        }
                    }
                    //If  the class does not contain the property mapped -- throw an exception
                    if (property == null)
                        throw new Exception($"Invalid property mapping. Type \"{returnType.FullName}\" does not have a property called \"{map.PropertyName}\"");
                    if (!property.CanWrite)
                        throw new Exception($"Invalid property mapping. The property \"{returnType.FullName}.{map.PropertyName}\" is read only.");
                    try
                    {
                        if (map.Value != null)
                            SetPropertyValue(returnType, retVal, property, map, map.Value);
                        else
                        {
                            //Get the value from the reader
                            object value = reader.GetValue(reader.GetOrdinal(string.IsNullOrEmpty(map.Alias) ? map.FieldName : map.Alias));
                            object safeValue = GetSafeValue(property, value);
                            if (safeValue is string && map.TrimString) //If string are to be trimmed
                                safeValue = ((string)safeValue).Trim();
                            //Set the property's value
                            property.SetValue(retVal, safeValue);
                        }
                    }
                    catch (Exception excp)//Handle exception 
                    {
                        throw new Exception($"Error creating value for {map.PropertyName}", excp);
                    }
                }
			}
			else //No property map - use property name as field name
			{
                //For each property
				foreach(PropertyInfo property in returnType.GetProperties())
				{
                    //Try to get the ordinal
					int ord = reader.GetOrdinal(property.Name);
                    //If the data reader has a column that matches the property name
					if(ord > -1)
					{
                        //Get the value from the reader
                        object value = reader[property.Name];
                        //Convert the value to a type safe value
                        object safeValue = GetSafeValue(property, value);
                        //Set the property value
                        if (!property.CanWrite)
                            throw new Exception($"Invalid property mapping. The property \"{returnType.FullName}.{property.Name}\" is read only.");
                        property.SetValue(retVal, safeValue);
					}
				}
			}
			return retVal;
		}

        /// <summary>
        /// Convert a value into a type safe value. Handles null values
        /// </summary>
        /// <param name="property">The property info of the property that needs to be set</param>
        /// <param name="value">The value that needs to be converted</param>
        /// <returns></returns>
        private static object GetSafeValue( PropertyInfo property, object value)
        {
            MethodInfo defaultMethod = typeof(ObjectFactory).GetMethod("Default", BindingFlags.NonPublic | BindingFlags.Static);
            //Get the property's type - Get the underlying tyoe if the property's type is a nullable value type
            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            object safeValue = null;
            if (value == null)
                return value;
            if (t.IsEnum) //Get enum values
                safeValue = (value == DBNull.Value) ? null : value == null ? null : Enum.ToObject(t, value);
            else if(value.GetType() == typeof(DateTime))
            {
                if (t == typeof(string))
                    safeValue = ((DateTime)value).ToISODateTime();
                else
                    safeValue = value;
            }
            else if (Nullable.GetUnderlyingType(property.PropertyType) != null) //Handle nullable value types
                safeValue = (value == DBNull.Value) ? null : value == null ? null : Convert.ChangeType(value, t);
            else if (t.IsValueType) //Handle value types
            {
                MethodInfo genDefault = defaultMethod.MakeGenericMethod(t);
                safeValue = (value == DBNull.Value) ? genDefault.Invoke(null, new object[] { }) : (value == null) ? genDefault.Invoke(null, new object[] { }) : Convert.ChangeType(value, t);
            }
            else //Handle all other types
                safeValue = (value == DBNull.Value) ? null : value == null ? null : Convert.ChangeType(value, t);
            return safeValue;
        }

        /// <summary>
        /// Get the default value of a type
        /// </summary>
        /// <typeparam name="T">The type for which the default value is requested</typeparam>
        /// <returns>The default value fo the type</returns>
        private static object Default<T>()
        {
            return default(T);
        }

        /// <summary>
        /// Create an boject from the source
        /// </summary>
        /// <typeparam name="T">The type of the object to be created</typeparam>
        /// <typeparam name="S">The type of the source object</typeparam>
        /// <param name="source">The source object from which the new object needs to be created</param>
        /// <param name="mapping">The mapping mapping the properties of the source object to the target object</param>
        /// <returns></returns>
        public static T CreateObject<T, S>(S source, ObjectPropertyMap<T> mapping)
        {
            Type returnType = typeof(T),
                sourceType = typeof(S);
            if (returnType.IsGenericType)
                throw new NotImplementedException("Creating a generic type is not implemented yet");
            if (returnType.IsArray)
                throw new NotImplementedException("Creating a generic type is not implemented yet");
            if (returnType.IsAbstract || returnType.IsInterface)
                throw new InvalidOperationException($"Cannot create an instance of type \"{returnType.FullName}\"");
            T retVal = (T)returnType.Assembly.CreateInstance(returnType.FullName);
            if (retVal == null)
                throw new NullReferenceException($"The instance of \"{returnType.FullName}\" failed to instantiate");
            if (mapping == null)
                throw new ArgumentException("Mapping cannot be null");
            else
            {
                foreach (PropertyInfo property in returnType.GetProperties())
                {
                    PropertyMap map = mapping.PropertyMaps.Where(m => m.PropertyName == property.Name).FirstOrDefault();
                    if (!string.IsNullOrEmpty(map?.FieldName))
                    {
                        PropertyInfo sProperty = sourceType.GetProperty(map.FieldName.Trim(), map.PropertyType);
                        if (sProperty == null)
                            throw new ArgumentException($"The mapping passes is not valid. {returnType.FullName} does not have a property called \"{map.FieldName}\"");
                        object value = sProperty.GetValue(source);
                        SetPropertyValue(returnType, retVal, property, map, value);
                    }
                    if (map?.Value != null)
                    {
                        object value = map.Value;
                        SetPropertyValue(returnType, retVal, property, map, value);
                    }
                }
            }
            return retVal;
        }

        private static void SetPropertyValue<T>(Type returnType, T retVal, PropertyInfo property, PropertyMap map, object value)
        {
            object safeValue = GetSafeValue(property, value);
            if (safeValue is string && map.TrimString)
                safeValue = ((string)safeValue).Trim();
            if (!property.CanWrite)
                throw new Exception($"Invalid property mapping. The property \"{returnType.FullName}.{map.PropertyName}\" is read only.");
            property.SetValue(retVal, safeValue);
        }

        /// <summary>
        /// Create an object from one or more sources
        /// </summary>
        /// <typeparam name="T">The type of the object that will be created</typeparam>
        /// <param name="mapping">The mapping that maps the properties of the target object to the source object(s)</param>
        /// <param name="sources">A array of source object that contains the values for the target object's properties Note! The types of the source objects must be unique</param>
        /// <returns></returns>
        public static T CreateObject<T>(ObjectPropertyMap<T> mapping, params object[] sources)
        {
            Type returnType = typeof(T);

            if (returnType.IsGenericType)
            {
                Type sourceType = sources[0].GetType();
                if (sourceType.IsGenericTypeDefinition)
                {
                    Type elementType = sourceType.GenericTypeArguments[0];

                    //Get the generic method to create the return object
                    MethodInfo method = typeof(ObjectFactory).GetMethod("CreateObject", new[] { typeof(ObjectPropertyMap<T>), typeof(IEnumerable<>) });
                    MethodInfo genericMethod = method.MakeGenericMethod(returnType, elementType);

                    //Create and return the created object
                    return (T)genericMethod.Invoke(null, new object[] { mapping, sources[0] });
                }
            }
            if (returnType.IsArray)
                throw new NotImplementedException("Creating a generic type is not implemented yet");
            if (returnType.IsAbstract || returnType.IsInterface)
                throw new InvalidOperationException($"Cannot create an instance of type \"{returnType.FullName}\"");

            //Create the return object
            T retVal = (T)returnType.Assembly.CreateInstance(returnType.FullName);

            if (retVal == null)
                throw new NullReferenceException($"The instance of \"{returnType.FullName}\" failed to instantiate");
            if (mapping == null)
                throw new ArgumentException("Mapping cannot be null");
            else
            {
                foreach (PropertyInfo property in returnType.GetProperties())
                {
                    object source = null;
                    PropertyMap map = mapping.PropertyMaps.Where(m => m.PropertyName == property.Name && m.PropertyType ==property.PropertyType).FirstOrDefault();
                    if (map == null)
                    {
                        //If the property.PropertyType is a nullable type. Nullable is a generic type the first generic argyment is the value type - int? == Nullable<int>, try to get the map of the Nullable<T>.Value type
                        map = mapping.PropertyMaps.Where(m => m.PropertyName == property.Name).FirstOrDefault();
                        if (map != null && !map.PropertyType.IsGenericType)
                        {
                            Type[] argumentTypes = map.PropertyType.GetGenericArguments();
                            if (argumentTypes.Any())
                            {
                                if (map.PropertyType.GetGenericArguments().First() != property.PropertyType)
                                    map = null;
                            }
                        }
                    }
                    if (map != null)
                    {
                        if (map?.Value != null)
                        {
                            object value = map.Value;
                            SetPropertyValue(returnType, retVal, property, map, value);
                        }
                        else if (!string.IsNullOrEmpty(map?.FieldName))
                        {
                            PropertyInfo sProperty = map.SourceType.GetProperty(map.FieldName, map.PropertyType);
                            if(sProperty == null)
                            {
                                //If the mapped object is a nullable type. Nullable is a generic type the first generic argyment is the value type - int? == Nullable<int>, try to get the property of the Nullable<T>.Value type
                                if (map.PropertyType.IsGenericType)
                                {
                                    Type[] argumentTypes = map.PropertyType.GetGenericArguments();
                                    if(argumentTypes.Any())
                                        sProperty = map.SourceType.GetProperty(map.FieldName, argumentTypes.First());
                                }
                            }
                            //Find the object in the parameters that contains the value for this property. The source's type must match the propertiy maps source type
                            object value;
                            bool hasNullObject = false;
                            if (map.SourceType != null)
                            {
                                if (map.SourceType.IsInterface)
                                {
                                    foreach (object obj in sources)
                                    {
                                        if (obj != null)
                                        {
                                            if (obj.GetType().GetInterfaces().Contains(map.SourceType))
                                            {
                                                source = obj;
                                                break;
                                            }
                                        }
                                        else
                                            hasNullObject = true;
                                    }
                                }
                                else
                                    foreach (object obj in sources)
                                    {
                                        if (obj != null)
                                        {
                                            if (obj.GetType() == map.SourceType)
                                            {
                                                source = obj;
                                                break;
                                            }
                                        }
                                        else
                                            hasNullObject = true;
                                    }

                                if (source == null && !hasNullObject)
                                    throw new ArgumentException($"A parameter of type {map.SourceType.Name} was not passed to this function");
                                if (sProperty == null)
                                    throw new ArgumentException("The mapping passed is not valid. The source FieldName is required");
                                if (source != null)
                                {
                                    value = GetSafeValue(property, sProperty.GetValue(source));
                                    if (map.DbType == DbType.String && map.TrimString)
                                        value = ((string)value).Trim();
                                    if (value != null)
                                    {
                                        if (!property.CanWrite)
                                            throw new Exception($"Invalid property mapping. The property \"{returnType.FullName}.{map.PropertyName}\" is read only.");
                                        property.SetValue(retVal, value);
                                    }
                                }
                            }
                        }
                        else //If the type of one of the parameters match the type of the property
                        {
                            Type propertyType, sourceType = null;
                            if (map.PropertyType.IsGenericType)
                            {
                                propertyType = map.PropertyType.GetGenericArguments().FirstOrDefault();
                            }
                            else
                                propertyType = map.PropertyType;
                            foreach (object obj in sources)
                            {
                                if (obj != null)
                                {
                                    Type objType = obj.GetType();
                                    if (objType == typeof(KeyValuePair<string, object>))
                                    {
                                        KeyValuePair<string, object> objKVP = (KeyValuePair<string, object>)obj;
                                        if (objKVP.Key == map.SourceKey)
                                        {
                                            source = objKVP.Value;
                                            if (source != null)
                                            {
                                                sourceType = source.GetType();
                                                sourceType = sourceType.IsGenericType ? sourceType.GetGenericArguments().FirstOrDefault() : sourceType;
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        sourceType = map.SourceType.IsGenericType && map.SourceType != typeof(KeyValuePair<string, object>) ? map.SourceType.GetGenericArguments().FirstOrDefault() : map.SourceType;
                                        if (objType == sourceType)
                                        {
                                            source = obj;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!property.CanWrite)
                                throw new Exception($"Invalid property mapping. The property \"{returnType.FullName}.{map.PropertyName}\" is read only.");
                            if (source != null)
                            {
                                if (source is string && map.TrimString)
                                    source = ((string)source).Trim();
                                property.SetValue(retVal, source);
                            }
                        }
                    }
                }
            }
            return retVal;
        }

        public static void UpdateObject<T>(ref T target, ObjectPropertyMap<T> mapping, params object[] sources)
        {
            Type targetType = typeof(T);

            if (targetType.IsGenericType)
                throw new NotImplementedException("Updating a generic type not implemented yet");
            if (targetType.IsArray)
                throw new NotImplementedException("Updating an array not implemented yet");
            if (target == null)
                throw new ArgumentNullException(nameof(target)); ;
            if (mapping == null)
                throw new ArgumentException("Mapping cannot be null");
            else
            {
                foreach (PropertyInfo property in targetType.GetProperties())
                {
                    object source = null;
                    PropertyMap map = mapping.PropertyMaps.Where(m => m.PropertyName == property.Name && m.PropertyType == property.PropertyType).FirstOrDefault();
                    if (map != null)
                    {
                        if (map?.Value != null)
                        {
                            object value = map.Value;
                            SetPropertyValue(targetType, target, property, map, value);
                        }
                        else if (!string.IsNullOrEmpty(map?.FieldName))
                        {
                            PropertyInfo sProperty = map.SourceType.GetProperty(map.FieldName, map.PropertyType);
                            //Find the object in the parameters that contains the value for this property. The source's type must match the propertiy maps source type
                            object value;
                            bool hasNullObject = false;
                            if (map.SourceType != null)
                            {
                                if (map.SourceType.IsInterface)
                                {
                                    foreach (object obj in sources)
                                    {
                                        if (obj != null)
                                        {
                                            if (obj.GetType().GetInterfaces().Contains(map.SourceType))
                                            {
                                                source = obj;
                                                break;
                                            }
                                        }
                                        else
                                            hasNullObject = true;
                                    }
                                }
                                else
                                    foreach (object obj in sources)
                                    {
                                        if (obj != null)
                                        {
                                            if (obj.GetType() == map.SourceType)
                                            {
                                                source = obj;
                                                break;
                                            }
                                        }
                                        else
                                            hasNullObject = true;
                                    }

                                if (source == null && !hasNullObject)
                                    throw new ArgumentException($"A parameter of type {map.SourceType.Name} was not passed to this function");
                                if (sProperty == null)
                                    throw new ArgumentException("The mapping passed is not valid. The source FieldName is required");
                                if (source != null)
                                {
                                    value = GetSafeValue(property, sProperty.GetValue(source));
                                    if (map.DbType == DbType.String && map.TrimString)
                                        value = ((string)value).Trim();
                                    if (value != null)
                                    {
                                        if (!property.CanWrite)
                                            throw new Exception($"Invalid property mapping. The property \"{targetType.FullName}.{map.PropertyName}\" is read only.");
                                        property.SetValue(target, value);
                                    }
                                }
                            }
                        }
                        else //If the type of one of the parameters match the type of the property
                        {
                            Type propertyType, sourceType = null;
                            if (map.PropertyType.IsGenericType)
                            {
                                propertyType = map.PropertyType.GetGenericArguments().FirstOrDefault();
                            }
                            else
                                propertyType = map.PropertyType;
                            foreach (object obj in sources)
                            {
                                if (obj != null)
                                {
                                    Type objType = obj.GetType();
                                    if (objType == typeof(KeyValuePair<string, object>))
                                    {
                                        KeyValuePair<string, object> objKVP = (KeyValuePair<string, object>)obj;
                                        if (objKVP.Key == map.SourceKey)
                                        {
                                            source = objKVP.Value;
                                            if (source != null)
                                            {
                                                sourceType = source.GetType();
                                                sourceType = sourceType.IsGenericType ? sourceType.GetGenericArguments().FirstOrDefault() : sourceType;
                                            }
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        sourceType = map.SourceType.IsGenericType && map.SourceType != typeof(KeyValuePair<string, object>) ? map.SourceType.GetGenericArguments().FirstOrDefault() : map.SourceType;
                                        if (objType == sourceType)
                                        {
                                            source = obj;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!property.CanWrite)
                                throw new Exception($"Invalid property mapping. The property \"{targetType.FullName}.{map.PropertyName}\" is read only.");
                            if (source != null)
                            {
                                if (source is string && map.TrimString)
                                    source = ((string)source).Trim();
                                property.SetValue(target, source);
                            }
                        }
                    }
                }
            }
        }

        public static T CreateGenericObject<T,S>(ObjectPropertyMap<T> mapping, IEnumerable<S> source)
        {
            Type returnType = typeof(T);
            Type elementType = returnType.GenericTypeArguments.Last();
            
            //Check if it is possible to create the object
            if (returnType.IsAbstract || returnType.IsInterface)
                throw new InvalidOperationException($"Cannot create an instance of type \"{returnType.FullName}\"");

            //Create an instance of the return type
            T retVal = (T)Activator.CreateInstance(returnType);

            //Get the generic method to create the child elements
            MethodInfo method = typeof(ObjectFactory).GetMethod("CreateObject", new[] { typeof(ObjectPropertyMap<T>), typeof(object[]) });
            MethodInfo genericMethod = method.MakeGenericMethod(elementType);

            //Get the add method for the return type
            MethodInfo addMethod = returnType.GetMethod("Add");

            foreach(S sourceElement in source)
            {
                object element = genericMethod.Invoke(null, new object[] { mapping, sourceElement });
                if (returnType.GenericTypeArguments.Length == 1)
                {
                    addMethod.Invoke(retVal, new object[] { element });
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            return retVal;
        }

        public static T CreateGenericObject<T>(IDataReader reader, List<PropertyMap> propertyMaps)
		{
			Type returnType = typeof(T);
			Type elementType = returnType.GenericTypeArguments.Last();
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
				if (returnType.GenericTypeArguments.Length == 1)
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
			return (T)toArrayMethod.Invoke(listObject, Array.Empty<object>());
		}

		public static T CreateList<T>(IDataReader reader, List<PropertyMap> propertyMaps)
		{
			Type returnType = typeof(T);
			Type elementType = returnType.BaseType == typeof(Array) ? returnType.GetElementType() : returnType.IsGenericType ? returnType.GenericTypeArguments.First() : null;
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
