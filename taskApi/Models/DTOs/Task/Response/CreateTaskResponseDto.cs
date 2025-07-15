using taskApi.Models.Common;

namespace taskApi.Models.DTOs.Task.Response
{
    public class CreateTaskResponseDto : BaseResponseDto
    {
        public TaskData? Task { get; set; }
    }
}
