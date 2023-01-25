using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Security;
using System.Globalization;

namespace EncryptDecrypt
{
    public partial class Form1 : Form
    {
        private int intSaltLen = 5;
        private const string PWD_SUFFIX_NEW = "1F3n!%zy";
        private const int _encSalt = 509;
        private const int _encLength = 8;
        private static byte[] _IVBytes = new byte[] { 1, 3, 6, 23, 45, 16, 78, 20, 194, 78, 209, 39, 69, 74, 123, 43 };
        public Form1()
        {
            InitializeComponent();
        }

        public  string Encrypt(string strStringToEncrypt)
        {
            if (strStringToEncrypt == null || strStringToEncrypt.Length == 0)
            {
                return "";
            }

            SymmetricAlgorithm objCryptoService = new TripleDESCryptoServiceProvider();
            objCryptoService.Mode = CipherMode.CBC;
            byte[] btToEncrypt = System.Text.ASCIIEncoding.ASCII.GetBytes(GenerateSeed2() + strStringToEncrypt + GenerateSeed2());

            objCryptoService.Key = GetLegalKey(objCryptoService);
            objCryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };

            using (ICryptoTransform objTransform = objCryptoService.CreateEncryptor())
            using (System.IO.MemoryStream objMS = new System.IO.MemoryStream())
            {
                CryptoStream objCS = new CryptoStream(objMS, objTransform, CryptoStreamMode.Write);

                objCS.Write(btToEncrypt, 0, btToEncrypt.Length);
                objCS.FlushFinalBlock();

                byte[] btEncrypted = objMS.ToArray();

                return Convert.ToBase64String(btEncrypted, 0, btEncrypted.Length);
            }
        }
        private  string GenerateSeed2()
        {
            byte[] rndHlp = new byte[intSaltLen];

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(rndHlp);

            return System.Text.ASCIIEncoding.ASCII.GetString(rndHlp);
        }
        private static byte[] GetLegalKey(SymmetricAlgorithm objCryptoService)
        {
            string strKey = PWD_SUFFIX_NEW;
            // Adjust key if necessary, and return a valid key
            if (objCryptoService.LegalKeySizes.Length > 0)
            {
                // Key sizes in bits
                int intKeySize = strKey.Length * 8;
                int intMinSize = objCryptoService.LegalKeySizes[0].MinSize;
                int intMaxSize = objCryptoService.LegalKeySizes[0].MaxSize;
                int intSkipSize = objCryptoService.LegalKeySizes[0].SkipSize;

                if (intKeySize > intMaxSize)
                {
                    // Extract maximum size allowed
                    strKey = strKey.Substring(0, intMaxSize / 8);
                }
                else if (intKeySize < intMaxSize)
                {
                    // Set valid size
                    int intValidSize = (intKeySize <= intMinSize) ? intMinSize :
                        (intKeySize - intKeySize % intSkipSize) + intSkipSize;
                    if (intKeySize < intValidSize)
                    {
                        // Pad the key with asterisk to make up the size
                        strKey = strKey.PadRight(intValidSize / 8, '*');
                    }
                }
            }
            return System.Text.Encoding.ASCII.GetBytes(strKey);
        }
        public string Decrypt(string strStringToDecrypt)
        {
            if (strStringToDecrypt == null || strStringToDecrypt.Length == 0)
            {
                return "";
            }

            string strRet = "";
            try
            {
                SymmetricAlgorithm objCryptoService = new TripleDESCryptoServiceProvider();
                objCryptoService.Mode = CipherMode.CBC;
                byte[] btToDecrypt = Convert.FromBase64String(strStringToDecrypt);

                objCryptoService.Key = GetLegalKey(objCryptoService);
                objCryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };

                using (ICryptoTransform objTransform = objCryptoService.CreateDecryptor())
                using (System.IO.MemoryStream objMS = new System.IO.MemoryStream(btToDecrypt, 0, btToDecrypt.Length))
                {

                    CryptoStream objCS = new CryptoStream(objMS, objTransform, CryptoStreamMode.Read);

                    // Get the result from the Crypto stream
                    System.IO.StreamReader objSR = new System.IO.StreamReader(objCS);
                    strRet = objSR.ReadToEnd();
                    return strRet.Substring(intSaltLen, strRet.Length - intSaltLen - intSaltLen);
                }
            }
            catch (Exception ex)
            {
            }
            return null;
            //try
            //{
            //    strRet = DecryptOld(strStringToDecrypt);
            //    if (strRet == null)
            //    {
            //        strRet = "";
            //    }
            //}
            //catch { }

            //if (strRet != "")
            //{
            //    return strRet;
            //}

            //try
            //{
            //    if (strRet == "")
            //    {
            //        strRet = DecryptRC4(strStringToDecrypt);
            //    }
            //    return strRet;
            //}
            //catch
            //{
            //    return strStringToDecrypt;
            //}
        }

        private void BtnEncrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbUnEncrypted.Text))
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                txtbEncrypted.Text = Encrypt(txtbUnEncrypted.Text);
        }

        private void BtnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbEncrypted.Text))
                MessageBox.Show("", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                txtbUnEncrypted.Text = Decrypt(txtbEncrypted.Text);
        }

        private void btnEncryptId_Click(object sender, EventArgs e)
        {
            txtbEnctyptedId.Text = EncryptKey(int.Parse(txtbId.Text));
        }

        private void btnDescyptId_Click(object sender, EventArgs e)
        {
            int[] values;
            DecryptKey(_encSalt, txtbEnctyptedId.Text, out values);
            txtbId.Text = $"{values[0]}";
        }

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
                while (valstring.Length < 4)
                    valstring += (char)rnd.Next(71, 91);
                valStrings.Add(valstring);
            }
            toEncrypt = string.Join($"{seperator}", valStrings);
            while (toEncrypt.Length < length)
            {
                toEncrypt += (char)rnd.Next(71, 91);
            }
            return toEncrypt;
        }

        public static string EncryptKey(params int[] values)
        {
            if (values == null || values.Length == 0)
                return null;
            Random rnd = new Random(_encSalt);
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
            while (toEncrypt.Length < _encLength)
            {
                toEncrypt += (char)rnd.Next(71, 91);
            }
            return toEncrypt;
        }

        public static string EncryptKey(int? value)
        {
            if (value == null)
                return null;
            Random rnd = new Random(_encSalt);
            int offset = rnd.Next(0, 10);
            string valstring = $"{value + offset:X}";
            while (valstring.Length < 4)
                valstring += (char)rnd.Next(71, 91);
            string toEncrypt = valstring;
            while (toEncrypt.Length < _encLength)
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
            foreach (string part in parts)
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
            Random rnd = new Random(_encSalt);
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
