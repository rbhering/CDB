using CDB.Application.Common.Mocks;
using CDB.Domain.Interfaces;
using Moq;
using Shouldly;
using CDB.Application.Commands.TbCdi;

namespace CDB.Application.Tests.Commands;

public class CreateTbCdiRequestHandlerTests
{
    private readonly Mock<ITbCdiRepository> _mockRepo;

    public CreateTbCdiRequestHandlerTests()
    {
        _mockRepo = MockTbCdiRepository.GetTbCdiRepository();
    }

    [Fact]
    public async Task CreatetTbCdiListTest()
    {
        // Arrange
        var handler = new CreateTbCdiCommandHandler(_mockRepo.Object);

        // Act
        var result = await handler.Handle(
            new CreateTbCdiCommand() { Tb = 1.08M, Cdi = 0.009M}, CancellationToken.None);

        //Assert
        Assert.Equal(typeof(int), result.GetType());
        Assert.Equal(1, result);
    }
}
