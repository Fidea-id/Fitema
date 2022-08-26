using FitemaAdmin.Services.Contracts;
using RestSharp;

namespace FitemaAdmin.Services.Impl
{
    public class GetResponseService : IGetResponseService
    {
        private IUriService _uriService;
        public GetResponseService(IUriService uriService)
        {
            _uriService = uriService;
        }
        public async Task<RestResponse> GetResponse(string url)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);

            var request = new RestRequest(getUrl, Method.Get);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteAsync(request);
            return response;
        }

        public async Task<RestResponse> GetResponseWithAuth(string url, string auth)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);

            var request = new RestRequest(getUrl, Method.Post);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + auth);

            var response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
