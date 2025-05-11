using CDB.Application.Commands.MesesImposto;
using CDB.Application.Common.Mocks;
using CDB.Domain.Interfaces;
using Moq;

namespace CDB.Application.Tests.Commands;

public class CreateMesesImpostRequestHandlerTests
{
    private readonly Mock<IMesesImpostoRepository> _mockRepo;

    public CreateMesesImpostRequestHandlerTests()
    {
        _mockRepo = MockMesesImpostoRepository.GetMesesImpostoRepository();
    }

    [Fact]
    public async Task CreatetMesesImposttoListTest()
    {
        // Arrange
        var handler = new CreateMesesImpostoCommandHandler(_mockRepo.Object);

        // Act
        var result = await handler.Handle(
            new CreateMesesImpostoCommand() { PorcentagemImposto = 0.2M, QtdMeses = 2}, CancellationToken.None);

        //Assert
        Assert.Equal(typeof(int), result.GetType());
        Assert.Equal(1, result);
    }
}
