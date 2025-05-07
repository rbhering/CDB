using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Domain.Interfaces;
using CDB.Persistence.Repositories;
using Moq;

namespace CDB.Application.Tests;


public sealed class CalculoCdbServiceTest
{

    public readonly Mock<ICalculoCdbService> _calculoCdbService = new();

    [Fact]
    public void CalculoCdbService_CalcularCdb_Deve_Retornar_Tipo_CdbResponseDto_Valor_Inicial_Positivo()
    {
        // Arrange  
        var cdbRequestDto = new CdbRequestDto()
        {
            QtdMeses = 12,
            ValorInicial = 1250
        };
        ICalculoCdbService calculoCdbService =
            new CalculoCdbService(new Mock<IMesesImpostoRepository>().Object, new Mock<ITbCdiRepository>().Object, null);

        // Act 
        var retorno = /*async () => await*/ calculoCdbService.CalcularCdb(cdbRequestDto);


        Assert.Equal("CDB.Application.Dtos.CdbResponseDto", retorno.Result.ToString());
    }

    [Fact]
    public async Task CalculoCdbService_CalcularCdb_Deve_Retornar_ArgumentException_Valor_Inicial_Negativo()
    {
        // Arrange  
        var cdbRequestDto = new CdbRequestDto()
        {
            QtdMeses = 12,
            ValorInicial = -1250
        };
        ICalculoCdbService calculoCdbService =
            new CalculoCdbService(new Mock<IMesesImpostoRepository>().Object, new Mock<ITbCdiRepository>().Object, null);

        // Act & Assert  
        await Assert.ThrowsAsync<ArgumentException>(async () => await calculoCdbService.CalcularCdb(cdbRequestDto));
    }

    //[Fact]
    //public void CalculoCdbService_CalcularCdb_Deve_Retornar_CdbResponseDto_Com_Valores_Corretos()
    //{
    //    // Arrange  

    //    //Estou instanciando os Repositories, porque eles são de um Banco em Memória criado e populado pela própria aplicação.
    //    //Caso contraio, não instanciaria os Repositories em um teste com valores fixos 
    //    var mesesImpostoRepository = new MesesImpostoRepository();
    //    var tbCdiRepository = new TbCdiRepository();
    //    var bruto = 2613.13M;
    //    var liquido = 2155.83M;

    //    CalculoCdbService calculoCdbService =
    //        new CalculoCdbService(mesesImpostoRepository, tbCdiRepository);


    //    // Act  
    //    var resultado = calculoCdbService.CalcularCdb(new CdbRequestDto
    //    {
    //        QtdMeses = 16,
    //        ValorInicial = 10000
    //    });

    //    //Assert
    //    Assert.Equal(bruto, resultado.Result.ValorBruto);
    //    Assert.Equal(liquido, resultado.Result.ValorLiquido);
    //}


}
