using FitemaEntity.Models;

namespace FitemaAPI.Repository.Contracts
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomer(Customers request);
        Task UpdateCustomer(Customers request);
        Task<IEnumerable<Customers>> GetCustomers(int orgId);
        Task<Customers> GetCustomerById(int orgId, int custId);
        Task DeleteCustomer(int orgId, int id);
    }
}
