using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
namespace APITester.Models.Extensions
{
    public static class StringExtensions
    {
        public static string[] CSVToArray(this string value)
        {
            return CSV2List<string>(value).ToArray();
        }

        public static List<T> CSV2List<T>(this string values)
        {
            Type type = typeof(T);
            List<T> retVal = new List<T>();
            if (values != null)
            {
                string[] _values = values.Split(',');
                foreach (string val in _values)
                {
                    try
                    {
                        retVal.Add((T)Convert.ChangeType(val, type));
                    }
                    catch (Exception excp)
                    {
                        retVal.Add(default);
                    }
                }
            }
            return retVal;
        }

        public static string JsonPrettify(this string json)
        {
            try
            {
                if (string.IsNullOrEmpty(json))
                    return null;
                using (var stringReader = new StringReader(json))
                using (var stringWriter = new StringWriter())
                {
                    var jsonReader = new JsonTextReader(stringReader);
                    var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = Formatting.Indented };
                    jsonWriter.WriteToken(jsonReader);
                    return stringWriter.ToString();
                }
            }
            catch 
            {
                return "";
            }
        }
    }
}
