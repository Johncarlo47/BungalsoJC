using System;
using System.Collections.Generic;

struct Student
{
    public string StudentNumber;
    public string Name;
    public string Program;
    public int YearLevel;
}

class Program
{
    static void Main()
    {
        Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
        int choice;

        do
        {
            Console.WriteLine("\nSTUDENT LOOKUP USING DICTIONARY");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Display All Students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Student Number: ");
                    string studentNum = Console.ReadLine();

                    if (studentDictionary.ContainsKey(studentNum))
                    {
                        Console.WriteLine("Error: Student Number already exists!");
                        break;
                    }

                    Student newStudent = new Student();
                    newStudent.StudentNumber = studentNum;
                    Console.Write("Enter Name: ");
                    newStudent.Name = Console.ReadLine();
                    Console.Write("Enter Program: ");
                    newStudent.Program = Console.ReadLine();
                    Console.Write("Enter Year Level: ");
                    int.TryParse(Console.ReadLine(), out newStudent.YearLevel);

                    studentDictionary.Add(studentNum, newStudent);
                    Console.WriteLine("Student added successfully!");
                    break;

                case 2:
                    Console.Write("Enter Student Number to search: ");
                    string searchNum = Console.ReadLine();

                    if (studentDictionary.TryGetValue(searchNum, out Student foundStudent))
                    {
                        Console.WriteLine("Student Found!");
                        Console.WriteLine($"Student Number: {foundStudent.StudentNumber}");
                        Console.WriteLine($"Name: {foundStudent.Name}");
                        Console.WriteLine($"Program: {foundStudent.Program}");
                        Console.WriteLine($"Year Level: {foundStudent.YearLevel}");
                    }
                    else
                    {
                        Console.WriteLine("Student Number does not exist.");
                    }
                    break;

                case 3:
                    if (studentDictionary.Count == 0)
                    {
                        Console.WriteLine("No student records found.");
                        break;
                    }
                    Console.WriteLine("\nSTUDENT RECORDS");
                    foreach (var kvp in studentDictionary)
                    {
                        Console.WriteLine($"Student Number: {kvp.Value.StudentNumber}");
                        Console.WriteLine($"Name: {kvp.Value.Name}");
                        Console.WriteLine($"Program: {kvp.Value.Program}");
                        Console.WriteLine($"Year Level: {kvp.Value.YearLevel}");
                        Console.WriteLine();
                    }
                    break;

                case 4:
                    Console.WriteLine("Program exited.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 4);
    }
}