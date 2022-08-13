using Fitema.Models;
using Fitema.Requests;

namespace Fitema.Repository.Contracts
{
    public interface IOrganizationRepository
    {
        Task CreateOrganization(OrganizationRequest data);
        Task<Organizations> GetOrganizationById(int id);
        Task UpdateOrganization(Organizations data);
    }
}
