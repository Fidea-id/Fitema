using FitemaAPI.Helpers;
using FitemaEntity.Models;
using FitemaEntity.Responses;

namespace FitemaAPI.Services.Contracts
{
    public interface IBillService
    {
        Task<DefaultResponse<IEnumerable<BillResponse>>> GetOrgBills(int orgId);
        Task<DefaultResponse<IEnumerable<Plans>>> GetPlans();
        Task<DefaultResponse<IEnumerable<Plans>>> GetActiveBills();
    }
}
