
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Application.DTOs;
using TodoApi.Domain.Entities;
using TodoApi.Infrastructure.Data;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    private readonly AppDbContext _db;

    public TodosController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll()
    {
        var items = await _db.TodoItems
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new TodoDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsDone = x.IsDone,
                CreatedAt = x.CreatedAt,
                DueDate = x.DueDate,
                Priority = x.Priority

            })
            .ToListAsync();

        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create(TodoCreateDto dto)
    {
        var entity = new TodoItem
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Priority = dto.Priority
        };

        _db.TodoItems.Add(entity);
        await _db.SaveChangesAsync();

        var result = new TodoDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            IsDone = entity.IsDone,
            CreatedAt = entity.CreatedAt,
            DueDate = entity.DueDate,
            Priority = entity.Priority
        };

        return CreatedAtAction(nameof(GetAll), new { id = entity.Id }, result);
    }
}
