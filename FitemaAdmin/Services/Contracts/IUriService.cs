namespace FitemaAdmin.Services.Contracts
{
    public enum UrlType { API, APPS, LANDING };
    public interface IUriService
    {
        Uri GetBaseUri(UrlType type, string query = null);
        string GetAPIKey();
    }
}
