using Microsoft.EntityFrameworkCore;
using Tasks.Api.Model;

namespace Tasks.Api.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<MyTask> Tasks { get; set; }
    }
}
