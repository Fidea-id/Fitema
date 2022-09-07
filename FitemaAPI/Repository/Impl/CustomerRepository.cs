using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;
using MySqlX.XDevAPI.Relational;

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

        public async Task DeleteCustomer(int orgId, int id)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteScalarAsync(@"
                delete from Customers where Id = @id And OrgId = @orgId
            ", new { id = id, OrgId = orgId });
        }

        public async Task<Customers> GetCustomerById(int orgId, int custId)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstAsync<Customers>(@"
                select * from Customers where OrgId = @Id And Id = @CustId
            ", new { Id = orgId, CustId = custId });
        }

        public async Task<IEnumerable<Customers>> GetCustomers(int orgId)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryAsync<Customers>(@"
                select * from Customers where OrgId = @Id
            ", new { Id = orgId });
        }

        public async Task UpdateCustomer(Customers request)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteAsync(@"
                update Customers 
                set Name = @name,
                    Email = @email.
                    PhoneNumber = @phone,
                    UpdatedAt = @now
                where Id = @id
            ", new { id = request.Id, name = request.Name, email = request.Email, phone = request.PhoneNumber, now = DateTime.UtcNow });
        }
    }
}
