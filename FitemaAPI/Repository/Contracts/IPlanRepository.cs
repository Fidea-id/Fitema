using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plans>> GetPlanList();
    }
}
