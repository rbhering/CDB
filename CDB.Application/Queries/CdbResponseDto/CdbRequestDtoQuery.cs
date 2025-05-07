using MediatR;

namespace CDB.Application.Queries.CdbResponseDto;

public class CdbResponseDtoQuery : IRequest<Dtos.CdbResponseDto>
{
    public CdbResponseDtoQuery(Dtos.CdbRequestDto result)
    {
        Result = result;
    }
    public Dtos.CdbRequestDto Result { get; set; }
}