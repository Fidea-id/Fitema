using FitemaEntity.Responses;
using Newtonsoft.Json;
using RestSharp;

namespace FitemaAdmin.Utils.Helpers
{
    public static class ResponseHelper<T>
    {
        public static ApiResponse<T> SetResponse(RestResponse response)
        {
            var content = JsonConvert.DeserializeObject<T>(response.Content);
            var message = "Success";
            if (!response.IsSuccessful)
            {
                message = "Fail";
            }
            var result = new ApiResponse<T>
            {
                Data = content,
                IsSuccess = response.IsSuccessful,
                StatusCode = response.StatusCode,
                Message = message,
                Error = response.ErrorException
            };
            return result;
        }
        public static ApiResponse<string> SetExceptionResponse(Exception response)
        {
            var message = "Error";
            var result = new ApiResponse<string>
            {
                Data = null,
                IsSuccess = false,
                StatusCode = System.Net.HttpStatusCode.InternalServerError,
                Message = message,
                Error = response
            };
            return result;
        }
    }
}
