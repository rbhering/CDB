using CDB.Application.Queries.MesesImposto;
using CDB.Application.Commands.MesesImposto;
using CDB.Application.Common.Mocks;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;
using Shouldly;

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
        var handler = new CreateMesesImpostoCommandHandler(_mockRepo.Object);

        var result = await handler.Handle(
            new CreateMesesImpostoCommand() { PorcentagemImposto = 0.2M, QtdMeses = 2}, CancellationToken.None);

        result.ShouldBeOfType<int>();

        result.Equals(1);
    }
}
