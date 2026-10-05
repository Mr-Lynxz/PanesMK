using System;
using System.Collections.Generic;

struct StudentRequest
{
    public string StudentNumber;
    public string StudentName;
    public string RequestType;
}

class Queue
{
    static void Main()
    {
        Queue<StudentRequest> requestQueue =
            new Queue<StudentRequest>();

        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("================================");
            Console.WriteLine("STUDENT REQUEST QUEUE");
            Console.WriteLine("================================");
            Console.WriteLine("1. Add Request");
            Console.WriteLine("2. View Pending Requests");
            Console.WriteLine("3. Process Request");
            Console.WriteLine("4. Exit");
            Console.WriteLine("\n");
            Console.Write("Enter choice: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                StudentRequest request = new StudentRequest();

                Console.Write("Enter Student Number: ");
                request.StudentNumber = Console.ReadLine();

                Console.Write("Enter Student Name: ");
                request.StudentName = Console.ReadLine();

                Console.Write("Enter Request Type: ");
                request.RequestType = Console.ReadLine();

                requestQueue.Enqueue(request);

                Console.WriteLine("Request added successfully!");
            }
            else if (choice == 2)
            {
                if (requestQueue.Count == 0)
                {
                    Console.WriteLine("No pending requests.");
                }
                else
                {
                    int number = 1;

                    foreach (StudentRequest request in requestQueue)
                    {
                        Console.WriteLine(
                            number + ". " +
                            request.StudentName + " - " +
                            request.RequestType);

                        number++;
                    }
                }
            }
            else if (choice == 3)
            {
                if (requestQueue.Count == 0)
                {
                    Console.WriteLine("No pending requests.");
                }
                else
                {
                    StudentRequest request =
                        requestQueue.Dequeue();

                    Console.WriteLine(
                        "Processing Request: " +
                        request.StudentName);

                    Console.WriteLine(
                        "Request Type: " +
                        request.RequestType);

                    Console.WriteLine(
                        "Request processed successfully!");
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