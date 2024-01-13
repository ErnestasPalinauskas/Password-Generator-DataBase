using System;
using System.Linq;

namespace SlaptGen
{
    public class PasswordGenerator
    {
        // Konstantos simbolių rinkiniams
        private const string UpperCaseString = "ABCDEFGHIJKLMNOPRSTUVWXYZ";
        private const string LowerCaseString = "abcdefghijklmnoprstuvwxyz";
        private const string NumbersString = "0123456789";
        private const string SymbolsString = "!@#$%^&*()_+-=<>?";

        // Atsitiktinių skaičių generatorius
        private readonly Random _random = new Random();

        // Funkcija slaptažodžio generavimui
        public string Generate(int length = 12, int upperCase = -1, int lowerCase = -1, int numbers = -1, int symbols = 1)
        {
            // Slaptažodžio masyvas
            var password = new char[length];

            // Simbolių rinkiniai
            var characterSets = new[]
            {
                new { Set = UpperCaseString, Count = upperCase },
                new { Set = LowerCaseString, Count = lowerCase },
                new { Set = NumbersString, Count = numbers },
                new { Set = SymbolsString, Count = symbols }
            };

            // Užtikriname, kad visi reikalavimai būtų įvykdyti
            foreach (var characterSet in characterSets.Where(x => x.Count > 0))
            {
                for (int i = 0; i < characterSet.Count; i++)
                {
                    int position;
                    do
                    {
                        // Randame laisvą poziciją slaptažodyje
                        position = _random.Next(length);
                    } while (password[position] != '\0');

                    // Įrašome simbolį į slaptažodį
                    password[position] = characterSet.Set[_random.Next(characterSet.Set.Length)];
                }
            }

            // Užpildome likusias vietas
            for (int i = 0; i < length; i++)
            {
                if (password[i] == '\0')
                {
                    // Randame leistinus simbolių rinkinius
                    var allowedCharacterSets = characterSets.Where(x => x.Count < 0).ToList();

                    // Pasirenkame atsitiktinį simbolių rinkinį
                    var characterSet = allowedCharacterSets[_random.Next(allowedCharacterSets.Count)];

                    // Įrašome simbolį į slaptažodį
                    password[i] = characterSet.Set[_random.Next(characterSet.Set.Length)];
                }
            }

            // Grąžiname sugeneruotą slaptažodį
            return new string(password);
        }
    }
}
