using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITester.Models.Extensions
{
    public static class ArrayExtensions
    {
        public static string ArrayToCSV<T>(this T[] values, char seperator)
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach(T value in values)
            {
                if(isFirst) isFirst = false;
                else retVal.Append(seperator);
                retVal.Append($"{value}");
            }
            return retVal.ToString();
        }
    }
}
