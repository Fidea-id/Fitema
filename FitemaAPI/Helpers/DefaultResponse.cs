namespace FitemaAPI.Helpers
{
    public class DefaultResponse<T>
    {
        public DefaultResponse()
        {
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }

    public class DefaultResponse
    {
        public DefaultResponse()
        {
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
