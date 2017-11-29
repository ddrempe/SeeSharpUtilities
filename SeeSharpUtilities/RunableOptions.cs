using Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpUtilities
{
    class RunableOptions
    {
        public static void Cryptography(string passphrase)
        {
            List<string> options = new List<string>
            {
                "1. Symmetric encryption of a text",
                "2. Symmetric decryption of a text",
                "3. Generate symmetric key"
            };
            Menu cryptographyMenu = new Menu("Cryptography", options);

            int userInput = 0;
            do
            {
                userInput = cryptographyMenu.Display();
                string inputText;

                switch (userInput)
                {
                    case 1:
                        Console.Write("Enter text: ");
                        inputText = Console.ReadLine();

                        string encryptedText = SymmetricEncryption.EncryptText(inputText, passphrase);
                        Console.WriteLine("Encrypted text: " + encryptedText);
                        break;
                    case 2:
                        Console.Write("Enter text: ");
                        inputText = Console.ReadLine();

                        string decryptedText = SymmetricEncryption.DecryptText(inputText, passphrase);
                        Console.WriteLine("Decrypted text: " + decryptedText);
                        break;
                    case 3:
                        byte[] key = SymmetricEncryption.GenerateKey(passphrase);
                        string keyAsString = Encoding.Default.GetString(key, 0, key.Length);
                        Console.WriteLine("Key: " + keyAsString);
                        break;
                    default:
                        break;
                }
            } while (userInput != 0);
        }
    }
}
