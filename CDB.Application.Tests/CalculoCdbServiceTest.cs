using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Domain.Interfaces.Repositories;
using CDB.Infra.Data.Fake;
using Moq;

namespace CDB.Application.Tests;

[TestClass]
public sealed class CalculoCdbServiceTest
{

    public readonly Mock<ICalculoCdbService> _calculoCdbService = new();

    [TestMethod]
    public void CalculoCdbService_CalcularCdb_Deve_Retornar_Tipo_CdbResponseDto_Valor_Inicial_Positivo()
    {
        // Arrange  
        var cdbRequestDto = new CdbRequestDto()
        {
            QtdMeses = 12,
            ValorInicial = 1250
        };
        ICalculoCdbService calculoCdbService =
            new CalculoCdbService(new Mock<IMesesImpostoRepository>().Object, new Mock<ITbCdiRepository>().Object);
        
        // Act 
        var retorno = calculoCdbService.CalcularCdb(cdbRequestDto);

        // Assert  
        Assert.AreEqual("CDB.Application.Dtos.CdbResponseDto", retorno.Result.ToString());
    }

    [TestMethod]
    public void CalculoCdbService_CalcularCdb_Deve_Retornar_ArgumentException_Valor_Inicial_Negativo()
    {
        // Arrange  
        var cdbRequestDto = new CdbRequestDto()
        {
            QtdMeses = 12,
            ValorInicial = -1250
        };
        ICalculoCdbService calculoCdbService =
            new CalculoCdbService(new Mock<IMesesImpostoRepository>().Object, new Mock<ITbCdiRepository>().Object);

        // Act 
        var retorno = async () => await calculoCdbService.CalcularCdb(cdbRequestDto);

        // Assert  
        Assert.ThrowsExceptionAsync<ArgumentException>(retorno);
    }
    
    [TestMethod]
    public void CalculoCdbService_CalcularCdb_Deve_Retornar_CdbResponseDto_Com_Valores_Corretos()
    {
        // Arrange  
        //Estou instanciando os Repositories, porque eles são Fake, caso contraio, não instanciaria os Repositories em um teste 
        var mesesImpostoRepository = new MesesImpostoRepositoryFake();
        var tbCdiRepository = new TbCdiRepositorFake();

        CalculoCdbService calculoCdbService = 
            new CalculoCdbService(mesesImpostoRepository, tbCdiRepository);
        
        
        // Act  
        var resultado = calculoCdbService.CalcularCdb(new CdbRequestDto
                                                          {
                                                              QtdMeses = 16,
                                                              ValorInicial = 10000
                                                          });

        //Assert
        Assert.AreEqual(2613.13M, resultado.Result.ValorBruto);
        Assert.AreEqual(2155.83M, resultado.Result.ValorLiquido);
    }


}
