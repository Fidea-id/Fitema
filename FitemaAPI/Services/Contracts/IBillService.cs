using FitemaAPI.Helpers;
using FitemaEntity.Responses;

namespace FitemaAPI.Services.Contracts
{
    public interface IBillService
    {
        Task<DefaultResponse<IEnumerable<BillResponse>>> GetOrgBills(int orgId);
    }
}
