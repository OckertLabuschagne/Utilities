using System;

using SEFI.Mappings;

namespace SEFI.Exceptions
{
    [Serializable]
    public class InvalidMappingExpression<T> : Exception
    {
        public InvalidMappingExpression()
        { }

        public InvalidMappingExpression(ObjectPropertyMap<T> objectMap, PropertyMap propertyMap)
        {
            _ValueType = typeof(T);
            ObjectMap = objectMap;
            PropertyMap = propertyMap;
        }

        public InvalidMappingExpression(T value, PropertyMap propertyMap)
        {
            Value = value;
            _ValueType = typeof(T);
            PropertyMap = propertyMap;
        }

        Type _ValueType;

        public T Value { get; set; }
        public ObjectPropertyMap<T> ObjectMap { get; set; }
        public PropertyMap PropertyMap { get; set; }

        public override string ToString()
        {
            return $"Invalid object property mapping. {_ValueType?.FullName ?? ""} does not contain a property named {PropertyMap?.PropertyName ?? "No Name"}";
        }
    }
}
