using Dapper;
using Fitema.Database;
using Fitema.Models;
using Fitema.Requests;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Transactions;

namespace Fitema.Repository.Contracts
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public OrganizationRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task CreateOrganization(OrganizationRequest data)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteScalarAsync(@"
                insert into Organizations (
                    Name, Address, Description, StatusId
                )
                values (
                    @Name, @Address, @Description, @StatusId
                );
                select Id from Organizations where Id = last_insert_id()
            ", data);
        }

        public async Task<Organizations> GetOrganizationById(int id)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstAsync<Organizations>(@"
                select Name, Address, Description, StatusId
                from Organizations
                where Id = @Key
		    ", new { Key = $"{id}" }
            );
        }

        public async Task UpdateOrganization(Organizations data)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteAsync(@"
                update Organizations 
                set Name = @Name,
                    Address = @Address,
                    Description = @Description,
                    UpdatedAt = now()
                where Id = @Id
            ", data);
        }
    }
}
