namespace todo_console;

public enum Priority
{
    Low,
    Medium,
    High
}

public class TodoTask
{
    public required string Title { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime CreationDate { get; init; } = DateTime.Today;
    public DateTime? DueDate { get; init; }
    public Priority Priority { get; set; } = Priority.Medium;
}
