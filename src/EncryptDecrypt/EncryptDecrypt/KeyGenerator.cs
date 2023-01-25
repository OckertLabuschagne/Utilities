using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SEFI.Encryption
{
    public static class KeyGenerator
    {
        private static byte[] _IVBytes = new byte[] {1, 3, 6, 23, 45, 16, 78, 20, 194, 78, 209, 39, 69, 74, 123, 43};
        private static int _Salt = 509;
        private static int _Length = 8;

        public static string EncryptKey(int salt, int length, params int[] values)
        {
            if (values == null || values.Length == 0)
                return null;
            Random rnd = new Random(salt);
            int offset = rnd.Next(0, 10);
            string seperator = $"{rnd.Next(33, 48)}";

            string toEncrypt = "";
            List<string> valStrings = new List<string>();
            foreach (int val in values)
            {
                string valstring = $"{val + offset:X}";
                while(valstring.Length < 4)
                    valstring += (char)rnd.Next(71, 91);
                valStrings.Add(valstring);
            }
            toEncrypt = string.Join(seperator, valStrings);
            while(toEncrypt.Length < length)
            {
                toEncrypt += (char)rnd.Next(71, 91);
            }
            return toEncrypt;
        }

        public static string EncryptKey(params int[] values)
        {
            if (values == null || values.Length == 0)
                return null;
            Random rnd = new Random(_Salt);
            int offset = rnd.Next(0, 10);
            string seperator = $"{rnd.Next(33, 48)}";

            string toEncrypt = "";
            List<string> valStrings = new List<string>();
            foreach (int val in values)
            {
                string valstring = $"{val + offset:X}";
                while (valstring.Length < 4)
                    valstring += (char)rnd.Next(71, 91);
                valStrings.Add(valstring);
            }
            toEncrypt = string.Join(seperator, valStrings);
            while (toEncrypt.Length < _Length)
            {
                toEncrypt += (char)rnd.Next(71, 91);
            }
            return toEncrypt;
        }

        public static string EncryptKey(int? value)
        {
            if (value == null)
                return null;
            Random rnd = new Random(_Salt);
            int offset = rnd.Next(0, 10);
            string valstring = $"{value + offset:X}";
            while (valstring.Length < 4)
                valstring += (char)rnd.Next(71, 91);
            string toEncrypt = valstring;
            while (toEncrypt.Length < _Length)
            {
                toEncrypt += (char)rnd.Next(71, 91);
            }
            return toEncrypt;
        }

        public static void DecryptKey(int salt, string encryptedKey, out int[] values)
        {
            if (string.IsNullOrEmpty(encryptedKey))
            {
                values = null;
                return;
            }
            List<int> vals = new List<int>();
            Random rnd = new Random(salt);
            int offset = rnd.Next(0, 10);
            char seperator = (char)rnd.Next(33, 48);
            string[] parts = encryptedKey.Split(seperator);
            int val;
            foreach(string part in parts)
            {
                string intString = part;
                for (int i = 71; i < 91; i++)
                    intString = intString.Replace($"{(char)i}", "");
                if (int.TryParse(intString, NumberStyles.HexNumber, new CultureInfo("en-US"), out val))
                    vals.Add(val - offset);
            }
            values = vals.ToArray();
        }

        public static int? DecryptKey(int salt, string encryptedKey)
        {
            if (string.IsNullOrEmpty(encryptedKey))
                return null;
            List<int> vals = new List<int>();
            Random rnd = new Random(salt);
            int offset = rnd.Next(0, 10);
            char seperator = (char)rnd.Next(33, 48);
            string[] parts = encryptedKey.Split(seperator);
            int val;
            foreach (string part in parts)
            {
                string intString = part;
                for (int i = 71; i < 91; i++)
                    intString = intString.Replace($"{(char)i}", "");
                if (int.TryParse(intString, NumberStyles.HexNumber, new CultureInfo("en-US"), out val))
                    vals.Add(val - offset);
            }
            return vals.FirstOrDefault();
        }

        public static int? DecryptKey(string encryptedKey)
        {
            if (string.IsNullOrEmpty(encryptedKey))
                return null;
            List<int> vals = new List<int>();
            Random rnd = new Random(_Salt);
            int offset = rnd.Next(0, 10);
            char seperator = (char)rnd.Next(33, 48);
            string[] parts = encryptedKey.Split(seperator);
            int val;
            foreach (string part in parts)
            {
                string intString = part;
                for (int i = 71; i < 91; i++)
                    intString = intString.Replace($"{(char)i}", "");
                if (int.TryParse(intString, NumberStyles.HexNumber, new CultureInfo("en-US"), out val))
                    vals.Add(val - offset);
            }
            return vals.FirstOrDefault();
        }
    }
}
