using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface IFitemaDataRepository
    {
        public Task<IEnumerable<FitemaData>> GetFitemaDataByType(string type);
    }
}
