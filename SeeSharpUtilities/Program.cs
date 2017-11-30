using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> options = new List<string>
            {
                "1. Cryptography"
            };
            Menu mainMenu = new Menu("Main menu", options);
                        
            int userInput = mainMenu.Display();

            switch (userInput)
            {
                case 1:
                    CryptographyOptions.Run();
                    break;
                default:
                    break;
            }
        }
    }
}
