using System.Data.Common;
using todo_console;

var categories = new Dictionary<string, List<TodoTask>>();
var tasks = new List<TodoTask>();
string? choice = null;
while (choice != "5")
{
    Console.WriteLine(@"Menu:
    1. Add new task.
    2. Read tasks.
    3. Edit task.
    4. Categories
    5. Exit.
    ");
    Console.WriteLine("Enter your choice:");
    choice = Console.ReadLine();


    if (choice == "1")
    {
        var task = "";
        while (string.IsNullOrWhiteSpace(task))
        {
            Console.WriteLine("Enter your task:");
            task = Console.ReadLine();
            Console.WriteLine("Enter due date (optional):");
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
    }
    else if (choice == "2")
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
    else if (choice == "3"){
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
            continue;
        }
        else
        {
            int taskNumber = Convert.ToInt16(taskChoice);
            var editingTask = tasks[taskNumber - 1];
            Console.WriteLine($"Editing task: {editingTask.Title}.");
            Console.WriteLine(@"
                1. Complete task.
                2. Change priority.
                3. Add to category.
            ");
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
                Console.WriteLine(@"
                    1. High
                    2. Medium
                    3. Low
                ");
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
                Console.WriteLine("Select category to assign.");
                var j = 1;
                foreach (var cat in categories)
                {
                    Console.WriteLine($"{j}.{cat.Key}");
                    j++;
                }
                var categoryName = Console.ReadLine();
                if (!string.IsNullOrEmpty(categoryName))
                {
                    var category = categories[categoryName];
                    category.Add(editingTask);
                    Console.WriteLine($"Task {editingTask.Title} successfully added to category {categoryName}");
                }
                continue;
            }
            else
            {
                Console.WriteLine("Wrong choice.");
                return;
            }
        }
    }
    else if (choice == "4")
    {
        Console.WriteLine(@"
            1. Display categories.
            2. Add new category.
            3. Remove category.
        ");
        var catChoice = Console.ReadLine();
        switch (catChoice)
        {
            case "1":
                if (categories.Count == 0)
                {
                    Console.WriteLine("No categories found.");
                    break;
                }
                Console.WriteLine("Categories:");
                var k = 1;
                foreach (var category in categories)
                {
                    Console.WriteLine($"{k}. {category.Key}");
                    k++;
                }
                Console.WriteLine("Choose a category:");
                var categoryChoice = Convert.ToInt16(Console.ReadLine()) - 1;
                var catList = categories.Values.ElementAt(categoryChoice);
                foreach (var cat in catList)
                {
                    Console.WriteLine(cat.Title);
                }
                break;
            case "2":
                Console.WriteLine("Category name:");
                string? catName = null;
                while (string.IsNullOrEmpty(catName))
                {
                    catName = Console.ReadLine();
                }
                categories.Add(catName, []);
                break;
            case "3":
                var catNameToRemove = Console.ReadLine();
                if (!string.IsNullOrEmpty(catNameToRemove))
                {
                    categories.Remove(catNameToRemove);
                }
                break;
            default:
                Console.WriteLine("Incorrect choice.");
                break;
        }
    }
    else if (choice == "5")
    {
        return;
    }
    else
    {
        Console.WriteLine("Incorrect choice.");
    }
}
