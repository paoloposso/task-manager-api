using Microsoft.EntityFrameworkCore;
using Tasks.Api.Data;
using Tasks.Api.Model;
using Tasks.Api.Service;

namespace Tasks.Api.Repository
{
    public class MyTaskRepository(TaskDbContext context) : IMyTaskRepository
    {
        private readonly TaskDbContext _context = context;

        public IEnumerable<MyTask> GetTasks() => _context.Tasks.ToList();

        public async Task<MyTask?> GetTaskById(int taskId) =>
            await _context.Tasks.FirstOrDefaultAsync(t => t.TaskId == taskId);

        public MyTask CreateTask(MyTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public async Task<MyTask?> UpdateTask(MyTask task)
        {
            var existingTask = await GetTaskById(task.TaskId);
            if (existingTask is null)
            {
                return null;
            }

            existingTask.Done = task.Done;
            existingTask.Description = task.Description;
            _context.SaveChanges();

            return existingTask;
        }
    }
}
