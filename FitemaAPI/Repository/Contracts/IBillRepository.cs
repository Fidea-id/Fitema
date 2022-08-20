using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface IBillRepository
    {
        Task<int> CreateBill(Bills data);
        Task<IEnumerable<Bills>> GetListBill(int orgId);
        Task UpdateBillStatus(int billId, int statusId);
    }
}
