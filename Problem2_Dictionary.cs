using System;
using System.Collections.Generic;

struct Student2
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Dictionary
{
    static void Main()
    {
        Dictionary<string, Student2> studentDictionary =
            new Dictionary<string, Student2>();

        while (true)
        {   
            Console.WriteLine("\n");
            Console.WriteLine("================================");
            Console.WriteLine("STUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\n");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter Student Number: ");
                string studentNumber = Console.ReadLine();

                if (studentDictionary.ContainsKey(studentNumber))
                {
                    Console.WriteLine("Student Number already exists.");
                }
                else
                {
                    Student2 student = new Student2();

                    student.StudentNumber = studentNumber;

                    Console.Write("Enter Name: ");
                    student.Name = Console.ReadLine();

                    Console.Write("Enter Program: ");
                    student.Program = Console.ReadLine();

                    Console.Write("Enter Year Level: ");
                    student.YearLevel =
                        int.Parse(Console.ReadLine());

                    studentDictionary.Add(studentNumber, student);

                    Console.WriteLine("Student added successfully!");
                }
            }
            else if (choice == 2)
            {
                Console.Write("Enter Student Number to search: ");
                string searchNumber = Console.ReadLine();

                if (studentDictionary.TryGetValue(
                    searchNumber, out Student2 student))
                {
                    Console.WriteLine("Student Found!");
                    Console.WriteLine("\n");
                    Console.WriteLine("Student Number: " +
                        student.StudentNumber);
                    Console.WriteLine("Name: " +
                        student.Name);
                    Console.WriteLine("Program: " +
                        student.Program);
                    Console.WriteLine("Year Level: " +
                        student.YearLevel);
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else if (choice == 3)
            {
                if (studentDictionary.Count == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    foreach (var item in studentDictionary)
                    {
                        Console.WriteLine("Student Number: " +
                            item.Value.StudentNumber);
                        Console.WriteLine("Name: " +
                            item.Value.Name);
                        Console.WriteLine("Program: " +
                            item.Value.Program);
                        Console.WriteLine("Year Level: " +
                            item.Value.YearLevel);
                        Console.WriteLine();
                    }
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Program exited.");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.WriteLine();
        }
    }
}