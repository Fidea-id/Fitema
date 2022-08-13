using Fitema.Models;

namespace Fitema.Repository.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> GetListProduct(int orgId);
    }
}
