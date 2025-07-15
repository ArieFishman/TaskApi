using System.Text.Json;
using taskApi.Models;
using taskApi.Models.Common;
using taskApi.Models.DTOs.Task.Response;
using taskApi.Models.Entities.Task;

namespace taskApi.Services.Task
{
    public class TaskService: ITaskService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "tasks.json");
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        // Method to load tasks
        private List<TaskItem> GetTasksFromJson()
        {
            if (!File.Exists(_filePath))
                return new List<TaskItem>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json, _jsonOptions) ?? new();
        }

        // Method to save tasks
        private void SaveTasksToJson(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }

        public CreateTaskResponseDto CreateTask(TaskItem task)
        {
            var response = new CreateTaskResponseDto();

            try
            {
                var tasks = GetTasksFromJson();

                // Increase id
                task.Id = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;

                tasks.Add(task);
                SaveTasksToJson(tasks);

                response.IsSuccess = true;
                response.Task = new TaskData
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    DueDate = task.DueDate,
                    Status = task.Status
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "שגיאה בהוספת המשימה: " + ex.Message;
            }

            return response;
        }

        public GetTasksResponseDto GetTasks()
        {
            var response = new GetTasksResponseDto();

            try
            {
                var tasks = GetTasksFromJson();

                response.Tasks = tasks.Select(task => new TaskData
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    DueDate = task.DueDate,
                    Status = task.Status
                }).ToList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "שגיאה במשיכת משימות: " + ex.Message;
                response.Tasks = [];
            }

            return response;
        }

        public UpdateTaskResponseDto UpdateTask(int id, TaskItem task)
        {
            var response = new UpdateTaskResponseDto();

            try
            {
                var tasks = GetTasksFromJson();
                var taskToUpdate = tasks.FirstOrDefault(t => t.Id == id);

                if (taskToUpdate == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = $"לא נמצאה משימה עם מזהה {id}.";
                    return response;
                }

                taskToUpdate.Title = task.Title;
                taskToUpdate.Description = task.Description;
                taskToUpdate.Priority = task.Priority;
                taskToUpdate.DueDate = task.DueDate;
                taskToUpdate.Status = task.Status;

                SaveTasksToJson(tasks);

                response.IsSuccess = true;
                response.Task = new TaskData
                {
                    Id = taskToUpdate.Id,
                    Title = taskToUpdate.Title,
                    Description = taskToUpdate.Description,
                    Priority = taskToUpdate.Priority,
                    DueDate = taskToUpdate.DueDate,
                    Status = taskToUpdate.Status
                };
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "שגיאה בעדכון המשימה: " + ex.Message;
            }

            return response;
        }

        public DeleteTaskResponseDto DeleteTask(int id)
        {
            var response = new DeleteTaskResponseDto();

            try
            {
                var tasks = GetTasksFromJson();
                var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);

                if (taskToRemove == null)
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = $"לא נמצאה משימה עם מזהה {id}.";
                    return response;
                }

                tasks.Remove(taskToRemove);
                SaveTasksToJson(tasks);

                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessage = "שגיאה במחיקת המשימה: " + ex.Message;
            }

            return response;
        }

    }
}
