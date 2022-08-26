using RestSharp;

namespace FitemaAdmin.Services
{
    public interface IPutResponseService
    {
        Task<RestResponse> PutResponse(string url, string obj);
        Task<RestResponse> PutResponseWithAuth(string url, string auth, string obj);
    }

}
