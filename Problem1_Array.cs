using System;

struct Student1
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Array
{
    static void Main()
    {
        Student1[] students = new Student1[10];
        int studentCount = 0;

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("================================");
            Console.WriteLine("STUDENT RECORD MANAGEMENT");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.WriteLine("\n");
            Console.Write("Enter choice: ");
            

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                if (studentCount == students.Length)
                {
                    Console.WriteLine("Student records are full.");
                }
                else
                {
                    Console.Write("Enter Student Number: ");
                    string studentNumber = Console.ReadLine();

                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Program: ");
                    string program = Console.ReadLine();

                    Console.Write("Enter Year Level: ");
                    int yearLevel = int.Parse(Console.ReadLine());

                    students[studentCount].StudentNumber = studentNumber;
                    students[studentCount].Name = name;
                    students[studentCount].Program = program;
                    students[studentCount].YearLevel = yearLevel;

                    studentCount++;

                    Console.WriteLine("Student added successfully!");
                }
            }
            else if (choice == 2)
            {
                if (studentCount == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    for (int i = 0; i < studentCount; i++)
                    {
                        Console.WriteLine("Student Number: " +
                            students[i].StudentNumber);
                        Console.WriteLine("Name: " +
                            students[i].Name);
                        Console.WriteLine("Program: " +
                            students[i].Program);
                        Console.WriteLine("Year Level: " +
                            students[i].YearLevel);
                        Console.WriteLine();
                    }
                }
            }
            else if (choice == 3)
            {
                Console.Write("Enter Student Number to search: ");
                string searchNumber = Console.ReadLine();

                int index = -1;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == searchNumber)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    Console.WriteLine("Student Found!");
                    Console.WriteLine("Student Number: " +
                        students[index].StudentNumber);
                    Console.WriteLine("Name: " +
                        students[index].Name);
                    Console.WriteLine("Program: " +
                        students[index].Program);
                    Console.WriteLine("Year Level: " +
                        students[index].YearLevel);
                }
            }
            else if (choice == 4)
            {
                Console.Write("Enter Student Number to update: ");
                string updateNumber = Console.ReadLine();

                int index = -1;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == updateNumber)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    Console.Write("Enter New Name: ");
                    students[index].Name = Console.ReadLine();

                    Console.Write("Enter New Program: ");
                    students[index].Program = Console.ReadLine();

                    Console.Write("Enter New Year Level: ");
                    students[index].YearLevel =
                        int.Parse(Console.ReadLine());

                    Console.WriteLine("Student updated successfully!");
                }
            }
            else if (choice == 5)
            {
                Console.Write("Enter Student Number to delete: ");
                string deleteNumber = Console.ReadLine();

                int index = -1;

                for (int i = 0; i < studentCount; i++)
                {
                    if (students[i].StudentNumber == deleteNumber)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Student not found.");
                }
                else
                {
                    for (int i = index; i < studentCount - 1; i++)
                    {
                        students[i] = students[i + 1];
                    }

                    studentCount--;

                    Console.WriteLine("Student deleted successfully!");
                }
            }
            else if (choice == 6)
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