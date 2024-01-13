using System;
using System.Security.Cryptography;
using System.Text;

namespace SHA256Hash
{
    public class Hashing
    {
        // Konstanta iteracijų skaičiui
        private const int Iterations = 40000;

        // Konstanta baitų skaičiui
        private const int ByteSize = 32;

        // Funkcija slaptažodžio maišos kodui generuoti
        public string Hash(string text, byte[] salt)
        {
            // Sukuriamas Rfc2898DeriveBytes objektas
            using (Rfc2898DeriveBytes rfc = new Rfc2898DeriveBytes(text, salt, Iterations))
            {
                byte[] textBytes = rfc.GetBytes(ByteSize);

                // Sukuriamas SHA256 objektas
                using (SHA256 mySHA256 = SHA256.Create())
                {
                    byte[] result = mySHA256.ComputeHash(textBytes);

                    // Konvertuojame baitų masyvą į šešioliktainę eilutę
                    return BitConverter.ToString(result).Replace("-", "").ToLower();
                }
            }
        }
    }
}
