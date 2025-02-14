using Models;

internal class QueryService
{
    internal List<TodoTask> StatusQuery(List<TodoTask> tasks, Priority priority)
    {
        IEnumerable<TodoTask> statusQuery =
            from task in tasks
            where task.Priority == priority
            select task;
        
        List<TodoTask> todoTasks = [];
        foreach (var i in statusQuery)
        {
            todoTasks.Add(i);
        }

        return todoTasks;
    }
}