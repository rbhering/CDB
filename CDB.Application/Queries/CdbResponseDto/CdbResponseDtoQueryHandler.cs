using MediatR;
using CDB.Application.Interfaces;
using System;
using CDB.Application.Services;

namespace CDB.Application.Queries.CdbResponseDto;

public class CdbResponseDtoHandler(ICalculoCdbService calculoCdbService) : IRequestHandler<CdbRequestDtoQuery, Dtos.CdbResponseDto>
{
    public async Task<Dtos.CdbResponseDto> Handle(CdbRequestDtoQuery request, CancellationToken cancellationToken)
    {
        return await calculoCdbService.CalcularCdb(request.Result);
    }
}
