using Dapper;
using Fitema.Database;
using Fitema.Models;
using Fitema.Repository.Contracts;

namespace Fitema.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public UserRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstOrDefaultAsync<Users>(@"
                select * from Users 
                where email = @email", new { email = email});
        }

    }
}
