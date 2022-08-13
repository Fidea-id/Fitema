using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plans>> GetPlanList();
    }
}
