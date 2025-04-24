using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static string filePath = "tasks.txt";
    static List<string> tasks = new List<string>();

    static void Main()
    {
        LoadTasks();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("📌 TO-DO LIST");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. List Tasks");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddTask(); break;
                case "2": RemoveTask(); break;
                case "3": ListTasks(); break;
                case "4": SaveTasks(); Console.WriteLine("Tasks saved. Exiting..."); return;
                default: Console.WriteLine("Invalid choice! Press any key to continue..."); Console.ReadKey(); break;
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks = new List<string>(File.ReadAllLines(filePath));
        }
    }

    static void SaveTasks()
    {
        File.WriteAllLines(filePath, tasks);
    }

    static void AddTask()
    {
        Console.Write("Enter task: ");
        string task = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(task))
        {
            tasks.Add(task);
            SaveTasks();
        }
    }

    static void RemoveTask()
    {
        
        ListTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to remove. Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Console.Write("Enter task number to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Invalid task number! Press any key to continue...");
            Console.ReadKey();
        }
    }

    static void ListTasks()
    {
        Console.Clear();
        Console.WriteLine("📋 Your Tasks:");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}
