using RestSharp;

namespace FitemaAdmin.Services
{
    public interface IPostResponseService
    {
        Task<RestResponse> PostResponse(string url, string obj);
        Task<RestResponse> PostResponseWithAuth(string url, string auth, string obj);
    }
}
