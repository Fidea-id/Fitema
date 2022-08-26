using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;
using FitemaEntity.Requests;

namespace FitemaAPI.Repository.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public ProductRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<int> CreateProduct(ProductRequest request)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.ExecuteScalarAsync<int>(@"
                insert into Products (
                    OrgId, Name, Price, Period, Promo
                )
                values (
                    @OrgId, @Name, @Price, @Period, @Promo
                );
                select Id from Products where Id = last_insert_id()
            ", request);
        }

        public async Task DeleteProduct(int orgId, int id)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteScalarAsync(@"
                delete from Products where Id = @id And OrgId = @orgId
            ", new { id = id, OrgId = orgId });
        }

        public async Task<IEnumerable<Products>> GetListProduct(int orgId)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryAsync<Products>(@"
            select * from Products 
            where OrgId = @id", new { id = orgId });
        }

        public async Task<Products> GetProductDetail(int orgId, int productId)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryFirstAsync<Products>(@"
                select * from Products where OrgId = @OrgId And Id = p@Id
            ", new { Id = productId, OrgId = orgId });
        }

        public Task UpdateProduct(Products data)
        {
            throw new NotImplementedException();
        }
    }
}
