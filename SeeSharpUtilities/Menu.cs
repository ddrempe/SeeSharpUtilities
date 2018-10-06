using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* SOURCES:
https://stackoverflow.com/questions/20365214/a-simple-menu-in-a-console-application
*/

namespace SeeSharpUtilities
{
    class Menu
    {
        public string MenuName { get; set; }

        public List<string> MenuOptions { get; set; }

        public Menu(string name, List<string> options)
        {
            MenuName = name;
            MenuOptions = options;
        }

        public int Display()
        {
            Console.WriteLine(MenuName);
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            foreach (string option in MenuOptions)
            {
                Console.WriteLine(option);
            }

            Console.Write("Enter choice: ");
            var result = Console.ReadLine();
            Console.Clear();
            return Convert.ToInt32(result);
        }
    }
}
