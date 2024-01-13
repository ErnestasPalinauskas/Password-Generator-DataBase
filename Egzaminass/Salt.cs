using System;
using System.Security.Cryptography;

namespace Salt
{
    public class Salt
    {
        // Konstanta salt dydžiui
        private const int SaltSize = 16;

        // Funkcija salt generavimui
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
