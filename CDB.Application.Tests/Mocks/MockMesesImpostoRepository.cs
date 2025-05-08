using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDB.Application.Tests.Mocks;

public static class MockMesesImpostoRepository
{
    public static Mock<IMesesImpostoRepository> GetMesesImpostoRepository()
    {
        List<MesesImposto> listMesesImpostoFake = new List<MesesImposto>();
        {
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 12, PorcentagemImposto = 0.2M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 24, PorcentagemImposto = 0.175M });
            listMesesImpostoFake.Add(new MesesImposto { QtdMeses = 60, PorcentagemImposto = 0.15M });
        };

        var mockRepo = new Mock<IMesesImpostoRepository>();

        mockRepo.Setup(r => r.GetAllMesesImpostoAsync()).ReturnsAsync(listMesesImpostoFake);

        mockRepo.Setup(r => r.AddMesImpostoAsync(It.IsAny<MesesImposto>())).ReturnsAsync((MesesImposto mesesImposto) =>
        {
            listMesesImpostoFake.Add(mesesImposto);    
            return 1;
        });

        return mockRepo;

    }
}
