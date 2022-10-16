using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;

namespace BusinessLogic.Helpers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<PhoneDTO, Phone>();

            CreateMap<Phone, PhoneDTO>()
                .ForMember(dest => dest.ColorName, act => act.MapFrom(src => src.Color.Name));

            CreateMap<Color, ColorDTO>().ReverseMap();
        }
    }
}