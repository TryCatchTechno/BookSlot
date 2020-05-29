
using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Business, BusinessToReturnDto>().ForMember(d => d.BusinessCategory, o => o.MapFrom(s => s.BusinessCategory.Name));
        }
    }
}