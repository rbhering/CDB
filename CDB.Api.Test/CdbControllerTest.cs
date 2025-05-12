using CDB.Application.Dtos;
using CDB.Application.Queries.CdbResponseDto;
using CDB.Api.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CDB.Application.Validators;

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
            var validator = new CdbRequestDtoValidator();
            var controller = new CdbController(mockMediatr.Object, validator); //!!!!!!!!!!!!!!!!!!!!!!!! VER ISSO
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

            // Act
            var validator = new CdbRequestDtoValidator();
            var controller = new CdbController(mockMediatr.Object, validator);

            // Assert
            BadRequestObjectResult badRequestObjectResult = (BadRequestObjectResult) await controller.Post(cdbRequestDto);
            Assert.Equal(400, badRequestObjectResult.StatusCode);
            
        }
    }
}
