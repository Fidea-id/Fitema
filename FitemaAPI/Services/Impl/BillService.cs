using AutoMapper;
using FitemaAPI.Helpers;
using FitemaAPI.Repository.Contracts;
using FitemaAPI.Services.Contracts;
using FitemaEntity.Dtos.Auth;
using FitemaEntity.Responses;
using Microsoft.Extensions.Options;

namespace FitemaAPI.Services.Impl
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMapper _mapper;
        public BillService(IBillRepository billRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _billRepository = billRepository;
        }
        public async Task<DefaultResponse<IEnumerable<BillResponse>>> GetOrgBills(int orgId)
        {
            var request = await _billRepository.GetListBill(orgId);
            var response = _mapper.Map<IEnumerable<BillResponse>>(request);

            return new DefaultResponse<IEnumerable<BillResponse>> { Data = response, Message = "Success", Success = true } ;
        }
    }
}
