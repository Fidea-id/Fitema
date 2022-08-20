using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;

namespace FitemaAPI.Repository.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public ProductRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<IEnumerable<Products>> GetListProduct(int orgId)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryAsync<Products>(@"
            select * from Products 
            where OrgId = @id", new { id = orgId });
        }
    }
}
