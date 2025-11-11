using System.ComponentModel.DataAnnotations;

namespace Tasks.Api.Model;

public enum TaskCurrentStatus
{
    Pending,
    InProgress,
    Completed
}

public class MyTask
{
    [Key]
    public int TaskId { get; set; }
    public required string Description { get; set; }
    public bool Done { get; set; }
}
