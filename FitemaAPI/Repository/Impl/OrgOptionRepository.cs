using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;

namespace FitemaAPI.Repository.Impl
{
    public class OrgOptionRepository : IOrgOptionRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public OrgOptionRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
