using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace SEFI.Extensions
{
    public static class StringExtensions
    {
        public static string ToCSVString<T>(this List<T> list, char seperator = ',', char stringDelimiter = '"')
        {
            StringBuilder retVal = new StringBuilder();
            bool isFirst = true;
            foreach (T val in list)
            {
                if (isFirst)
                    isFirst = false;
                else
                    retVal.Append(seperator);
                if (typeof(T) == typeof(string))
                    retVal.Append($"{stringDelimiter}{(val as string).Replace("\"", "\"\"")}{stringDelimiter}");
                else
                    retVal.Append(val);
            }
            return retVal.ToString();
        }
        public static string DoFormat(this string formatString, params object[] parameters)
        {
            return string.Format(formatString, parameters);
        }

        public static bool IsAplhaOnly(this string value)
        {
            Regex rg = new Regex(@"^[a-zA-Z]*$");
            return rg.IsMatch(value);
        }

        public static bool IsAplhaNumeric(this string value)
        {
            Regex rg = new Regex(@"^[a-zA-Z0-9.-]*$");
            return rg.IsMatch(value);
        }

        public static bool IsNumeric(this string value)
        {
            Regex rg = new Regex(@"^[0-9.-]*$");
            return rg.IsMatch(value);
        }

        public static bool IsInteger(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return int.TryParse(value, out int o);
            return false;
        }

        public static bool IsNullableInteger(this string value)
        {
            if (value == null)
                return true;
            else if (!string.IsNullOrEmpty(value))
                return int.TryParse(value, out int o);
            return false;
        }

        public static bool IsLongInt(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return long.TryParse(value, out long o);
            return false;
        }

        public static bool IsNullableLongInt(this string value)
        {
            if (value == null)
                return true;
            else if (!string.IsNullOrEmpty(value))
                return long.TryParse(value, out long o);
            return false;
        }

        public static bool IsWholeNumber(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                long o;
                if (long.TryParse(value, out o))
                    return o > 0;
                else
                    return false;
            }
            return false;
        }

        public static bool IsNullableWholeNumber(this string value)
        {
            if (value == null)
                return true;
            else if (!string.IsNullOrEmpty(value))
            {
                int o;
                if (int.TryParse(value, out o))
                    return o > 0;
                else
                    return false;
            }
            return false;
        }

        public static bool IsDecimal(this string value)
        {
            if (!string.IsNullOrEmpty(value))
                return decimal.TryParse(value, out decimal o);
            return false;
        }

        public static bool IsNullableDecimal(this string value)
        {
            if (value == null)
                return true;
            else if (!string.IsNullOrEmpty(value))
                return decimal.TryParse(value, out decimal o);
            return false;
        }

        public static string TrimIfNotNull(this string value)
        {
            return value == null ? value : value.Trim();
        }

        public static T NullIfEmptyElse<T>(this string value, T nullValue)
        {
            if (value is null)
                return nullValue;
            if (string.IsNullOrEmpty(value))
                return default(T);
            else if (typeof(T) == typeof(int))
                return (T)Convert.ChangeType(value.ToNullableInt(), typeof(int));
            else if (typeof(T) == typeof(int?))
                return (T)Convert.ChangeType(value.ToNullableDecimal(), typeof(int));
            else if (typeof(T) == typeof(decimal))
                return (T)Convert.ChangeType(value.ToNullableInt(), typeof(decimal));
            else if (typeof(T) == typeof(decimal?))
                return (T)Convert.ChangeType(value.ToNullableDecimal(), typeof(decimal));
            else if (typeof(T) == typeof(DateTime))
                return (T)Convert.ChangeType(value.ToNullableDate(), typeof(DateTime));
            else if (typeof(T) == typeof(DateTime?))
                return (T)Convert.ChangeType(value.ToNullableDate(), typeof(DateTime));
            else if (typeof(T) == typeof(bool))
                return (T)Convert.ChangeType(value.ToNullableBool(), typeof(bool));
            else if (typeof(T) == typeof(bool?))
                return (T)Convert.ChangeType(value.ToNullableBool(), typeof(bool));
            else
                return (T)Convert.ChangeType(value, typeof(T));
        }

        public static string GetStringBetween(this string token, string first, string second)
        {
            if (!token.Contains(first)) return "";

            var afterFirst = token.Split(new[] { first }, StringSplitOptions.None)[1];

            if (!afterFirst.Contains(second)) return "";

            var result = afterFirst.Split(new[] { second }, StringSplitOptions.None)[0];

            return result;
        }

        public static string SetToEmptyStringIfNull(this string value)
        {
            var newVal = value == null ? value : value.Trim();
            if (string.IsNullOrWhiteSpace(newVal)) newVal = string.Empty;

            return newVal;
        }

        public static bool IsDate(this string input, bool ignoreNull = false)
        {
            if (!string.IsNullOrEmpty(input))
            {
                return (DateTime.TryParse(input, out DateTime dt));
            }
            else
            {
                if (ignoreNull) return true;
                return false;
            }
        }

        public static string ToISODate(this DateTime? t)
        {
            return t.HasValue ? t.Value == DateTime.MinValue ? null : t.Value.ToString("yyyy-MM-dd") : null;
        }

        public static string ToISODateTime(this DateTime? t, bool includeTimeZone = false, bool is24ourFormat = true)
        {
            string formatString = !includeTimeZone ? is24ourFormat ? "yyyy-MM-ddTHH:mm:ss.fff" : "yyyy-MM-ddThh:mm:ss.fff ttt" : is24ourFormat ? "yyyy-MM-ddTHH:mm:ss.fff zzz" : "yyyy-MM-ddThh:mm:ss.fff ttt zzz";
            return t.HasValue ? t.Value == DateTime.MinValue ? null : t.Value.ToString(formatString) : null;
        }

        public static string ToISODate(this DateTime t)
        {
            return t.ToString("yyyy-MM-dd");
        }

        public static string ToISODateTime(this DateTime t, bool includeTimeZone = false, bool is24ourFormat = true)
        {
            string formatString = !includeTimeZone ? is24ourFormat ? "yyyy-MM-ddTHH:mm:ss.fff" : "yyyy-MM-ddThh:mm:ss.fff ttt" : is24ourFormat ? "yyyy-MM-ddTHH:mm:ss.fff zzz" : "yyyy-MM-ddThh:mm:ss.fff ttt zzz";
            return t.ToString(formatString);
        }

        public static string ToStringSafe(this DateTime? t, bool isShortDateFormat = false)
        {
            if (isShortDateFormat)
            {
                return t.HasValue ? t.Value == DateTime.MinValue ? string.Empty : t.Value.ToString("MM/dd/yyyy") : String.Empty;
            }
            else
            {
                return t.HasValue ? t.Value == DateTime.MinValue ? string.Empty : t.Value.ToString("s") : String.Empty;
            }

        }

        public static bool IsNumeric(this string theValue, bool ignoreNull = false)
        {

            if (theValue == null && ignoreNull) return true;

            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out long retNum);
        }

        public static int? ToNullableInt(this string intString)
        {
            if (int.TryParse(intString, out int intVal))
                return intVal;
            return null;
        }

        public static decimal? ToNullableDecimal(this string intString)
        {
            if (decimal.TryParse(intString, out decimal decimalVal))
                return decimalVal;
            return null;
        }

        public static DateTime? ToNullableDate(this String dateString)
        {
            if (String.IsNullOrEmpty((dateString ?? "").Trim()))
                return null;

            if (DateTime.TryParse(dateString, out DateTime resultDate))
                return resultDate;

            return null;
        }

        public static bool? ToNullableBool(this string value)
        {
            if (bool.TryParse(value, out bool retVal))
                return retVal;
            return null;
        }

        public static bool IsValidEmailAddress(this string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool IsConvertableTo<T>(this string value)
        {
            try
            {
                T val = (T)Convert.ChangeType(value, typeof(T));
                return val != null;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
    }
}
