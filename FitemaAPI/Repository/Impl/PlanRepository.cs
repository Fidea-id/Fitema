using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;
using FitemaEntity.Utils.Constants;

namespace FitemaAPI.Repository.Impl
{
    public class PlanRepository : IPlanRepository
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

        public async Task<Plans> GetPlanById(int id)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstOrDefaultAsync<Plans>(@"
            select * from Plans 
            where StatusId = @status && Id == @id", new { status = StatusActive.ACTIVE, id = id });
        }
    }
}
