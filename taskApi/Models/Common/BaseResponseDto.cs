namespace taskApi.Models.Common
{
    public abstract class BaseResponseDto
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }
    }
}
