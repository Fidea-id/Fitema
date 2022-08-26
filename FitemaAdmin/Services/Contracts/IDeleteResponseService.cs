using RestSharp;


namespace FitemaAdmin.Services
{
    public interface IDeleteResponseService
    {
        Task<RestResponse> DeleteResponse(string url);
        Task<RestResponse> DeleteResponseWithAuth(string url, string auth);
    }
}
