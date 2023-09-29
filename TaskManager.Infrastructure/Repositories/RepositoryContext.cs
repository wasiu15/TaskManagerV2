using Microsoft.EntityFrameworkCore;
using TaskManager.Entities.Models;
using TaskManager.Infrastructure.Repositories.Configuration;

namespace TaskManager.Infrastructure.Repositories
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new TaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserTask>? Tasks { get; set; }
    }
}
