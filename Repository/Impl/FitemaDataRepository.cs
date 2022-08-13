using Fitema.Database;
using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public class FitemaDataRepository : IFitemaDataRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public FitemaDataRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public Task<IEnumerable<Models.FitemaData>> GetFitemaDataByType(string type)
        {
            throw new NotImplementedException();
        }
    }
}
