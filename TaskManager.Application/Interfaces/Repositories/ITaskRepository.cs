using TaskManager.Entities.Models;

namespace TaskManager.Application.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        void CreateTask(UserTask task);
        void DeleteTask(UserTask task);
        void UpdateTask(UserTask task);
        Task<IEnumerable<UserTask>> GetTasks();
        Task<UserTask> GetByTaskId(string taskId, bool trackChanges);
    }
}
