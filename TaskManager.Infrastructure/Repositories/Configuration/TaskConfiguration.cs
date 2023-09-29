using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManager.Entities.Models;

namespace TaskManager.Infrastructure.Repositories.Configuration
{
    public class TaskConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.HasData
            (
                new UserTask
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Name1",
                    Description = "Description1",
                    StartDate = new DateOnly(2023, 11, 10),
                    AllottedTime = 10,
                    ElapsedTime = 20,
                    Status = true
                },
                new UserTask
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Name2",
                    Description = "Description2",
                    StartDate = new DateOnly(2023, 12, 08),
                    AllottedTime = 20,
                    ElapsedTime = 40,
                    Status = false
                }
            );
        }
    }
}
