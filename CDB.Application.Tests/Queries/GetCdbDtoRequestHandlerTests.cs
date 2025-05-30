﻿using CDB.Application.Dtos;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Application.Services;
using CDB.Common.Tests;
using Shouldly;

namespace CDB.Application.Tests.Queries; 

public class GetCdbDtoRequestHandlerTests
{

    [Fact]
    public async Task CdbResponseDtoHandler_GetCdbResponseDto()
    {
        // Arrange
        CdbRequestDto cdbRequestDtoMock = new CdbRequestDto { QtdMeses = 10, ValorInicial = 10M };

        var tbCdiMock = GetPopulateObjects.GetTbCdi();
        var mesesImpostosMock = GetPopulateObjects.GetMesesImpostoList();

        var calculoCdbService = new CalculoCdbService(null)
        {
            TbCdi = tbCdiMock,
            MesesImpostos = mesesImpostosMock
        };

        // Act
        var handler = new CdbResponseDtoHandler(calculoCdbService, null);

        var result = await handler.Handle(new CdbRequestDtoQuery(cdbRequestDtoMock), CancellationToken.None);

        // Assert

        result.ShouldBeOfType<CDB.Application.Dtos.CdbResponseDto>();
    }
}
