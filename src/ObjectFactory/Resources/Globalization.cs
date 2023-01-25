using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Newtonsoft.Json;

namespace SEFI.Resources
{
    public class Globalization
    {
        public static T Parse<T>(TextReader reader)
        {
            return Parse<T>(reader.ReadToEnd());
        }

        public static T Parse<T>(string resourceString)
        {
            Dictionary<string, string> messages = JsonConvert.DeserializeObject<Dictionary<string, string>>(resourceString);
            Type type = typeof(T);
            T retval = (T)type.Assembly.CreateInstance(type.FullName);
            foreach (KeyValuePair<string, string> message in messages)
            {
                PropertyInfo property = type.GetProperty(message.Key);
                if (property != null)
                    property.SetValue(retval, message.Value);
            }
            return retval;
        }
    }
}
