
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace SEFI.Extensions
{
    public static class GenericExtensionMethods
    {

        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }

        public static string GetEnumDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static string GetEnumCategory<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var categoryAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(CategoryAttribute), false)
                            .FirstOrDefault() as CategoryAttribute;

                        if (categoryAttribute != null)
                        {
                            return categoryAttribute.Category;
                        }
                    }
                }
            }

            return string.Empty;
        }

        public static T GetEnumByDescription<T>(this string description)
        {
            Type type = typeof(T);
            if (type.IsEnum)
            {
                Array values = System.Enum.GetValues(type);
                foreach (int val in values)
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttribute = memInfo[0]
                        .GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .FirstOrDefault() as DescriptionAttribute;

                    if (descriptionAttribute != null)
                    {
                        if (descriptionAttribute.Description == description)
                            return (T)Convert.ChangeType(val, typeof(T));
                    }
                }
            }
            return default(T);
        }
    }
}


