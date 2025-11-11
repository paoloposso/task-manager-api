using Tasks.Api.Routes.Dto;
using Tasks.Api.Model;

namespace Tasks.Api.Service;

public class TaskService(IMyTaskRepository taskRepository)
{
    private readonly IMyTaskRepository _taskRepository = taskRepository;

    public IEnumerable<MyTask> GetTasks() => _taskRepository.GetTasks();

    public async Task<MyTask?> GetTaskById(int taskId) =>
        await _taskRepository.GetTaskById(taskId);

    public async Task<MyTask?> ToggleTaskStatus(int taskId, bool done)
    {
        var task = await _taskRepository.GetTaskById(taskId);
        if (task is null)
        {
            return null;
        }

        task.Done = done;

        return await _taskRepository.UpdateTask(task);
    }

    public MyTask CreateTask(CreateTaskDto taskDto)
    {
        var tasks = _taskRepository.GetTasks();
        var newTaskId = tasks.Any() ? tasks.Max(t => t.TaskId) + 1 : 1;

        var newTask = new MyTask
        {
            TaskId = newTaskId,
            Description = taskDto.Description,
            Done = false
        };

        return _taskRepository.CreateTask(newTask);
    }
}