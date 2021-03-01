using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int AnnualSalary { get; set; }

        public int EmployeeAge { get; set; }

        public static List<Employee> GetAllEmployee()
        {
            List<Employee> listEmployees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId = 101,
                    FirstName = "Tom",
                    LastName = "Daely",
                    Gender = "Male",
                    AnnualSalary = 60000
                },

                new Employee
                {
                    EmployeeId = 102,
                    FirstName = "Mike",
                    LastName = "Mist",
                    Gender = "Male",
                    AnnualSalary = 72000
                },

                new Employee
                {
                    EmployeeId = 103,
                    FirstName = "Mary",
                    LastName = "Lamberth",
                    Gender = "Female",
                    AnnualSalary = 48000
                },

                new Employee
                {
                    EmployeeId = 104,
                    FirstName = "Pam",
                    LastName = "Penny",
                    Gender = "Female",
                    AnnualSalary = 50000
                },

                new Employee
                {
                    EmployeeId = 105,
                    FirstName = "Paul put",
                    LastName = "Genger",
                    Gender = "Male",
                    AnnualSalary = 65000
                },

                new Employee
                {
                    EmployeeId = 106,
                    FirstName = "Sandra",
                    LastName = "Bane",
                    Gender = "Female",
                    AnnualSalary = 7800
                },

                new Employee
                {
                    EmployeeId = 108,
                    FirstName = "Minn Shin",
                    LastName = "Monroe"
                    Gender = "Male"
                    AnnualSalary = 4000
                },
            };

            return listEmployees;
        }
    }
}
