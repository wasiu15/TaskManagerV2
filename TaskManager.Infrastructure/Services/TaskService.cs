using Application.Dtos;
using TaskManager.Application.Dtos;
using TaskManager.Application.Interfaces.Repositories;
using TaskManager.Application.Interfaces.Services;
using TaskManager.Domain.Exceptions;
using TaskManager.Entities.Models;

namespace TaskManager.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repositoryManager;
        public TaskService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async Task<GenericResponse<IEnumerable<TaskResponse>>> GetTasks()
        {
            // THIS WILL GET ALL TASKS FROM THE REPOSITORY
            var tasks = await _repositoryManager.TaskRepository.GetTasks();
            var response = new List<TaskResponse>();
            foreach (var task in tasks)
            {
                response.Add((TaskResponse)task);
                var temp = DateOnly.FromDateTime(DateTime.Now).DayNumber - task.StartDate.DayNumber;
            }

            return new GenericResponse<IEnumerable<TaskResponse>>
            {
                IsSuccessful = true,
                ResponseCode = "200",
                ResponseMessage = response.Count() > 0 ? "Successfully fetched all tasks. Total number: " + tasks.Count() : "No Task Found.",
                Data = response
            };
        }

        public async Task<GenericResponse<TaskResponse>> GetByTaskId(string taskId)
        {
            //  CHECK IF TASK ID IS ENTERED
            if (string.IsNullOrEmpty(taskId))
                throw new CustomBadRequestException("Please, enter a valid task ID");

            // THIS WILL GET TASK FROM THE REPOSITORY
            var task = await _repositoryManager.TaskRepository.GetByTaskId(taskId, false);

            //  CHECK IF THE TASK EXIST
            if (task == null)
                throw new CustomNotFoundException("Task not found");

            var fullTaskDetails = (TaskResponse)task;

            return new GenericResponse<TaskResponse>
            {
                IsSuccessful = true,
                ResponseCode = "200",
                ResponseMessage = "Successfully fetched task from the database",
                Data = fullTaskDetails
            };
        }

        public async Task<GenericResponse<TaskResponse>> SetTaskStatus(string taskId)
        {

            //  CHECK IF TASK ID IS ENTERED
            if (string.IsNullOrEmpty(taskId))
                throw new CustomBadRequestException("Please, enter a valid task ID");

            // THIS WILL GET TASK FROM THE REPOSITORY
            var task = await _repositoryManager.TaskRepository.GetByTaskId(taskId, false);

            //  CHECK IF TASK EXIST
            if (task == null)
                throw new CustomNotFoundException("Task not found");
            
            //  CHECK IF TASK IS ALREADY CLOSED
            if (task.Status)
                throw new CustomDuplicateRequestException("Task is already closed");

            int elapsed_time = DateOnly.FromDateTime(DateTime.Now).DayNumber - task.StartDate.DayNumber;

            task.Status = true;
            task.ElapsedTime = elapsed_time;
            _repositoryManager.TaskRepository.UpdateTask(task);
            await _repositoryManager.SaveAsync();

            // CONVERT TASK TO A RESPONSE OBJECT
            var fullTaskDetails = (TaskResponse)task;

            return new GenericResponse<TaskResponse>
            {
                IsSuccessful = true,
                ResponseCode = "200",
                ResponseMessage = "Successfully updated task in the database",
                Data = fullTaskDetails
            };
        }

        public async Task<GenericResponse<TaskDto>> CreateTask(CreateTaskRequest task)
        {
            //  ALLOCATED TIME SHOULD BE A NUMBER AND MUST BE GREATER THAN ZERO
            if (task == null || task.AllottedTime < 1)
                throw new CustomBadRequestException(task == null ? "Please enter all fields correctly" : "Allotted time must be greater than zero");

            //  SAVE TO NOTIFICATION TABLE
            UserTask taskToSave = new UserTask
            {
                Id = Guid.NewGuid().ToString(),
                Name = task.Name,
                Description = task.Description,
                StartDate = DateOnly.FromDateTime(DateTime.UtcNow),
                AllottedTime = task.AllottedTime,
                ElapsedTime = task.AllottedTime,
                Status = false
            };
            
            _repositoryManager.TaskRepository.CreateTask(taskToSave);
            await _repositoryManager.SaveAsync();
            
            //  CHECK IF THE LIST IS EMPTY
            return new GenericResponse<TaskDto>
            {
                IsSuccessful = true,
                ResponseCode = "201",
                ResponseMessage = "New task created successfully",
                Data = (TaskDto)taskToSave
            };

        }
        public async Task<GenericResponse<TaskResponse>> DeleteTask(string taskId)
        {
            //  CHECK IF REQUIRED INPUTS ARE ENTERED
            if (string.IsNullOrEmpty(taskId))
                throw new CustomBadRequestException("Please, enter the task Id");

            Guid taskIdGuid = new Guid(taskId);
            var checkIfTaskExist = await _repositoryManager.TaskRepository.GetByTaskId(taskId, true);

            //  CHECK IF THE TASK EXIST
            if (checkIfTaskExist == null)
                throw new CustomNotFoundException("Task not found");

            
            //  DELETE FROM TASK DATABASE
            _repositoryManager.TaskRepository.DeleteTask(checkIfTaskExist);
            await _repositoryManager.SaveAsync();

            return new GenericResponse<TaskResponse>
            {
                IsSuccessful = true,
                ResponseCode = "200",
                ResponseMessage = "Successfully deleted your task in the database",
            };
        }
    }
}