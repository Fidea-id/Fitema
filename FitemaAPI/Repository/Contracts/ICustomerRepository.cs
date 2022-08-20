using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface ICustomerRepository
    {
        Task CreateCustomer(Customers request);
        Task<IEnumerable<Customers>> GetCustomers(int orgId);
        Task DeleteCustomer(int id, int orgId);
    }
}
