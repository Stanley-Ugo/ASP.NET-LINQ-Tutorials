using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    //string Helper class to act as an extension to the string class
    public static class StringHelper
    {
        public static string ChangeFirstLetterCase(this string inputString)
        {
            if(inputString.Length > 0)
            {
                char[] charArray = inputString.ToCharArray();
                charArray[0] = char.IsUpper(charArray[0]) ? char.ToLower(charArray[0]) : char.ToUpper(charArray[0]);

                return new string(charArray);
            }

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);
            //Or could be  written as
            IEnumerable<int> evenNumbersII = Enumerable.Where(numbers, n => n % 2 == 0);

            return inputString;
        }
    }
}
