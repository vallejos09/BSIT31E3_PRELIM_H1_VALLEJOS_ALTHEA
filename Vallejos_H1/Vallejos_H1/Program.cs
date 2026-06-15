using System;
using System.Collections.Generic;
using System.Linq;

namespace Vallejos_H1
{
    class Student
    {
        public string Name { get; set; } = string.Empty;
        public List<int> Grades { get; set; } = new List<int>();
        public double Average => Grades.Count > 0 ? Grades.Average() : 0;
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Individual Averages");
                Console.WriteLine("4. Class Average");
                Console.WriteLine("5. Top Student");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddStudent(); break;
                    case "2": DisplayStudents(); break;
                    case "3": ShowIndividualAverages(); break;
                    case "4": ShowClassAverage(); break;
                    case "5": ShowTopStudent(); break;
                    case "6": running = false; break;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        // All helper methods must be inside Program class but outside Main
        static void AddStudent()
        {
            Console.Write("Enter student name: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name.");
                return;
            }

            Student s = new Student { Name = name };

            Console.Write("Enter grades separated by spaces: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                string[] inputs = input.Split();
                foreach (var g in inputs)
                {
                    if (int.TryParse(g, out int grade))
                        s.Grades.Add(grade);
                }
            }

            students.Add(s);
            Console.WriteLine("Student added successfully!");
        }

        static void DisplayStudents()
        {
            if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
            foreach (var s in students)
                Console.WriteLine($"{s.Name} - Grades: {string.Join(", ", s.Grades)}");
        }

        static void ShowIndividualAverages()
        {
            if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
            foreach (var s in students)
                Console.WriteLine($"{s.Name} - Average: {s.Average:F2}");
        }

        static void ShowClassAverage()
        {
            if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
            double classAvg = students.Average(s => s.Average);
            Console.WriteLine($"Class Average: {classAvg:F2}");
        }

        static void ShowTopStudent()
        {
            if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
            var top = students.OrderByDescending(s => s.Average).First();
            Console.WriteLine($"Top Student: {top.Name} with Average {top.Average:F2}");
        }
    }
}
