using Microsoft.EntityFrameworkCore;
using TodoApi.Domain.Entities;

namespace TodoApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TodoItem>(e =>
        {
            e.Property(x => x.Title).HasMaxLength(120).IsRequired();
            e.Property(x => x.Priority).HasMaxLength(20).IsRequired();

        });

    }
}
