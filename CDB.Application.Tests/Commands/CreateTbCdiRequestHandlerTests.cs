using CDB.Application.Commands.MesesImposto;
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
        var handler = new CreateTbCdiCommandHandler(_mockRepo.Object);

        var result = await handler.Handle(
            new CreateTbCdiCommand() { Tb = 1.08M, Cdi = 0.009M}, CancellationToken.None);

        result.ShouldBeOfType<int>();

        result.Equals(1);
    }
}
