using RestSharp;

namespace FitemaAdmin.Services
{
    public interface IRestRequestService
    {
        //Get
        Task<RestResponse> GetResponse(string url);
        Task<RestResponse> GetResponseWithAuth(string url, string auth);
        //Post
        Task<RestResponse> PostResponse(string url, string obj);
        Task<RestResponse> PostResponseWithAuth(string url, string auth, string obj);
        //Put
        Task<RestResponse> PutResponse(string url, string obj);
        Task<RestResponse> PutResponseWithAuth(string url, string auth, string obj);
        //Delete
        Task<RestResponse> DeleteResponse(string url);
        Task<RestResponse> DeleteResponseWithAuth(string url, string auth);
    }
}
