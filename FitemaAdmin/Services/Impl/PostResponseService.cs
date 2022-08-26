using FitemaAdmin.Services.Contracts;
using RestSharp;

namespace FitemaAdmin.Services.Impl
{
    public class PostResponseService : IPostResponseService
    {
        private IUriService _uriService;

        public PostResponseService(IUriService uriService)
        {
            _uriService = uriService;
        }

        public async Task<RestResponse> PostResponse(string url, string obj)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);

            var request = new RestRequest(getUrl, Method.Post);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(obj);
            var response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<RestResponse> PostResponseWithAuth(string url, string auth, string obj)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);

            var request = new RestRequest(getUrl, Method.Post);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + auth);
            request.AddJsonBody(obj);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
