﻿using System;
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

        public void RestrictionOperators()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Creating a func to paass to the where extension method
            Func<int, bool> predicate = x => x % 2 == 0;
            IEnumerable<int> evenNumbers = numbers.Where(predicate);

            foreach (int i in evenNumbers)
                Console.WriteLine(i);

        }

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
    }
}