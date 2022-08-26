using RestSharp;

namespace FitemaAdmin.Services
{
    public interface IGetResponseService
    {
        Task<RestResponse> GetResponse(string url);
        Task<RestResponse> GetResponseWithAuth(string url, string auth);
    }
}
