using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class SystemLogRepository: ISystemLogRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public SystemLogRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
