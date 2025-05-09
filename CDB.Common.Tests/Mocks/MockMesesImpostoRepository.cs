using CDB.Common.Tests;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;

namespace CDB.Application.Common.Mocks;

public static class MockMesesImpostoRepository
{
    public static Mock<IMesesImpostoRepository> GetMesesImpostoRepository()
    {
        List<MesesImposto> listMesesImposto = GetPopulateObjects.GetMesesImpostoList();

        var mockRepo = new Mock<IMesesImpostoRepository>();

        mockRepo.Setup(r => r.GetAllMesesImpostoAsync()).ReturnsAsync(listMesesImposto);

        mockRepo.Setup(r => r.AddMesImpostoAsync(It.IsAny<MesesImposto>())).ReturnsAsync((MesesImposto mesesImposto) =>
        {
            listMesesImposto.Add(mesesImposto);    
            return 1;
        });

        return mockRepo;

    }
}
