using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adding a string variable
            string stringName = "pragim";

            //changed first letter to uppercase
            string result = stringName.ChangeFirstLetterCase();

            Console.WriteLine(result);
        }
    }
}
