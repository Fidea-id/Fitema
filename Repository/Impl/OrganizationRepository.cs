using Fitema.Database;
using Fitema.Dtos.User;
using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public OrganizationRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public Task CreateOrganization(OrganizationCreateDto data)
        {
            throw new NotImplementedException();
        }

        public Task<Organizations> GetOrganizationById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrganization(OrganizationCreateDto data)
        {
            throw new NotImplementedException();
        }
    }
}
