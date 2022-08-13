using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class ProductRepository: IProductRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public ProductRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
