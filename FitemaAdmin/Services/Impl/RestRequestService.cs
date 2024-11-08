﻿using FitemaAdmin.Services.Contracts;
using RestSharp;

namespace FitemaAdmin.Services.Impl
{
    public class RestRequestService : IRestRequestService
    {
        private IUriService _uriService;
        public RestRequestService(IUriService uriService)
        {
            _uriService = uriService;
        }
        //Get
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

        //Post
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
        //Put
        public async Task<RestResponse> PutResponse(string url, string obj)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);

            var request = new RestRequest(getUrl, Method.Put);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(obj);
            var response = await client.ExecuteAsync(request);
            return response;
        }
        public async Task<RestResponse> PutResponseWithAuth(string url, string auth, string obj)
        {
            var getUrl = _uriService.GetBaseUri(UrlType.API, url);
            var getAPIKey = _uriService.GetAPIKey();
            var client = new RestClient(getUrl);

            var request = new RestRequest(getUrl, Method.Put);
            request.AddHeader("XApiKey", getAPIKey);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer " + auth);
            request.AddJsonBody(obj);
            var response = await client.ExecuteAsync(request);
            return response;
        }

        //Delete
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
