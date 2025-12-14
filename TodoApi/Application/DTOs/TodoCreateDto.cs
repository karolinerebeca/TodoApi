namespace TodoApi.Application.DTOs;

public class TodoCreateDto
{
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public string Priority { get; set; } = "Normal";
}
