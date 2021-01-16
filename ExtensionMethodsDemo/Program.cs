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
            //
            string stringName = "pragim";
            string result = stringName.ChangeFirstLetterCase();

            Console.WriteLine(result);
        }
    }
}
