using FitemaAPI.Helpers;
using FitemaEntity.Models;
using FitemaEntity.Requests;

namespace FitemaAPI.Services.Contracts
{
    public interface ICustomerService
    {
        Task<DefaultResponse> AddCustomer(CustomerRequest request);
        Task<DefaultResponse<IEnumerable<Customers>>> GetCustomers(int orgId);
        Task<DefaultResponse<Customers>> GetCustomerById(int orgId, int id);
        Task<DefaultResponse> UpdateCustomer(CustomerUpdateRequest request);
        Task<DefaultResponse> DeleteCustomer(int orgId, int id);
    }
}
