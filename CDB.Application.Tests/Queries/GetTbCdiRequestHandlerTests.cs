using CDB.Application.Queries.TbCdi;
using CDB.Application.Common.Mocks;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;
using Shouldly;

namespace CDB.Application.Tests.Queries
{
    public class GetTbCdiRequestHandlerTests
    {
        private readonly Mock<ITbCdiRepository> _mockRepo;

        public GetTbCdiRequestHandlerTests()
        {
            _mockRepo = MockTbCdiRepository.GetTbCdiRepository();
        }

        [Fact]
        public async Task GetTbCdiListTest()
        {
            // Arrange
            var handler = new TbCdiQueryHandler(_mockRepo.Object);

            // Act
            var result = await handler.Handle(new TbCdiQuery(), CancellationToken.None);

            //Assert
            result.ShouldBeOfType<TbCdi>();

            result.Cdi.ShouldBe(0.009M);
        }
    }
}
