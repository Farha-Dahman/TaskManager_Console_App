// See https://aka.ms/new-console-template for more information
using System;

namespace TaskManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            await taskManager.LoadTasks();

            while (true)
            {
                Console.WriteLine("\nTask Manager Menu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Update Task");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Search for Task");
                Console.WriteLine("6. Show Progress");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        await taskManager.AddTask();
                        break;
                    case "2":
                        taskManager.ViewTasks();
                        break;
                    case "3":
                        await taskManager.UpdateTask();
                        break;
                    case "4":
                        await taskManager.DeleteTask();
                        break;
                    case "5":
                        taskManager.SearchTasks();
                        break;
                    case "6":
                        taskManager.ShowProgress();
                        break;
                    case "7":
                        await taskManager.SaveTasks();
                        Console.WriteLine("\nGoodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}