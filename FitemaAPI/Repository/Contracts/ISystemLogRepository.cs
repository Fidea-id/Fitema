using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface ISystemLogRepository
    {
        Task CreateLog(SystemLog log);
    }
}
