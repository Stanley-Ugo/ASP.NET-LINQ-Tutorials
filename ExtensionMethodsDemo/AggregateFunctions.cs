using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    public class AggregateFunctions
    {
        public int AggregateMinAndMax()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Getting the Min even numbers Values with LINQ
            int result = numbers.Where(x => x % 2 == 0).Min();

            //Getting the Max even numbers Values with LINQ
            int resultII = numbers.Where(x => x % 2 == 0).Max();

            //Finding the Sum of the Numbers with Linq
            int sumOfAllNumbers = numbers.Sum();
            int sumOfAllEvenNumbers = numbers.Where(n => n % 2 == 0).Sum();

            //finding the count of Numbers
            int countOfAllNumbers = numbers.Count();
            int countOfAllEvenNumbers = numbers.Where(n => n % 2 == 0).Count();

            //Finding the Average of all Numbers
            double averageOfAllNumbers = numbers.Average();
            double averageOfAllEvenNumbers = numbers.Where(n => n % 2 == 0).Average();

            //Finding the minCount() & maxCount() values of a string
            string[] countries = { "India", "USA", "UK" };

            //FInding the minCount
            int minCount = countries.Min(x => x.Length);

            //FInding the Max Count
            int maxCount = countries.Max(x => x.Length);


            return result;
        }
    }
}
