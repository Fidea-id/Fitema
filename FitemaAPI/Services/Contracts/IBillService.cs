using FitemaAPI.Helpers;
using FitemaEntity.Dtos.Bill;
using FitemaEntity.Models;
using FitemaEntity.Responses;

namespace FitemaAPI.Services.Contracts
{
    public interface IBillService
    {
        Task<DefaultResponse<IEnumerable<BillResponse>>> GetOrgBills(int orgId);
        Task<DefaultResponse<IEnumerable<PlanDto>>> GetPlans();
        Task<DefaultResponse<BillResponse>> GetActiveBills(int orgId);
    }
}
