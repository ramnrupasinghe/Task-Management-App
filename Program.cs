using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();

    static void Main()
    {
        Console.WriteLine("Simple Task Management Console App");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Edit Task");
            Console.WriteLine("5. Prioritize Task");
            Console.WriteLine("6. Display Highest Priority Task");
            Console.WriteLine("7. Clear Completed Tasks");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice (1-8): ");
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
                    EditTask();
                    break;

                case "5":
                    PrioritizeTask();
                    break;

                case "6":
                    DisplayHighestPriorityTask();
                    break;

                case "7":
                    ClearCompletedTasks();
                    break;

                case "8":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 8.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter the task description: ");
        string taskDescription = Console.ReadLine();
        tasks.Add(new TaskItem(taskDescription));
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
            tasks[taskNumber - 1].MarkCompleted();
            Console.WriteLine("Task marked as completed!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please enter a valid task number.");
        }
    }

    static void EditTask()
    {
        ViewTasks();

        Console.Write("\nEnter the task number to edit: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            Console.Write("Enter the new task description: ");
            string newTaskDescription = Console.ReadLine();

            tasks[taskNumber - 1].UpdateTaskDescription(newTaskDescription);
            Console.WriteLine("Task edited successfully!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please enter a valid task number.");
        }
    }

    static void PrioritizeTask()
    {
        ViewTasks();

        Console.Write("\nEnter the task number to prioritize: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].Prioritize();
            Console.WriteLine("Task prioritized!");
        }
        else
        {
            Console.WriteLine("Invalid task number. Please enter a valid task number.");
        }
    }

    static void DisplayHighestPriorityTask()
    {
        var highestPriorityTask = tasks.OrderByDescending(t => t.Priority).FirstOrDefault();

        if (highestPriorityTask != null)
        {
            Console.WriteLine($"Highest Priority Task: {highestPriorityTask}");
        }
        else
        {
            Console.WriteLine("No tasks found.");
        }
    }

    static void ClearCompletedTasks()
    {
        tasks.RemoveAll(t => t.IsCompleted);
        Console.WriteLine("Completed tasks cleared!");
    }
}

class TaskItem
{
    public string TaskDescription { get; private set; }
    public bool IsCompleted { get; private set; }
    public int Priority { get; private set; }

    public TaskItem(string taskDescription)
    {
        TaskDescription = taskDescription;
        IsCompleted = false;
        Priority = 0;
    }

    public void MarkCompleted()
    {
        IsCompleted = true;
    }

    public void UpdateTaskDescription(string newTaskDescription)
    {
        TaskDescription = newTaskDescription;
    }

    public void Prioritize()
    {
        Priority++;
    }

    public override string ToString()
    {
        return $"{TaskDescription} (Priority: {Priority}, Completed: {(IsCompleted ? "Yes" : "No")})";
    }
}


