using AutoMapper;
using CDB.Application.Dtos;
using CDB.Domain.Entities;

namespace CDB.Application.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<MesesImposto, MesessImpostoDto>().ReverseMap()
                .ForMember(x => x.MesesImpostoId, y => y.Ignore());

            CreateMap<TbCdi, TbCdiDto>().ReverseMap()
                .ForMember(x => x.TbCdiId, y => y.Ignore());
        }
    }
}
