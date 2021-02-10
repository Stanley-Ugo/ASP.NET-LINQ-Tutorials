using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodsDemo
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        public string Class { get; set; }
        public List<string> Subjects { get; set; }

        public int TotalMarks { get; set; }

        public static List<Student> GetAllStudents()
        {
            List<Student> listStudent = new List<Student>
            {
                new Student
                {
                    StudentId = 101,
                    Name = "Tom",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#"},
                    TotalMarks = 800
                },

                new Student
                {
                    StudentId = 102,
                    Name = "Mike",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#", "ADO.NET", "AJAX"},
                    TotalMarks = 800
                },

                new Student
                {
                    StudentId = 103,
                    Name = "Pam",
                    Gender = "Female",
                    Subjects = new List<string> {"ASP.NET", "C#", "WPF", "SQL SERVER"},
                    TotalMarks = 800
                },

                new Student
                {
                    StudentId = 104,
                    Name = "Mary",
                    Gender = "Female",
                    Subjects = new List<string> {"ASP.NET", "C#", "LINQ", "WPF"},
                    TotalMarks = 900
                },

                new Student
                {
                    StudentId = 105,
                    Name = "Tom",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#"},
                    TotalMarks = 800
                },

                new Student
                {
                    StudentId = 106,
                    Name = "Robb",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#", "ADO.NET", "AJAX"},
                    TotalMarks = 950
                },

                new Student
                {
                    StudentId = 107,
                    Name = "Alex",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#", "WPF", "SQL SERVER"},
                    TotalMarks = 750
                },

                new Student
                {
                    StudentId = 108,
                    Name = "Susan",
                    Gender = "Female",
                    Subjects = new List<string> {"ASP.NET", "C#", "LINQ", "WPF"},
                    TotalMarks = 860
                },

                new Student
                {
                    StudentId = 109,
                    Name = "Pamilerin",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#", "WPF", "SQL SERVER"},
                    TotalMarks = 660
                },

                new Student
                {
                    StudentId = 110,
                    Name = "Martha",
                    Gender = "Female",
                    Subjects = new List<string> {"ASP.NET", "C#", "LINQ", "WPF"},
                    TotalMarks = 500
                },

                new Student
                {
                    StudentId = 111,
                    Name = "Meek",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET", "C#"},
                    TotalMarks = 600
                },

                new Student
                {
                    StudentId = 112,
                    Name = "Henry",
                    Gender = "Male",
                    Subjects = new List<string> {"ASP.NET CORE", "LINQ"},
                    TotalMarks = 700
                },

                new Student
                {
                    StudentId = 113,
                    Name = "Sharon Stone",
                    Gender = "Female",
                    Subjects = new List<string> {"ASP.NET CORE", "LINQ"},
                    Class = "Entry Level"
                    TotalMarks = 400
                }
            };

            return listStudent;
        }
    }
}
