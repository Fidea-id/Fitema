using AutoMapper;
using FitemaEntity.Models;
using FitemaEntity.Responses;

namespace FitemaAPI.MapperProfiles
{
    public class BillProfile: Profile
    {
        public BillProfile()
        {
            CreateMap<Bills, BillResponse>();
        }
    }
}
