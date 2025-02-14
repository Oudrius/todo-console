namespace UI;

internal static class MenuHandler
{
    internal static void MainMenu()
    {
        Console.WriteLine(@"Menu:
            1. Add new task.
            2. Read tasks.
            3. Edit task.
            4. Categories
            5. Exit.
        ");
    }

    internal static void TaskMenu()
    {
        Console.WriteLine(@"
            1. Complete task.
            2. Change priority.
            3. Add to category.
        ");
    }

    internal static void PriorityMenu()
    {
        Console.WriteLine(@"
            1. High
            2. Medium
            3. Low
        ");
    }

    internal static void CategoryMenu()
    {
        Console.WriteLine(@"
            1. Display categories.
            2. Add new category.
            3. Remove category.
        ");
    }

    internal static void QueryMenu()
    {
        Console.WriteLine(@"
            1. Filter by status.
            2. Filter by duedate.
            3. Exit.
        ");
    }

    internal static void StatusQueryMenu()
    {
        Console.WriteLine(@"
            1. Low
            2. Medium
            3. High
        ");
    }
}