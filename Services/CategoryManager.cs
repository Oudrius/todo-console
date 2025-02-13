using Models;

namespace Services;

internal class CategoryManager
{
    public void CreateCategory(Dictionary<string, List<TodoTask>> categories)
    {
        Console.WriteLine("Category name:");
        string? catName = null;
        while (string.IsNullOrEmpty(catName))
        {
            catName = Console.ReadLine();
        }
        categories.Add(catName, []);
    }

    public void ReadCategories(Dictionary<string, List<TodoTask>> categories)
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("No categories found.");
            return;
        }
        Console.WriteLine("Categories:");
        var k = 1;
        foreach (var category in categories)
        {
            Console.WriteLine($"{k}. {category.Key}");
            k++;
        }
        Console.WriteLine("Choose a category:");
        try
        {
            var categoryChoice = Convert.ToInt16(Console.ReadLine()) - 1;
            var catList = categories.Values.ElementAt(categoryChoice);
            foreach (var cat in catList)
            {
                Console.WriteLine(cat.Title);
            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RemoveCategory(Dictionary<string, List<TodoTask>> categories)
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("No categories found.");
            return;
        }
        Console.WriteLine("Categories:");
        var k = 1;
        foreach (var category in categories)
        {
            Console.WriteLine($"{k}. {category.Key}");
            k++;
        }
        Console.WriteLine("Choose a category:");
        try
        {
            var categoryChoice = Convert.ToInt16(Console.ReadLine()) - 1;
            var catToRemove = categories.ElementAt(categoryChoice).Key;
            Console.WriteLine(catToRemove);
            categories.Remove(catToRemove);
            Console.WriteLine($"Successfully removed category {catToRemove}");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}