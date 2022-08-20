using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetListProduct(int orgId);
    }
}
