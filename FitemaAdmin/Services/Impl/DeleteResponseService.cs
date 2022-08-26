using FitemaAdmin.Services.Contracts;
using RestSharp;

namespace FitemaAdmin.Services.Impl
{
    public class DeleteResponseService : IDeleteResponseService
    {
        private IUriService _uriService;
        public DeleteResponseService(IUriService uriService)
        {
            _uriService = uriService;
        }

        public async Task<RestResponse> DeleteResponse(string url)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);
            var request = new RestRequest(getUrl, Method.Delete);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<RestResponse> DeleteResponseWithAuth(string url, string auth)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);
            var request = new RestRequest(getUrl, Method.Delete);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + auth);
            var response = await client.ExecuteAsync(request);
            return response;
        }
    }
}
