using MediatR;
using CDB.Application.Interfaces;
using System;
using CDB.Application.Services;

namespace CDB.Application.Queries.CdbResponseDto;

public class CdbResponseDtoHandler(ICalculoCdbService calculoCdbService) : IRequestHandler<CdbResponseDtoQuery, Dtos.CdbResponseDto>
{
    public async Task<Dtos.CdbResponseDto> Handle(CdbResponseDtoQuery request, CancellationToken cancellationToken)
    {
        return await calculoCdbService.CalcularCdb(request.Result);
    }
}

//////////////////////////////////////////////////////

//public class CdbResponseDtoQuery : IRequest<Dtos.CdbResponseDto>
//{
//    public CdbResponseDtoQuery(Dtos.CdbRequestDto result)
//    {
//        Result = result;
//    }
//    public Dtos.CdbRequestDto Result { get; set; }
//}
//public class GetPersonQueryHandler(ICalculoCdbService calculoCdbService) : IRequestHandler<CdbResponseDtoQuery, Dtos.CdbResponseDto>
//{
//    public async Task<Dtos.CdbResponseDto> Handle(CdbResponseDtoQuery request, CancellationToken cancellationToken)
//    {
//        return await calculoCdbService.CalcularCdb(request.Result);
//    }
//}