using taskApi.Models.Common;

namespace taskApi.Models.DTOs.Task.Response
{
    public class UpdateTaskResponseDto: BaseResponseDto
    {
        public TaskData? Task { get; set; }
    }
}
