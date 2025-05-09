using MediatR;
using CDB.Application.Interfaces;

namespace CDB.Application.Queries.CdbResponseDto;

public class CdbResponseDtoHandler(ICalculoCdbService calculoCdbService, IMediator? mediator) 
    : IRequestHandler<CdbRequestDtoQuery, Dtos.CdbResponseDto>
{
    public async Task<Dtos.CdbResponseDto> Handle(CdbRequestDtoQuery request, CancellationToken cancellationToken)
    {    
        return await calculoCdbService.CalcularCdb(request.Result);
    }
}
