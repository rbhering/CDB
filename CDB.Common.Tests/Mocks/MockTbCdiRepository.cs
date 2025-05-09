using CDB.Common.Tests;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;

namespace CDB.Application.Common.Mocks;

public static class MockTbCdiRepository
{
    public static Mock<ITbCdiRepository> GetTbCdiRepository()
    {
        TbCdi tbCdiMock = GetPopulateObjects.GetTbCdi();

        var mockRepo = new Mock<ITbCdiRepository>();

        mockRepo.Setup(r => r.GetSingleTbCdiAsync()).ReturnsAsync(tbCdiMock);

        mockRepo.Setup(r => r.AddTbCdiAsync(It.IsAny<TbCdi>())).ReturnsAsync((TbCdi tbCdi) =>
        {
            tbCdiMock = tbCdi;
            return 1;
        });

        return mockRepo;

    }
}
