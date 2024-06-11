using AutoMapper;

using Trendit_Project_Web.Models.Dto;

namespace Trendit_Project_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        { 
            CreateMap<VillaCreateDTO,VillaDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
        }
    }
}
