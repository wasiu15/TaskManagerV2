using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Interfaces.Services;

namespace TaskManager.Infrastructure.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ITaskService> _taskService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager));
        }

        public ITaskService TaskService => _taskService.Value;

    }
}
