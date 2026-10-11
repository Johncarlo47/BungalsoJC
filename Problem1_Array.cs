using System;

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
        Student[] students = new Student[10];
        int studentCount = 0;
        int choice;

        do
        {
            Console.WriteLine("\nSTUDENT RECORD MANAGEMENT");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");
            Console.Write("Enter choice: ");
            
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    if (studentCount >= 10)
                    {
                        Console.WriteLine("Student storage is full (maximum 10 students).");
                        break;
                    }
                    Student newStudent = new Student();
                    Console.Write("Enter Student Number: ");
                    newStudent.StudentNumber = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    newStudent.Name = Console.ReadLine();
                    Console.Write("Enter Program: ");
                    newStudent.Program = Console.ReadLine();
                    Console.Write("Enter Year Level: ");
                    int.TryParse(Console.ReadLine(), out newStudent.YearLevel);

                    students[studentCount] = newStudent;
                    studentCount++;
                    Console.WriteLine("Student added successfully!");
                    break;

                case 2:
                    if (studentCount == 0)
                    {
                        Console.WriteLine("No student records found.");
                        break;
                    }
                    Console.WriteLine("\nSTUDENT RECORDS");
                    for (int i = 0; i < studentCount; i++)
                    {
                        Console.WriteLine($"Student Number: {students[i].StudentNumber}");
                        Console.WriteLine($"Name: {students[i].Name}");
                        Console.WriteLine($"Program: {students[i].Program}");
                        Console.WriteLine($"Year Level: {students[i].YearLevel}");
                        Console.WriteLine();
                    }
                    break;

                case 3:
                    Console.Write("Enter Student Number to search: ");
                    string searchNum = Console.ReadLine();
                    int foundIndex = -1;
                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == searchNum)
                        {
                            foundIndex = i;
                            break;
                        }
                    }
                    if (foundIndex != -1)
                    {
                        Console.WriteLine("Student Found!");
                        Console.WriteLine($"Student Number: {students[foundIndex].StudentNumber}");
                        Console.WriteLine($"Name: {students[foundIndex].Name}");
                        Console.WriteLine($"Program: {students[foundIndex].Program}");
                        Console.WriteLine($"Year Level: {students[foundIndex].YearLevel}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Student Number to update: ");
                    string updateNum = Console.ReadLine();
                    int updateIndex = -1;
                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == updateNum)
                        {
                            updateIndex = i;
                            break;
                        }
                    }
                    if (updateIndex != -1)
                    {
                        Console.Write("Enter New Name: ");
                        students[updateIndex].Name = Console.ReadLine();
                        Console.Write("Enter New Program: ");
                        students[updateIndex].Program = Console.ReadLine();
                        Console.Write("Enter New Year Level: ");
                        int.TryParse(Console.ReadLine(), out students[updateIndex].YearLevel);
                        Console.WriteLine("Student updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 5:
                    Console.Write("Enter Student Number to delete: ");
                    string deleteNum = Console.ReadLine();
                    int deleteIndex = -1;
                    for (int i = 0; i < studentCount; i++)
                    {
                        if (students[i].StudentNumber == deleteNum)
                        {
                            deleteIndex = i;
                            break;
                        }
                    }
                    if (deleteIndex != -1)
                    {
                        for (int i = deleteIndex; i < studentCount - 1; i++)
                        {
                            students[i] = students[i + 1];
                        }
                        studentCount--;
                        Console.WriteLine("Student deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;

                case 6:
                    Console.WriteLine("Program exited.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 6);
    }
}