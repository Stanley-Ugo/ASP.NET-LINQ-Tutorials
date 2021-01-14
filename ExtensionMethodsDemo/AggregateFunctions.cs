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
            string[] countries = { "India", "USA", "UK", "Canada", "Australia" };

            //FInding the minCount
            int minCount = countries.Min(x => x.Length);

            //FInding the Max Countx
            int maxCount = countries.Max(x => x.Length);

            //Using the Aggragate Function To Concatenate strings
            string countryList = countries.Aggregate((a, b) => a + "," + b);
            //result =  "India, USA, UK, Canada, Australia"

            //Getting the Product of an int array with Linq aggregate Function
            //the Number 10 here is the seeding number that is the first number to be multiplies with the numb array
            int intArrayResult = numbers.Aggregate(10, (a, b) => a * b);

            return result;
        }
        //Restriction Opeerators
        public void RestrictionOperators()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Creating a func to paass to the where extension method
            Func<int, bool> predicate = x => x % 2 == 0;
            IEnumerable<int> evenNumbers = numbers.Where(predicate);

            foreach (int i in evenNumbers)
                Console.WriteLine(i);

        }

        //Projection Operation
        public void ProjectionOperation()
        {
            //Getting the List of Employees ID
           IEnumerable<int> results = Employee.GetAllEmployee().Select(emp => emp.EmployeeId);

            foreach(int id in results)
            {
                Console.WriteLine(id);
            }

            //Getting the FirstName and Lastame Projected into an annonymous type
            var result = Employee.GetAllEmployee().Select(emp => new { FirstName = emp.FirstName, Gender = emp.Gender } );

            foreach (var item in result)
            {
                Console.WriteLine(item.FirstName + " - " + item.Gender);
            }

            //Getting the Fullname and Monthly Salary
            var resultSet = Employee.GetAllEmployee().Select(emp => new { FullName = emp.FirstName + " " + emp.LastName, MonthlySalary = emp.AnnualSalary / 12 });

            foreach (var item in resultSet)
            {
                Console.WriteLine(item.FullName + " " + item.MonthlySalary);
            }

            //Computing Employee Bonus [10%] to Employees who Earn above 50000
            var resultBonus = Employee.GetAllEmployee().Where(x => x.AnnualSalary > 50000)
                .Select(emp => new { Name = emp.FirstName, AnnualSalary = emp.AnnualSalary, Bonus = emp.AnnualSalary * .1 });

            foreach (var item in resultBonus)
            {
                Console.WriteLine(item.Name + " : " + item.AnnualSalary + " - " + item.Bonus);
            }
        }

        //SelectMany Operator
        public void SelectManyOperator()
        {
            //Gets all Distinct students's subjects from the list of subjects returned
            IEnumerable<string> subjects = Student.GetAllStudents().SelectMany(s => s.Subjects).Distinct();

            foreach (string subject in subjects)
            {
                Console.WriteLine(subject);
            }

            //Using SQL Like query to get Similar result sets
            IEnumerable<string> subjectsII = (from student in Student.GetAllStudents()
                                              from subject in student.Subjects
                                              select subject).Distinct();

            foreach (string subject in subjectsII)
            {
                Console.WriteLine(subject);
            }

            //Printing out the student Name and subjects
            var result = Student.GetAllStudents().SelectMany(s => s.Subjects, (student, subject) =>
                                                             new { StudentName = student.Name, SubjectName = subject });

            foreach (var item in result)
            {
                Console.WriteLine(item.StudentName + " - " + item.SubjectName );
            }
        }

        //Sorting OPerators
        public void SortingOperators()
        {
            IOrderedEnumerable<Student> result = Student.GetAllStudents().OrderBy(s => s.TotalMarks).ThenBy(s => s.Name).ThenByDescending(s => s.StudentId);

            foreach ( Student student in result)
            {
                Console.WriteLine(student.TotalMarks + "\t" + student.Name + "\t" + student.StudentId);
            }
        }

        //Paginatrion With Skip & Take
        public void PaginationWithSkipAndTake()
        {
            do
            {
                IEnumerable<Student> students = Student.GetAllStudents();

                Console.WriteLine("Please Enter Page Number between - 1,2,3 or 4");

                int pageNumber = 0;

                if (int.TryParse(Console.ReadLine(), out pageNumber))
                {
                    if (pageNumber >= 1 && pageNumber <= 4)
                    {
                        int pageSize = 3;
                        IEnumerable<Student> result = students.Skip((pageNumber - 1) * pageSize).Take(pageSize);

                        Console.WriteLine();
                        Console.WriteLine("Displaying Page " + pageNumber);

                        foreach (Student item in result)
                        {
                            Console.WriteLine(item.StudentId + "\t" + item.Name + "\t" + item.TotalMarks);
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Page Number Must be an integer between 1 and 4");
                    }
                }
                else
                {
                    Console.WriteLine("Page Number Must be an integer between 1 and 4");
                }
            } while (1 == 1);
        }

        public void SetOperators()
        {
            string[] countries = { "USA", "usa", "INDIA", "UK", "UK" };

            var result = countries.Distinct(StringComparer.OrdinalIgnoreCase);

            //looping throught the result set & printing to the console
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void UnionOperators()
        {
            //array of integers
            int[] numbers1 = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 1, 3, 6, 7, 8 };

            //combining the array only distinct numbers
            var result = numbers1.Union(numbers2);

            //getting just the numbers comon to both variables
            var result2 = numbers1.Intersect(numbers2);

            //getting just the numbers in result except the numbers passed in
            var result3 = numbers1.Except(numbers2);

            //joins both result sets without removing identical numbers
            var result4 = numbers1.Concat(numbers2);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void GenerationOPerators()
        {
            //Generating numbers from 1 - 10 with the Range Operator
            IEnumerable<int> result = Enumerable.Range(1, 10);

            //Generating only even numbers from 1 - 10 with the Range Operator
            IEnumerable<int> result2 = Enumerable.Range(1, 10).Where(x => x % 2 == 0);

            //Using the .Repeat to reapeat an item to the console
            var result3 = Enumerable.Repeat("Hello", 5);

            //Using the Empty<> operator to avoid getting into null reference exceptions
            IEnumerable<int> result4 = Enumerable.Empty<int>(); // returns 0

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        public void SequenceEqualOperator()
        {
            string[] countries = { "USA", "INDIA", "UK" };
            string[] countries2 = { "USA", "india", "UK" };

            //this is case sensitive 
            var result = countries.SequenceEqual(countries2);

            //Ignores the case and returns true
            var result2 = countries.SequenceEqual(countries2, StringComparer.OrdinalIgnoreCase);

            Console.WriteLine("Are Equal = " + result);


        }

        public void QuantifiersOperators()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            //result returns true cos all numbers is less than 10
            var result = numbers.All(x => x < 10);

            //returns true cos it contains any element
            var result2 = numbers.Any();

            //returns false cos no number in the numbers array is greater then 10
            var results3 = numbers.Any(x => x > 10);

            //chects to see if an element is present in a sequence
            var result4 = numbers.Contains(3);

            //Adding a string array
            string[] countries = { "USA", "INDIA", "UK" };

            //returns true after comparing regardles of case
            var resultSet = countries.Contains("india", StringComparer.OrdinalIgnoreCase);

            Console.WriteLine(resultSet);
        }
    }
}
