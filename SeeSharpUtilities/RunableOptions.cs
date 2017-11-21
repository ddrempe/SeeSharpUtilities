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
        public static void Cryptography()
        {
            List<string> options = new List<string>
            {
                "1. Symmetric encryption of a string",
                "2. Symmetric decryption of a string"
            };
            Menu cryptographyMenu = new Menu("Cryptography", options);

            int userInput = 0;
            do
            {
                userInput = cryptographyMenu.Display();

                switch (userInput)
                {
                    case 1:
                        //SymmetricEncryption.Encrypt();
                        break;
                    default:
                        break;
                }
            } while (userInput != 0);
        }
    }
}
