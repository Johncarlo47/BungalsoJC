
using System;
using System.Collections.Generic;

struct Operation
{
    public string Action;
    public string StudentNumber;
    public string StudentName;
}

class Program
{
    static void Main()
    {
        Stack<Operation> operationHistory = new Stack<Operation>();
        int choice;

        // Sample operations for demonstration
        operationHistory.Push(new Operation
        {
            Action = "Added",
            StudentNumber = "2026-0001",
            StudentName = "Juan"
        });

        operationHistory.Push(new Operation
        {
            Action = "Added",
            StudentNumber = "2026-0002",
            StudentName = "Maria"
        });

        operationHistory.Push(new Operation
        {
            Action = "Updated",
            StudentNumber = "2026-0001",
            StudentName = "Juan"
        });

        operationHistory.Push(new Operation
        {
            Action = "Deleted",
            StudentNumber = "2026-0003",
            StudentName = "Pedro"
        });

        do
        {
            Console.WriteLine("\nOPERATION HISTORY");
            Console.WriteLine("1. View Operation History");
            Console.WriteLine("2. View Last Operation");
            Console.WriteLine("3. Remove Last Operation");
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
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No operation history found.");
                        break;
                    }

                    Console.WriteLine("\nOPERATION HISTORY");

                    int number = 1;

                    foreach (Operation operation in operationHistory)
                    {
                        Console.WriteLine(number + ". " +
                            operation.Action + " " +
                            operation.StudentName);

                        number++;
                    }
                    break;

                case 2:
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No operation history found.");
                        break;
                    }

                    Operation lastOperation = operationHistory.Peek();

                    Console.WriteLine("Last Operation: " +
                        lastOperation.Action + " " +
                        lastOperation.StudentName);
                    break;

                case 3:
                    if (operationHistory.Count == 0)
                    {
                        Console.WriteLine("No operation to remove.");
                        break;
                    }

                    operationHistory.Pop();
                    Console.WriteLine("Last operation removed successfully!");
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
