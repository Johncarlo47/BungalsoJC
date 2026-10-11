
using System;
using System.Collections.Generic;

namespace Problem3
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }

    class Program
    {
        static void Main()
        {
            Queue<StudentRequest> requestQueue =
                new Queue<StudentRequest>();

            int choice;

            do
            {
                Console.WriteLine("\nSTUDENT REQUEST QUEUE");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        StudentRequest request = new StudentRequest();

                        Console.Write("Enter Student Number: ");
                        request.StudentNumber = Console.ReadLine() ?? "";

                        Console.Write("Enter Student Name: ");
                        request.StudentName = Console.ReadLine() ?? "";

                        Console.Write("Enter Request Type: ");
                        request.RequestType = Console.ReadLine() ?? "";

                        requestQueue.Enqueue(request);

                        Console.WriteLine("Request added successfully!");
                        break;

                    case 2:
                        if (requestQueue.Count == 0)
                        {
                            Console.WriteLine("No pending requests.");
                            break;
                        }

                        Console.WriteLine("\nREQUEST QUEUE");

                        int number = 1;

                        foreach (StudentRequest item in requestQueue)
                        {
                            Console.WriteLine(number + ". " +
                                item.StudentName + " - " +
                                item.RequestType);

                            number++;
                        }
                        break;

                    case 3:
                        if (requestQueue.Count == 0)
                        {
                            Console.WriteLine("No pending requests to process.");
                            break;
                        }

                        StudentRequest processed = requestQueue.Dequeue();

                        Console.WriteLine("\nProcessing Request: " +
                            processed.StudentName);

                        Console.WriteLine("Student Number: " +
                            processed.StudentNumber);

                        Console.WriteLine("Request Type: " +
                            processed.RequestType);

                        Console.WriteLine("Request processed successfully!");
                        break;

                    case 4:
                        Console.WriteLine("Program exited.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 4);
        }
    }
}
