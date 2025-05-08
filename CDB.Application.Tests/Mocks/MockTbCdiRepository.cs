using CDB.Common.Tests;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Application.Tests.Mocks;

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
