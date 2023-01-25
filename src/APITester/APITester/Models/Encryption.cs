using System;
using System.Security.Cryptography;
using System.IO;

namespace APITester.Models
{
    public class Encryption
    {
        private const int intSaltLen = 5;
        private const string PWD_SUFFIX_NEW = "1F3n!%zy";
        private const int _encSalt = 509;
        private const int _encLength = 8;
        private static byte[] _IVBytes = new byte[] { 1, 3, 6, 23, 45, 16, 78, 20, 194, 78, 209, 39, 69, 74, 123, 43 };

        public static string Encrypt(string strStringToEncrypt)
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
            using (MemoryStream objMS = new MemoryStream())
            {
                CryptoStream objCS = new CryptoStream(objMS, objTransform, CryptoStreamMode.Write);

                objCS.Write(btToEncrypt, 0, btToEncrypt.Length);
                objCS.FlushFinalBlock();

                byte[] btEncrypted = objMS.ToArray();

                return Convert.ToBase64String(btEncrypted, 0, btEncrypted.Length);
            }
        }

        private static string GenerateSeed2()
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

        public static string Decrypt(string strStringToDecrypt)
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
        }
    }
}
