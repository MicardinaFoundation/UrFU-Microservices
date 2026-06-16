using AutoMapper;
using RecuperatorCore.Models;
using KotelUtilizatorLibrary.Models;

namespace RecuperatorCore
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VariantAddDto, Variant>();
            CreateMap<UserAddDto, User>();
            CreateMap<VariantUserAddDto, VariantUser>();
        }
    }
}
