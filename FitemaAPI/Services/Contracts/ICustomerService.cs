using FitemaEntity.Models;
using FitemaEntity.Requests;

namespace FitemaAPI.Services.Contracts
{
    public interface ICustomerService
    {
        Task AddCustomer(CustomerRequest request);
        Task<IEnumerable<Customers>> GetCustomers(int orgId);
        Task<Customers> GetCustomerById(int orgId, int id);
        Task UpdateCustomer(int id, CustomerRequest request);
        Task DeleteCustomer(int id);
    }
}
