namespace TaskManager.Application.Interfaces.Repositories
{
    public interface IRepositoryManager
    {
        ITaskRepository TaskRepository { get; }
        Task SaveAsync();
    }
}
