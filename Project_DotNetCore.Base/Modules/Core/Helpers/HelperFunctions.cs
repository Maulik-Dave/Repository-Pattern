using System;
using System.Security.Cryptography;
using System.Text;

namespace Project_DotNetCore.Base.Modules.Core.Helpers
{
    public class HelperFunctions
    {
        public static string GenerateRandomPassword(int length = 10)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }

        public static string CreateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        public static string EncryptPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                var getbasestring = Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
                return getbasestring;
            }
        }

        //public static string DecryptText(string cipherText, string encryptionPrivateKey = "273ece6f97dd844d")
        //{
        //    if (String.IsNullOrEmpty(cipherText))
        //        return cipherText;

        //    var tDESalg = new TripleDESCryptoServiceProvider();
        //    tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
        //    tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

        //    byte[] buffer = Convert.FromBase64String(cipherText);
        //    return DecryptTextFromMemory(buffer, tDESalg.Key, tDESalg.IV);
        //}

        //public static string EncryptText(string plainText, string encryptionPrivateKey = "273ece6f97dd844d")
        //{
        //    if (string.IsNullOrEmpty(plainText))
        //        return plainText;

        //    var tDESalg = new TripleDESCryptoServiceProvider();
        //    tDESalg.Key = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(0, 16));
        //    tDESalg.IV = new ASCIIEncoding().GetBytes(encryptionPrivateKey.Substring(8, 8));

        //    byte[] encryptedBinary = EncryptTextToMemory(plainText, tDESalg.Key, tDESalg.IV);
        //    return Convert.ToBase64String(encryptedBinary);
        //}

        //private static byte[] EncryptTextToMemory(string data, byte[] key, byte[] iv)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateEncryptor(key, iv), CryptoStreamMode.Write))
        //        {
        //            byte[] toEncrypt = new UnicodeEncoding().GetBytes(data);
        //            cs.Write(toEncrypt, 0, toEncrypt.Length);
        //            cs.FlushFinalBlock();
        //        }

        //        return ms.ToArray();
        //    }
        //}

        //private static string DecryptTextFromMemory(byte[] data, byte[] key, byte[] iv)
        //{
        //    using (var ms = new MemoryStream(data))
        //    {
        //        using (var cs = new CryptoStream(ms, new TripleDESCryptoServiceProvider().CreateDecryptor(key, iv), CryptoStreamMode.Read))
        //        {
        //            var sr = new StreamReader(cs, new UnicodeEncoding());
        //            return sr.ReadLine();
        //        }
        //    }
        //}      
    }
}
