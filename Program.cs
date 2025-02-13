using Models;
using Services;
using UI;

var categories = new Dictionary<string, List<TodoTask>>();
var tasks = new List<TodoTask>();
var taskManager = new TaskManager();
var categoryManager = new CategoryManager();
string? choice = null;
while (choice != "5")
{
    MenuHandler.MainMenu();
    Console.WriteLine("Enter your choice:");
    choice = Console.ReadLine();


    if (choice == "1")
    {
        taskManager.AddTask(tasks);
    }
    else if (choice == "2")
    {
        taskManager.ReadTasks(tasks);
    }
    else if (choice == "3")
    {
        taskManager.UpdateTasks(tasks, categories);
    }
    else if (choice == "4")
    {
        MenuHandler.CategoryMenu();
        var catChoice = Console.ReadLine();
        switch (catChoice)
        {
            case "1":
                categoryManager.ReadCategories(categories);
                break;
            case "2":
                categoryManager.CreateCategory(categories);
                break;
            case "3":
                categoryManager.RemoveCategory(categories);
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
