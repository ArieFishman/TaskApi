using taskApi.Models.Common;

namespace taskApi.Models.DTOs.Task.Response
{
    public class GetTasksResponseDto: BaseResponseDto
    {
        public List<TaskData>? Tasks { get; set; }
    }
}
