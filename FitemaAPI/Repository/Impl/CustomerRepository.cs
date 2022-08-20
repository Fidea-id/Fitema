using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;
using FitemaEntity.Requests;

namespace FitemaAPI.Repository.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public CustomerRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task CreateCustomer(Customers request)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteScalarAsync(@"
                insert into Customers (
                    OrgId, Name, Email, PhoneNumber
                )
                values (
                    @OrgId, @Name, @Email, @PhoneNumber
                );
                select Id from Bills where Id = last_insert_id()
            ", request);
        }

        public Task DeleteCustomer(int id, int orgId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customers>> GetCustomers(int orgId)
        {
            throw new NotImplementedException();
        }
    }
}
