using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;

namespace FitemaAPI.Repository.Impl
{
    public class FitemaDataRepository : IFitemaDataRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public FitemaDataRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public Task<IEnumerable<FitemaData>> GetFitemaDataByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
