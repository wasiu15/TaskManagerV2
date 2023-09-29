using TaskManager.Entities.Models;

namespace TaskManager.Application.Dtos
{
    public class TaskDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AllocatedTime { get; set; }
        public string Status { get; set; }


        public static explicit operator TaskDto(UserTask userTask)
        {
            return new TaskDto
            {
                Id = userTask.Id,
                Name = userTask.Name,
                Description = userTask.Description,
                AllocatedTime = userTask.AllottedTime,
                Status = userTask.Status ? "CLOSED" : "PENDING"
            };
        }
    }
}