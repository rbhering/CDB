using CDB.Application.Dtos;
using CDB.Domain.Entidades;

namespace CDB.Application.Mapping;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<CdbRequestDto, Cdb>().ReverseMap();
        CreateMap<CdbResponseDto, Cdb>().ReverseMap();
    }
}
