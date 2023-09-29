using Application.Dtos;
using TaskManager.Application.Dtos;

namespace TaskManager.Application.Interfaces.Services
{
    public interface ITaskService
    {
        Task<GenericResponse<IEnumerable<TaskResponse>>> GetTasks();
        Task<GenericResponse<TaskDto>> CreateTask(CreateTaskRequest task);
        Task<GenericResponse<TaskResponse>> GetByTaskId(string taskId);
        Task<GenericResponse<TaskResponse>> DeleteTask(string taskId);
        Task<GenericResponse<TaskResponse>> SetTaskStatus(string taskId);

    }
}
