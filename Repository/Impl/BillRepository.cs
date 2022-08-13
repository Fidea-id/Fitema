using Fitema.Database;
using Fitema.Models;
using Fitema.Requests;

namespace Fitema.Repository.Contracts
{
    public class BillRepository: IBillRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public BillRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public Task CreateBill(BillRequest data)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Bills>> GetListBill(int orgId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBillStatus(int billId, int statusId)
        {
            throw new NotImplementedException();
        }
    }
}
