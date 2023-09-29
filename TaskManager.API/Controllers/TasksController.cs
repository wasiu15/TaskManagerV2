using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Dtos;
using TaskManager.Application.Interfaces.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public TasksController(IServiceManager serviceManager)
        {
            _serviceManager= serviceManager;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll()
        {
            var response = await _serviceManager.TaskService.GetTasks();
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpGet("getTaskById")]
        public async Task<ActionResult> GetTaskById([FromQuery] string taskId)
        {
            var response = await _serviceManager.TaskService.GetByTaskId(taskId);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost("createTask")]
        public async Task<ActionResult> AddTask(CreateTaskRequest task)
        {
            var response = await _serviceManager.TaskService.CreateTask(task);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPatch("UpdateTask")]
        public async Task<ActionResult> SetTaskAsClosed([FromQuery] string taskId)
        {
            var response = await _serviceManager.TaskService.SetTaskStatus(taskId);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult> DeleteTask([FromQuery] string taskId)
        {
            var response = await _serviceManager.TaskService.DeleteTask(taskId);
            if (response.IsSuccessful)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
