using Models;
using UI;

namespace Services;

internal class TaskManager
{
    public void AddTask(List<TodoTask> tasks)
    {
        var task = "";
        while (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Enter your task:");
            task = Console.ReadLine();
            Console.WriteLine("Enter due date (optional):");
            try
            {
                var dueDateInput = Console.ReadLine();
                DateTime? duedate = null;
                if (!string.IsNullOrEmpty(dueDateInput))
                {
                    duedate = Convert.ToDateTime(dueDateInput);
                }
                if (string.IsNullOrWhiteSpace(task))
                {
                    Console.WriteLine("Task cannot be empty.");
                    continue;
                };

                TodoTask todoTask = new()
                {
                    Title = task,
                    DueDate = duedate
                };

                tasks.Add(todoTask);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    public void ReadTasks(List<TodoTask> tasks)
    {
        if (tasks.Count==0)
        {
            Console.WriteLine("Task list is empty.");
        }

        var i = 1;

        foreach (var task in tasks)
        {
            Console.WriteLine($"{i}.{task.Title}");
            Console.WriteLine($"Completed: {task.IsCompleted}");
            Console.WriteLine($"Created: {task.CreationDate}");
            if (task.DueDate != null) {
                Console.WriteLine($"Due: {task.DueDate}");
            }
            Console.WriteLine($"Priority: {task.Priority}");
            i++;
        }
    }

    public void UpdateTasks(List<TodoTask> tasks, Dictionary<string, List<TodoTask>> categories)
    {
        if (tasks.Count==0)
        {
            Console.WriteLine("Task list is empty.");
        }
        var i = 1;
        foreach (var task in tasks)
        {
            Console.WriteLine($"{i}.{task.Title}");
            i++;
        }
        string? taskChoice = null;
        while (int.TryParse(taskChoice, out _) == false)
        {
            Console.WriteLine("Select a task or type exit to go back.");
            taskChoice = Console.ReadLine();
            if (taskChoice == "exit")
            {
                break;
            }
        }
        if (taskChoice == "exit")
        {
            return;
        }
        else
        {
            int taskNumber = Convert.ToInt16(taskChoice);
            var editingTask = tasks[taskNumber - 1];
            Console.WriteLine($"Editing task: {editingTask.Title}.");
            MenuHandler.TaskMenu();
            string? editChoice = null;
            while (editChoice == null || int.TryParse(editChoice, out _) == false )
            {
                Console.WriteLine("Enter your choice:");
                editChoice = Console.ReadLine();
            }
            if (editChoice == "1")
            {
                editingTask.IsCompleted = true;
            }
            else if (editChoice == "2")
            {
                Console.WriteLine("Select priority:");
                MenuHandler.PriorityMenu();
                var priorityChoice = Console.ReadLine();
                switch (priorityChoice)
                {
                    case "1":
                        editingTask.Priority = Priority.High;
                        break;
                    case "2":
                        editingTask.Priority = Priority.Medium;
                        break;
                    case "3":
                        editingTask.Priority = Priority.Low;
                        break;
                    default:
                        Console.WriteLine("Defaulting to Medium priority.");
                        editingTask.Priority = Priority.Medium;
                        break;
                }
            }
            else if (editChoice == "3")
            {
                Console.WriteLine("Select category to assign:");
                var j = 1;
                foreach (var cat in categories)
                {
                    Console.WriteLine($"{j}.{cat.Key}");
                    j++;
                }
                var categoryIndex = Convert.ToInt16(Console.ReadLine());
                var category = categories.ElementAt(categoryIndex - 1).Value;
                category.Add(editingTask);
                Console.WriteLine($"Task {editingTask.Title} successfully added to category {categories.ElementAt(categoryIndex - 1).Key}.");
                return;
            }
            else
            {
                Console.WriteLine("Wrong choice.");
                return;
            }
        }
    }
}