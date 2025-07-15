using taskApi.Models.DTOs.Task.Response;
using taskApi.Models.DTOs.Task.Request;
using taskApi.Models.Entities.Task;

namespace taskApi.Services.Task
{
    public interface ITaskService
    {
        public CreateTaskResponseDto CreateTask(TaskItem task);

        public GetTasksResponseDto GetTasks();

        public UpdateTaskResponseDto UpdateTask(int id, TaskItem dto);

        public DeleteTaskResponseDto DeleteTask(int id);
    }
}
