using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface IOrganizationRepository
    {
        Task<int> CreateOrganization(Organizations data);
        Task<Organizations> GetOrganizationById(int id);
        Task UpdateOrganization(Organizations data);
    }
}
