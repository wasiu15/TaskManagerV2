using TaskManager.Application.Interfaces.Repositories;

namespace TaskManager.Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<ITaskRepository> _taskRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _taskRepository = new Lazy<ITaskRepository>(() => new TaskRepository(repositoryContext));
        }

        public ITaskRepository TaskRepository => _taskRepository.Value;
        public async Task SaveAsync() => _repositoryContext.SaveChanges();

    }
}
