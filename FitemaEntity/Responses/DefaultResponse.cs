using System.Net;

namespace FitemaEntity.Responses
{
    public class ApiResponse<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public Exception Error { get; set; }
    }
}
