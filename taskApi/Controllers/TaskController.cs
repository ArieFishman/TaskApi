using Microsoft.AspNetCore.Mvc;
using taskApi.Models.DTOs.Task.Request;
using taskApi.Models.Entities.Task;
using taskApi.Services.Task;

namespace taskApi.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService) 
        { 
            _taskService = taskService;
        }

        [HttpPost]
        public ActionResult CreateTask([FromBody] CreateTaskRequestDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Priority = taskDto.Priority,
                DueDate = taskDto.DueDate,
                Status = taskDto.Status
            };

            var response = _taskService.CreateTask(task);

            if (!response.IsSuccess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        public ActionResult GetTasks()
        {
            var response = _taskService.GetTasks();

            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(int id, UpdateTaskRequestDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                Priority = taskDto.Priority,
                DueDate = taskDto.DueDate,
                Status = taskDto.Status
            };

            var response = _taskService.UpdateTask(id, task);

            if (!response.IsSuccess)
            {
                if (response.ErrorMessage.Contains("לא נמצאה"))
                    return NotFound(response);
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var response = _taskService.DeleteTask(id);

            if (!response.IsSuccess)
            {
                if (response.ErrorMessage.Contains("לא נמצאה"))
                    return NotFound(response);
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
