using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class BillRepository: IBillRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public BillRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
