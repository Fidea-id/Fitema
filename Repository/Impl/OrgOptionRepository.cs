using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class OrgOptionRepository: IOrgOptionRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public OrgOptionRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
