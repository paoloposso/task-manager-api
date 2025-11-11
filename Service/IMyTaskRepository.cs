using Tasks.Api.Model;

namespace Tasks.Api.Service;

public interface IMyTaskRepository
{
    IEnumerable<MyTask> GetTasks();
    Task<MyTask?> GetTaskById(int taskId);
    MyTask CreateTask(MyTask task);
    Task<MyTask?> UpdateTask(MyTask task);
}
