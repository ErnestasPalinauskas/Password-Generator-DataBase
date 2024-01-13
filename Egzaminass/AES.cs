using System;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlTypes;

namespace AES
{
    public class CreateAES
    {
        // Konstantos
        private const int KeySize = 256;
        private const int BlockSize = 128;
        private const int Iterations = 60000;

        // Privati funkcija AES objekto kūrimui
        private Aes CreateAes(string stringkey, byte[] salt)
        {
            Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(stringkey, salt, Iterations);
            Aes Aes = Aes.Create();
            Aes.KeySize = KeySize;
            Aes.BlockSize = BlockSize;
            Aes.Mode = CipherMode.CBC;
            Aes.Padding = PaddingMode.PKCS7;
            Aes.Key = rfc.GetBytes(32);
            Aes.IV = rfc.GetBytes(16);
            return Aes;
        }

        // Šifravimo funkcija
        public string EncryptAES(string plainText, string stringkey, byte[] salt)
        {
            byte[] encrypted;
            using (Aes myAes = CreateAes(stringkey, salt))
            {
                ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                            writer.Flush();
                        }
                    }
                    encrypted = memoryStream.ToArray();
                }
            }
            return BitConverter.ToString(encrypted);
        }

        // Dešifravimo funkcija
        public string DecryptAES(string text, string stringkey, byte[] salt)
        {
            String[] arr = text.Split('-');
            byte[] cyphertext = new byte[arr.Length];
            for (int i = 0; i < arr.Length; i++) cyphertext[i] = Convert.ToByte(arr[i], 16);

            string result = string.Empty;
            using (Aes myAes = CreateAes(stringkey, salt))
            {
                ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);
                using (MemoryStream memoryStream = new MemoryStream(cyphertext))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }
    }
}
