using MediatR;

namespace CDB.Application.Queries.CdbResponseDto;

public class CdbRequestDtoQuery : IRequest<Dtos.CdbResponseDto>
{
    public CdbRequestDtoQuery(Dtos.CdbRequestDto result)
    {
        Result = result;
    }
    public Dtos.CdbRequestDto Result { get; set; }
}