using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        Console.WriteLine("Simple Task Management Console App");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;

                case "2":
                    ViewTasks();
                    break;

                case "3":
                    MarkTaskAsCompleted();
                    break;

                case "4":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter the task description: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        Console.WriteLine("Task added successfully!");
    }

    static void ViewTasks()
    {
        Console.WriteLine("\nTask List:");

        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }

    static void MarkTaskAsCompleted()
    {
        ViewTasks();

        Console.Write("\nEnter the task number to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please enter a valid task number.");
        }
    }
}
