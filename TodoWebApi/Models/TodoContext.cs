using Microsoft.EntityFrameworkCore;

namespace TodoWebApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;
    }
}
