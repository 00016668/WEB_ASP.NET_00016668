using AutoMapper;
using WAD.CODEBASE._00016668.DTOs;
using WAD.CODEBASE._00016668.Models;

namespace WAD.CODEBASE._00016668.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contacts, ContactDto>()
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.Groups.GroupName));


            CreateMap<Contacts, ContactDto>().ReverseMap();

            CreateMap<Groups, GroupDto>().ReverseMap();
        }
    }
}
