using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                .Property(e => e.IsComplete)
                .HasDefaultValue(true);

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem() { Id = 1, Name = "First Item", IsComplete = true });
        }
    }
}
