using System;
using System.Collections.Generic;
using System.Text;

using SEFI.Mappings;

namespace SEFI.Exceptions
{
    [Serializable]
    public class InvalidPropertyMapExpression : Exception
    {
        public InvalidPropertyMapExpression() { }
        public InvalidPropertyMapExpression(object value, PropertyMap propertyMap)
        {
            _ValueType = value?.GetType();
            PropertyMap = propertyMap;
        }

        readonly Type _ValueType;

        public object Value { get; set; }
        public PropertyMap PropertyMap { get; set; }

        public override string ToString()
        {
            if (PropertyMap == null)
                return "Property map is not provided";
            if(_ValueType == null)
                return "Value type is unknown";
            return $"Invalid object property mapping. {_ValueType.FullName} does not contain a property named {PropertyMap.PropertyName}";
        }
    }
}
