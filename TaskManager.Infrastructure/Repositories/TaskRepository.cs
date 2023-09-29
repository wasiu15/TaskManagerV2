using Microsoft.EntityFrameworkCore;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Entities.Models;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : RepositoryBase<UserTask>, ITaskRepository
    {
        public TaskRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateTask(UserTask task) => Create(task);
        public void DeleteTask(UserTask task) => Delete(task);
        public void UpdateTask(UserTask task) => Update(task);
        public async Task<IEnumerable<UserTask>> GetTasks() => await FindAll(false).ToListAsync();
        public async Task<UserTask> GetByTaskId(string taskId, bool trackChanges) => await FindByCondition(x => x.Id.Equals(taskId), trackChanges).FirstOrDefaultAsync();
    }
}
