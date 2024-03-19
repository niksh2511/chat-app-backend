using Microsoft.AspNetCore.Mvc;

namespace API.DTO
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
        public int StatusCode { get; set; } = StatusCodes.Status200OK;
    }
}
