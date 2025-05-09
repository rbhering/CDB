
using CDB.Application.Dtos;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CDB.Api.Test
{
    public class CdbControllerTest
    {
        [Fact]
        public async Task MyAction_ShouldReturn_Ok()
        {
            // Arrange
            var cdbRequestDto = new CdbRequestDto
            {
                QtdMeses = 12,
                ValorInicial = 12M
            };
            var mockMediatr = new Mock<IMediator>();
            var expectedResult = System.Threading.Tasks.Task.FromResult(
            new CdbResponseDto
            {
                ValorBruto = 12.34M,
                ValorLiquido = 11.23M
            });
            mockMediatr.Setup(m => m.Send(It.IsAny<CdbRequestDtoQuery>(), It.IsAny<CancellationToken>()))
                .Returns(expectedResult);

            // Act
            var controller = new CdbController(mockMediatr.Object);
            var result = await controller.Post(cdbRequestDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            mockMediatr.Verify(m => m.Send(It.IsAny<CdbRequestDtoQuery>(), It.IsAny<CancellationToken>()), Times.Once);

        }

        [Fact]
        public async Task MyAction_ShouldReturn_Model_State_Error()
        {
            // Arrange  
            var cdbRequestDto = new CdbRequestDto
            {
                QtdMeses = -12,
                ValorInicial = -12M
            };
            var mockMediatr = new Mock<IMediator>();
            var expectedResult = System.Threading.Tasks.Task.FromResult(
            new CdbResponseDto
            {
                ValorBruto = 12.34M,
                ValorLiquido = 11.23M
            });
            mockMediatr.Setup(m => m.Send(It.IsAny<CdbRequestDtoQuery>(), It.IsAny<CancellationToken>()))
                .Returns(expectedResult);

            // Act  
            var controller = new CdbController(mockMediatr.Object);
            try
            {
                await controller.Post(cdbRequestDto);
            }
            catch (Exception ex)
            {
                //Assert
                Assert.Equal("Valor Inicial deve ser maior que zero e menor ou igual a 250.000,00.", ex.Message.ToString());
                Assert.IsType<System.ArgumentException>(ex);
            }
        }
    }
}
