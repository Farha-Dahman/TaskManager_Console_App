using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskManager
{
    public class TaskManager
    {
        private List<TaskItem> tasks = new List<TaskItem>();
        private const string FilePath = "tasks.json";

        public async Task LoadTasks()
        {
            if (File.Exists(FilePath))
            {
                string json = await File.ReadAllTextAsync(FilePath);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            }
        }

        public async Task SaveTasks()
        {
            string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePath, json);
        }

        public async Task AddTask()
        {
            Console.Write("Enter Task Title: ");
            string title;
            while (string.IsNullOrWhiteSpace(title = Console.ReadLine()))
            {
                Console.WriteLine("Task Title cannot be empty. Please enter a valid title.");
            }

            Console.Write("Enter Task Description: ");
            string description = Console.ReadLine();

            DateTime dueDate;
            while (true)
            {
                Console.Write("Enter Due Date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out dueDate))
                    break;
                Console.WriteLine("Invalid date format. Please try again.");
            }

            string priority;
            while (true)
            {
                Console.Write("Enter Priority (Low, Medium, High): ");
                priority = Console.ReadLine();
                if (priority == "Low" || priority == "Medium" || priority == "High")
                    break;
                Console.WriteLine("Invalid priority. Please enter Low, Medium, or High.");
            }

            string status;
            while (true)
            {
                Console.Write("Enter Status (Pending, In Progress, Completed): ");
                status = Console.ReadLine();
                if (status == "Pending" || status == "In Progress" || status == "Completed")
                    break;
                Console.WriteLine("Invalid status. Please enter Pending, In Progress, or Completed.");
            }

            string category;
            while (true)
            {
                Console.Write("Enter Category (e.g.: Work, Personal, Study): ");
                category = Console.ReadLine();
                if (category == "Work" || category == "Personal" || category == "Study")
                    break;
                Console.WriteLine("Invalid status. Please enter Work, In Personal, or Study.");
            }

            TaskItem newTask = new TaskItem
            {
                Title = title,
                Description = description,
                DueDate = dueDate,
                Priority = priority,
                Status = status,
                Category = category
            };

            tasks.Add(newTask);
            Console.WriteLine("Task added successfully!");

            await SaveTasks();
        }

        public void ViewTasks()
        {
            if (!tasks.Any())
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("\nFilter by:");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Status");
            Console.WriteLine("3. Priority");
            Console.WriteLine("4. Category");
            Console.Write("Enter your choice: ");

            string filterChoice = Console.ReadLine();
            IEnumerable<TaskItem> filteredTasks = tasks;

            switch (filterChoice)
            {
                case "2":
                    Console.Write("Enter Status to filter by (Pending, In Progress, Completed): ");
                    string status = Console.ReadLine();
                    filteredTasks = tasks.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
                    break;
                case "3":
                    Console.Write("Enter Priority to filter by (Low, Medium, High): ");
                    string priority = Console.ReadLine();
                    filteredTasks = tasks.Where(t => t.Priority.Equals(priority, StringComparison.OrdinalIgnoreCase));
                    break;
                case "4":
                    Console.Write("Enter Category to filter by: ");
                    string category = Console.ReadLine();
                    filteredTasks = tasks.Where(t => t.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
                    break;
            }

            Console.WriteLine("\nTasks:\n");
            foreach (var task in filteredTasks)
            {
                Console.WriteLine($"Title: {task.Title}, Description: {task.Description}, Due Date: {task.DueDate:yyyy-MM-dd}, Priority: {task.Priority}, Status: {task.Status}");
            }
        }

        public async Task UpdateTask()
        {
            Console.Write("Enter Task Title to update: ");
            string title = Console.ReadLine();

            TaskItem task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.Write("Enter new Title (leave blank to keep current): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle)) task.Title = newTitle;

            Console.Write("Enter new Description (leave blank to keep current): ");
            string description = Console.ReadLine();
            if (!string.IsNullOrEmpty(description)) task.Description = description;

            Console.Write("Enter new Due Date (yyyy-mm-dd, leave blank to keep current): ");
            string dueDateInput = Console.ReadLine();
            if (DateTime.TryParse(dueDateInput, out DateTime dueDate)) task.DueDate = dueDate;

            Console.Write("Enter new Priority (Low, Medium, High, leave blank to keep current): ");
            string priority = Console.ReadLine();
            if (!string.IsNullOrEmpty(priority)) task.Priority = priority;

            Console.Write("Enter new Status (Pending, In Progress, Completed, leave blank to keep current): ");
            string status = Console.ReadLine();
            if (!string.IsNullOrEmpty(status)) task.Status = status;

            Console.WriteLine("Task updated successfully!");
            await SaveTasks();
        }

        public async Task DeleteTask()
        {
            Console.Write("Enter Task Title to delete: ");
            string title = Console.ReadLine();

            TaskItem task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            tasks.Remove(task);
            Console.WriteLine("Task deleted successfully!");
            await SaveTasks();
        }

        public void SearchTasks()
        {
            Console.Write("Enter keyword to search: ");
            string keyword = Console.ReadLine();

            var searchResults = tasks
                .Where(t => t.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!searchResults.Any())
            {
                Console.WriteLine("No tasks found with the given keyword.");
                return;
            }

            Console.WriteLine("\nSearch Results:");
            foreach (var task in searchResults)
            {
                Console.WriteLine($"Title: {task.Title}, Due Date: {task.DueDate:yyyy-MM-dd}, Priority: {task.Priority}, Status: {task.Status}");
            }
        }

        public void ShowProgress()
        {
            if (!tasks.Any())
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            int totalTasks = tasks.Count;
            int completedTasks = tasks.Count(t => t.Status == "Completed");
            double completionRate = (double)completedTasks / totalTasks * 100;

            Console.WriteLine($"\nYou complete {completedTasks} from {totalTasks} tasks, Task Completion Rate: {completionRate:F2} tasks completed");
        }

    }
}