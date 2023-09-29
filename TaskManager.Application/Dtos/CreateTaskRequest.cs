namespace TaskManager.Application.Dtos
{
    public class CreateTaskRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int AllottedTime { get; set; }
    }
}
