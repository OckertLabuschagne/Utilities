using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUtilities
{
    public class Utilities
    {
        public static string List2CSV<T>(List<T> list, char textDelimmiter = '"', char fieldSeperator = ',')
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach(object value in list)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(fieldSeperator);
                if (value is string)
                    retVal.Append($"{textDelimmiter}{value}{textDelimmiter}");
                else if (value is Guid)
                    retVal.Append($"{textDelimmiter}{value}{textDelimmiter}");
                else
                    retVal.Append(value);
            }
            return retVal.ToString();
        }

        public static List<T> CSV2List<T>(string valueString, char textDelimmiter = '"', char fieldSeperator = ',')
        {
            List<T> retval = new List<T>();
            if (string.IsNullOrEmpty(valueString))
                return retval;
            string[] values = valueString.Split(fieldSeperator);
            foreach(string value in values)
            {
                T val = default(T);
                if(value[0] == textDelimmiter)
                {
                    if(value[value.Length - 1] == textDelimmiter)
                    {
                        val = (T)(Convert.ChangeType(value.Trim(textDelimmiter), typeof(T)));
                    }
                    
                }
                else if (typeof(T).IsEnum)
                {
                    val = (T)Enum.Parse(typeof(T), value);
                }
                else
                    val = (T)(Convert.ChangeType(value, typeof(T)));
                retval.Add(val);
            }
            return retval;
        }
    }
}
