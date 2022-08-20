using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;

namespace FitemaAPI.Repository.Impl
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;
        public UserRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<int> CreateUser(Users user)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.ExecuteScalarAsync<int>(@"
                insert into Users (
                    OrgId, FullName, Email, Password, Role
                )
                values (
                    @OrgId, @FullName, @Email, @Password, @Role
                );
                select Id from Users where Id = last_insert_id()
            ", user);
        }

        public async Task<Users> GetUserByEmail(string email)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstOrDefaultAsync<Users>(@"
                select * from Users 
                where email = @email", new { email = email });
        }

        public async Task<Users> GetUserById(int id)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstOrDefaultAsync<Users>(@"
                select * from Users 
                where id = @id", new { id = id });
        }

    }
}
