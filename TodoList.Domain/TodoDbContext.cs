using Microsoft.EntityFrameworkCore;
using TodoList.Domain.Tasks;

namespace TodoList.Domain
{
    public class TodoDbContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }

        public TodoDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
