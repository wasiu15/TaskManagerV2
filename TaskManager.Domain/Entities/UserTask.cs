namespace TaskManager.Entities.Models
{
    public class UserTask
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set;}
        public int AllottedTime { get; set; }
        public int ElapsedTime { get; set; }
        public bool Status { get; set; }
    }
}