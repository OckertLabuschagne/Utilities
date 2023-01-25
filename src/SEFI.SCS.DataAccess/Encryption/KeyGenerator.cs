using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

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
            char seperator = (char)rnd.Next(33, 48);

            string toEncrypt = "";
            List<string> valStrings = new List<string>();
            foreach (int val in values)
            {
                string valstring = $"{val + offset:X}";
                while(valstring.Length < 4)
                    valstring += (char)rnd.Next(71, 91);
                valStrings.Add(valstring);
            }
            toEncrypt = string.Join($"{seperator}", valStrings);
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
            char seperator = (char)rnd.Next(33, 48);

            string toEncrypt = "";
            List<string> valStrings = new List<string>();
            foreach (int val in values)
            {
                string valstring = $"{val + offset:X}";
                while (valstring.Length < 4)
                    valstring += (char)rnd.Next(71, 91);
                valStrings.Add(valstring);
            }
            toEncrypt = string.Join($"{seperator}", valStrings);
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

        private static int _timeByteLength = 5;
        public static string EncryptData(int length, string value)
        {
            if (value.Length > length)
                throw new Exception("Value length is greater than configured length");

            var bytes = Encoding.ASCII.GetBytes(value.PadRight(length + _timeByteLength + 1));
            var jlen = _IVBytes.Length;
            byte rollOver = 0;

            var epochBytes = GetEpochTime();

            for (int i = 0; i < _timeByteLength; i++)
                bytes[length + i] = epochBytes[i];

            var updated = Encoding.ASCII.GetString(bytes);

            for (int n = 0; n < length + _timeByteLength; n++)
                for (int i = 0; i < length + _timeByteLength; i++)
                    for (int j = 0; j < jlen; j += 2)
                        EorAddRollLeft(ref bytes[i], j, ref rollOver);

            bytes[length + _timeByteLength] = rollOver;
            return Convert.ToBase64String(bytes);
        }

        private static byte[] GetEpochTime()
        {
            DateTime now = DateTime.Now;
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var tsEpoch = now - epoch;
            var seconds = (long)tsEpoch.TotalSeconds;
            return BitConverter.GetBytes(seconds);
        }

        private static void EorAddRollLeft(ref byte byt, int j, ref byte rollOver)
        {
            byt = (byte)(byt ^ _IVBytes[j]);
            if (j + 1 < _IVBytes.Length)
                if (byt + _IVBytes[j + 1] > 255)
                    byt = (byte)(byt + _IVBytes[j + 1] - 256);
                else
                    byt = (byte)(byt + _IVBytes[j + 1]);

            if (byt * 2 > 255)
            {
                byt = (byte)(byt * 2 + rollOver - 256);
                rollOver = 1;
            }
            else
            {
                byt = (byte)(byt * 2 + rollOver);
                rollOver = 0;
            }
        }

        public static string DecryptData(int length, string value)
        {
            byte[] data;

            try
            {
                data = Convert.FromBase64String(value);
            }
            catch
            {
                // it means this string is not really encrypted nor is it base64 format
                return value;
            }

            if (data.Length != length + _timeByteLength + 1)
                return value; // it means this string is not really encrypted

            byte rollOver = data[length + _timeByteLength];
            var bytes = new byte[length + _timeByteLength];
            Array.Copy(data, bytes, length + _timeByteLength);

            for (int n = 0; n < length + _timeByteLength; n++)
                for (int i = length + _timeByteLength - 1; i >= 0; i--)
                    for (int j = _IVBytes.Length - 1; j >= 1; j -= 2)
                        RollRightSubtractEor(ref bytes[i], j, ref rollOver);

            return Encoding.ASCII.GetString(bytes).Substring(0, length).Trim();
        }

        private static void RollRightSubtractEor(ref byte byt, int j, ref byte rollOver)
        {
            byte previousRollOver = (byte)(byt & 1);
            byt = (byte)(byt / 2 + rollOver * 128);
            rollOver = previousRollOver;

            if (byt - _IVBytes[j] < 0)
                byt = (byte)(byt - _IVBytes[j] + 256);
            else
                byt = (byte)(byt - _IVBytes[j]);

            if (j - 1 >= 0)
                byt = (byte)(byt ^ _IVBytes[j - 1]);
        }
    }
}
