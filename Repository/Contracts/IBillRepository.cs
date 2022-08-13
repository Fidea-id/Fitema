using Fitema.Models;
using Fitema.Requests;

namespace Fitema.Repository.Contracts
{
    public interface IBillRepository
    {
        Task CreateBill(BillRequest data);
        Task<IEnumerable<Bills>> GetListBill(int orgId);
        Task UpdateBillStatus(int billId, int statusId);
    }
}
