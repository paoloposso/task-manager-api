using Tasks.Api.Routes.Dto;
using Tasks.Api.Service;

namespace Tasks.Api.Routes;

public static class TaskRoutes
{
    public static void MapTaskRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/tasks", (TaskService taskService) =>
            {
                return Results.Ok(taskService.GetTasks());
            })
            .WithName("GetTasks");

        app.MapPatch("/tasks/{taskId}/toggle-status/{done}", async (int taskId, bool done, TaskService taskService) =>
            {
                var task = await taskService.ToggleTaskStatus(taskId, done);

                if (task is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(task);
            })
            .WithName("ToggleTaskStatus");

        app.MapPost("/tasks", (CreateTaskDto taskDto, TaskService taskService) =>
            {
                var createdTask = taskService.CreateTask(taskDto);
                return Results.Created($"/tasks/{createdTask.TaskId}", createdTask);
            })
            .WithName("CreateTask");
    }
}
