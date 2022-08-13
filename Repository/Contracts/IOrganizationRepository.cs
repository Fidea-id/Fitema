using Fitema.Dtos.User;
using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public interface IOrganizationRepository
    {
        Task CreateOrganization(OrganizationCreateDto data);
        Task<Organizations> GetOrganizationById(int id);
        Task UpdateOrganization(OrganizationCreateDto data);
        Task
    }
}
