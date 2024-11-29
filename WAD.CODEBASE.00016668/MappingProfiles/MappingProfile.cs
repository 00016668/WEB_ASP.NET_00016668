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
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId)); // Maps GroupId

            CreateMap<ContactDto, Contacts>()
                .ForMember(dest => dest.Groups, opt => opt.Ignore());

            CreateMap<Groups, GroupDto>().ReverseMap();
        }
    }
}
