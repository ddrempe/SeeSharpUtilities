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
        public string menuName { get; set; }

        public List<string> menuOptions { get; set; }

        public Menu(string name, List<string> options)
        {
            menuName = name;
            menuOptions = options;
        }

        public int Display()
        {
            Console.WriteLine(menuName);
            Console.WriteLine();
            Console.WriteLine("0. Exit");
            foreach (string option in menuOptions)
            {
                Console.WriteLine(option);
            }

            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
