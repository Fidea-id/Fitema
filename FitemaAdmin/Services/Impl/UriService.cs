using FitemaAdmin.Services.Contracts;
using FitemaEntity.Models;

namespace FitemaAdmin.Services.Impl
{
    public class UriService : IUriService
    {
        private readonly URIModel _baseUri;

        public UriService(URIModel baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetBaseUri(UrlType type, string apiPath = null)
        {
            var baseUrl = CheckUrlByType(type);
            var uri = new Uri(baseUrl);
            if (apiPath == null)
            {
                return uri;
            }

            var modifiedUri = baseUrl + "" + apiPath;
            return new Uri(modifiedUri);
        }
        public string GetAPIKey()
        {
            return "b5d73f589d404b97823a2d44762d5e06";
        }

        private string CheckUrlByType(UrlType type)
        {
            string url = null;
            if (type == UrlType.API)
            {
                url = _baseUri.ApiUrl;
            }
            if (type == UrlType.APPS)
            {
                url = _baseUri.AppsUrl;
            }
            if (type == UrlType.LANDING)
            {
                url = _baseUri.LandingUrl;
            }
            return url;
        }
    }
}
