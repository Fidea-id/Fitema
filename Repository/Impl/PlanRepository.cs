using Dapper;
using Fitema.Database;
using Fitema.Models;
using Fitema.Repository.Contracts;
using Fitema.Utils.Constants;

namespace Fitema.Repository.Impl
{
    public class PlanRepository: IPlanRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public PlanRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Plans>> GetPlanList()
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryAsync<Plans>(@"
            select * from Plans 
            where StatusId = @status", new { status = StatusActive.ACTIVE });
        }
    }
}
