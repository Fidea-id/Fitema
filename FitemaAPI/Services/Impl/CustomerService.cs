using AutoMapper;
using FitemaAPI.Helpers;
using FitemaAPI.Repository.Contracts;
using FitemaAPI.Services.Contracts;
using FitemaEntity.Models;
using FitemaEntity.Requests;
using FitemaEntity.Responses;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Cryptography;
using Ubiety.Dns.Core;

namespace FitemaAPI.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<DefaultResponse> AddCustomer(CustomerRequest request)
        {
            var customer = new Customers
            {
                Email = request.Email,
                Name = request.Name,
                OrgId = request.OrgId,
                PhoneNumber = request.PhoneNumber,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            await _customerRepository.CreateCustomer(customer);
            return new DefaultResponse { Success = true, Message = "Success" };
        }

        public async Task<DefaultResponse> DeleteCustomer(int orgId, int id)
        {
            //check
            var get = await _customerRepository.GetCustomerById(orgId, id);
            if(get != null)
            {
                //delete
                await _customerRepository.DeleteCustomer(orgId, id);
                return new DefaultResponse { Success = true, Message = "Success" };
            }
            else
            {
                return new DefaultResponse { Success = false, Message = "Customer not found" };
            }
        }

        public async Task<DefaultResponse<Customers>> GetCustomerById(int orgId, int id)
        {
            //check
            var get = await _customerRepository.GetCustomerById(orgId, id);
            if (get != null)
            {
                //delete
                return new DefaultResponse<Customers> { Success = true, Message = "Success", Data = get };
            }
            else
            {
                return new DefaultResponse<Customers> { Success = false, Message = "Customer not found", Data = null };
            }
        }

        public async Task<DefaultResponse<IEnumerable<Customers>>> GetCustomers(int orgId)
        {
            //check
            var get = await _customerRepository.GetCustomers(orgId);
            if (get != null)
            {
                //delete
                return new DefaultResponse<IEnumerable<Customers>> { Success = true, Message = "Success", Data = get };
            }
            else
            {
                return new DefaultResponse<IEnumerable<Customers>> { Success = false, Message = "Customer not found", Data = null };
            }
        }

        public async Task<DefaultResponse> UpdateCustomer(CustomerUpdateRequest request)
        {
            //check
            var get = await _customerRepository.GetCustomerById(request.OrgId, request.Id);
            if (get != null)
            {
                if (request.Name != null) get.Name = request.Name; 
                if (request.Email != null) get.Email = request.Email; 
                if (request.PhoneNumber != null) get.PhoneNumber = request.PhoneNumber; 
                //update
                await _customerRepository.UpdateCustomer(get);
                return new DefaultResponse { Success = true, Message = "Success" };
            }
            else
            {
                return new DefaultResponse { Success = false, Message = "Customer not found" };
            }
        }
    }
}
