using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public TransactionRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
