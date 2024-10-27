using AutoMapper;
using MagicVilla.Models.VillaDbModels;
using MagicVilla.Models.VillaDtoModels;

namespace MagicVilla.WebApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Villa, VillaDto>().ReverseMap();
            //CreateMap<VillaDto, Villa>();

            CreateMap<Villa, VillaCreateDto>().ReverseMap();
            CreateMap<Villa, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberDto>().ReverseMap();

            CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
        }
    }
}
