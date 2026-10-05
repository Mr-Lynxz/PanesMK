using System;
using System.Collections.Generic;

struct Student4
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Stack
{
    static void Main()
    {
        Student4[] students = new Student4[10];
        int studentCount = 0;

        Stack<Operation> operationHistory =
            new Stack<Operation>();

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("================================");
            Console.WriteLine("STUDENT RECORD MANAGEMENT");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Student");
            Console.WriteLine("4. View Operation History");
            Console.WriteLine("5. View Last Operation");
            Console.WriteLine("6. Remove Last Operation");
            Console.WriteLine("7. Exit");
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

                    bool exists = false;

                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == studentNumber)
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (exists)
                    {
                        Console.WriteLine(
                            "Student Number already exists.");
                    }
                    else
                    {
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Program: ");
                        string program = Console.ReadLine();

                        Console.Write("Enter Year Level: ");
                        int yearLevel =
                            int.Parse(Console.ReadLine());

                        students[studentCount].StudentNumber =
                            studentNumber;
                        students[studentCount].Name = name;
                        students[studentCount].Program = program;
                        students[studentCount].YearLevel =
                            yearLevel;

                        studentCount++;

                        Operation operation = new Operation();

                        operation.Action = "Added";
                        operation.StudentNumber = studentNumber;
                        operation.StudentName = name;

                        operationHistory.Push(operation);

                        Console.WriteLine(
                            "Student added successfully!");
                    }
                }
            }
            else if (choice == 2)
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
                    students[index].Program =
                        Console.ReadLine();

                    Console.Write("Enter New Year Level: ");
                    students[index].YearLevel =
                        int.Parse(Console.ReadLine());

                    Operation operation = new Operation();

                    operation.Action = "Updated";
                    operation.StudentNumber =
                        students[index].StudentNumber;
                    operation.StudentName =
                        students[index].Name;

                    operationHistory.Push(operation);

                    Console.WriteLine(
                        "Student updated successfully!");
                }
            }
            else if (choice == 3)
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
                    string deletedNumber =
                        students[index].StudentNumber;

                    string deletedName =
                        students[index].Name;

                    for (int i = index;
                         i < studentCount - 1;
                         i++)
                    {
                        students[i] = students[i + 1];
                    }

                    studentCount--;

                    Operation operation = new Operation();

                    operation.Action = "Deleted";
                    operation.StudentNumber = deletedNumber;
                    operation.StudentName = deletedName;

                    operationHistory.Push(operation);

                    Console.WriteLine(
                        "Student deleted successfully!");
                }
            }
            else if (choice == 4)
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine(
                        "No recorded operations.");
                }
                else
                {
                    int number = 1;

                    foreach (Operation operation
                        in operationHistory)
                    {
                        Console.WriteLine(
                            number + ". " +
                            operation.Action + " " +
                            operation.StudentName);

                        number++;
                    }
                }
            }
            else if (choice == 5)
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine(
                        "No recorded operations.");
                }
                else
                {
                    Operation operation =
                        operationHistory.Peek();

                    Console.WriteLine(
                        "Last Operation: " +
                        operation.Action + " " +
                        operation.StudentName);
                }
            }
            else if (choice == 6)
            {
                if (operationHistory.Count == 0)
                {
                    Console.WriteLine(
                        "No recorded operations.");
                }
                else
                {
                    operationHistory.Pop();

                    Console.WriteLine(
                        "Last operation removed successfully!");
                }
            }
            else if (choice == 7)
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