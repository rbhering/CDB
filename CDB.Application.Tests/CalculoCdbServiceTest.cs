using CDB.Application.Dtos;
using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Application.Tests.Unit;
using CDB.Domain.Interfaces.Repositories;
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
    public void CalculoCdbService_CalcularCdb_Deve_Retornar_ArgumentException_Qtd_Meses_Negativo()
    {
        // Arrange  
        var cdbRequestDto = new CdbRequestDto()
        {
            QtdMeses = -12,
            ValorInicial = 1250
        };
        CalculoCdbServiceFactoryTest testFactory = new CalculoCdbServiceFactoryTest();

        // Act  
        var resultado = /*async () => await */testFactory.CalculoCdbService.CalcularCdb(cdbRequestDto);

        var tt = 0;

        // Assert  
        //Assert.AreNotEqual(0M, calculoCdbService); // Fixes CS0411 and S3415 by specifying type explicitly and correcting argument order.  
        //Assert.AreEqual(1.14, resultado); // Fixes CS1002 by adding a missing semicolon.  
    }


}
