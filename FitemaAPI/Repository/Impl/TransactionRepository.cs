using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;

namespace FitemaAPI.Repository.Impl
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public TransactionRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
