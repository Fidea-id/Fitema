using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;

namespace FitemaAPI.Repository.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public CustomerRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<int> CreateCustomer(Customers request)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.ExecuteScalarAsync<int>(@"
                insert into Customers (
                    OrgId, Name, Email, PhoneNumber
                )
                values (
                    @OrgId, @Name, @Email, @PhoneNumber
                );
                select Id from Customers where Id = last_insert_id()
            ", request);
        }

        public async Task DeleteCustomer(int id, int orgId)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteScalarAsync(@"
                delete from Customers where Id = @id And OrgId = @orgId
            ", new { id = id, OrgId = orgId });
        }

        public async Task<IEnumerable<Customers>> GetCustomers(int orgId)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryAsync<Customers>(@"
                select * from Customers where OrgId = @Id
            ", new { Id = orgId });
        }
    }
}
