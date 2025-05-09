using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Services;
using CDB.Application.Common.Mocks;
using CDB.Common.Tests;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;
using Shouldly;

namespace CDB.Application.Tests.Queries;

public class GetCdbDtoRequestHandlerTests
{

    [Fact]
    public async Task CdbResponseDtoHandler_GetCdbResponseDto()
    {
        CdbRequestDto cdbRequestDtoMock = new CdbRequestDto { QtdMeses = 10, ValorInicial = 10M };

        var tbCdiMock = GetPopulateObjects.GetTbCdi();
        var mesesImpostosMock = GetPopulateObjects.GetMesesImpostoList();

        var calculoCdbService = new CalculoCdbService(null)
        {
            TbCdi = tbCdiMock,
            MesesImpostos = mesesImpostosMock
        };

        var handler = new CdbResponseDtoHandler(calculoCdbService, null);

        var result = await handler.Handle(new CdbRequestDtoQuery(cdbRequestDtoMock), CancellationToken.None);

        result.ShouldBeOfType<CDB.Application.Dtos.CdbResponseDto>();

        result.ValorBruto.ShouldBe(11.23M);
        result.ValorLiquido.ShouldBe(10.25M);
    }
}
