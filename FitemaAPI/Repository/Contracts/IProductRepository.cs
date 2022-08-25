using FitemaEntity.Models;
using FitemaEntity.Requests;

namespace FitemaAPI.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<int> CreateProduct(ProductRequest request);
        Task UpdateProduct(Products data);
        Task DeleteProduct(int orgId, int id);
        Task<IEnumerable<Products>> GetListProduct(int orgId);
        Task<Products> GetProductDetail(int orgId, int productId);
    }
}
