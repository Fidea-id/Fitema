using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;

namespace FitemaAPI.Repository.Impl
{
    public class SystemLogRepository : ISystemLogRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public SystemLogRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task CreateLog(SystemLog log)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteScalarAsync(@"
                insert into SystemLog (
                    Status, Type, Detail, CreatedAt, UpdatedAt
                )
                values (
                    @Status, @Type, @Detail, @CreatedAt, @UpdatedAt
                );
                select Id from SystemLog where Id = last_insert_id()
            ", log);
        }
    }
}
