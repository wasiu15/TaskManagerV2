namespace TaskManager.Application.Interfaces.Services
{
    public interface IServiceManager
    {
        ITaskService TaskService { get; }
    }
}
