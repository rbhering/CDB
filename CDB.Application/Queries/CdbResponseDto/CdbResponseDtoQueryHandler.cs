using MediatR;
using CDB.Application.Interfaces;
using CDB.Application.PopulateDataBaseInMemory;

namespace CDB.Application.Queries.CdbResponseDto;

public class CdbResponseDtoHandler(ICalculoCdbService calculoCdbService, IMediator? mediator) 
    : IRequestHandler<CdbRequestDtoQuery, Dtos.CdbResponseDto>
{
    public async Task<Dtos.CdbResponseDto> Handle(CdbRequestDtoQuery request, CancellationToken cancellationToken)
    {
        if(mediator != null)
        {
            await PopulateDataBase.PopulateDatabaseInMemory(mediator);
            await calculoCdbService.PopulateMesesImpostoAsync();
            await calculoCdbService.PopulateTbCdiAsync();
        }
    
        return calculoCdbService.CalcularCdb(request.Result);
    }
}
