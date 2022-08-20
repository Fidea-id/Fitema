using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;

namespace FitemaAPI.Repository.Impl
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public VoucherRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }
    }
}
