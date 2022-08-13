using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public interface IFitemaDataRepository
    {
        public Task<IEnumerable<FitemaData>> GetFitemaDataByType(string type);
    }
}
