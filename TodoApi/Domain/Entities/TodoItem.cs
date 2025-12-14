namespace TodoApi.Domain.Entities;

public class TodoItem
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string? Description { get; set; }

    public bool IsDone { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DueDate { get; set; }

    public string Priority { get; set; } = "Normal";

}
