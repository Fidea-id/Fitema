using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public OrganizationRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
