using TaskManager.Entities.Models;

namespace Application.Dtos;

public class TaskResponse
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public int AllottedTime { get; set; }
    public int ElapsedTime { get; set; }
    public string EndDate { get; set; }
    public string DueDate { get; set; }
    public int DaysOverDue { get; set; }
    public int DaysLate { get; set; }
    public string Status { get; set; }


    public static explicit operator TaskResponse(UserTask userTask)
    {
        //  THIS WILL CALCULATE THE ELAPSED_TIME IF THE TASK IS NOT COMPLETED
        //  IF THE TASK IS COMPLETED THEN IT WILL GET THE LAST ELAPSED TIME SAVED IN THE DATABASE WHEN THE TASK WAS MARKED CLOSED
        int elapsed_time = userTask.Status ? userTask.ElapsedTime : DateOnly.FromDateTime(DateTime.Now).DayNumber - userTask.StartDate.DayNumber;
        return new TaskResponse
        {
            Id = userTask.Id,
            Name = userTask.Name,
            Description = userTask.Description,
            StartDate = userTask.StartDate.ToString(),
            AllottedTime = userTask.AllottedTime,
            ElapsedTime = elapsed_time,
            Status = userTask.Status ? "CLOSED" : "PENDING",
            DueDate = userTask.StartDate.AddDays(userTask.AllottedTime).ToString(),
            EndDate = userTask.StartDate.AddDays(elapsed_time).ToString(),
            //  DAYS LEFT AFTER THE DUE DATE IF THE TASK WAS NOT COMPLETED
            DaysOverDue = userTask.Status ? 0 : userTask.ElapsedTime - userTask.AllottedTime,
            //  DAYS LEFT BETWEEN TIME THE TASK IS COMPLETED AND THE TOTAL TIME ALLOCATED FOR THE TASK
            DaysLate = userTask.Status ? userTask.AllottedTime - userTask.ElapsedTime : 0
        };
    }
}