using Fitema.Database;

namespace Fitema.Repository.Contracts
{
    public class VoucherRepository: IVoucherRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public VoucherRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
