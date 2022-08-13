using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public CustomerRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
