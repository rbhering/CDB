using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using CDB.Persistence.Context;
using CDB.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CDB.CrossCutting.RegisterService;

public static class ServiceContainer
{
    public static bool RegisterAndPopulateDataBaseContext(IServiceCollection services)
    {
        services.AddDbContext<CdbContext>(options =>
        {
            options.UseInMemoryDatabase("CdbDatabase");
        });

        CdbContext context = new CdbContext(new DbContextOptionsBuilder<CdbContext>()
            .UseInMemoryDatabase("CdbDatabase")
            .Options);

        ITbCdiRepository tbCdiRepository = new TbCdiRepository(context);
        IMesesImpostoRepository mesesImpostoRepository = new MesesImpostoRepository(context);

        tbCdiRepository.AddTbCdiAsync(new TbCdi { Tb = 1.08M, Cdi = 0.009M });

        mesesImpostoRepository.AddMesImpostoAsync(new MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
        mesesImpostoRepository.AddMesImpostoAsync(new MesesImposto { QtdMeses = 12, PorcentagemImposto = 0.2M });
        mesesImpostoRepository.AddMesImpostoAsync(new MesesImposto { QtdMeses = 24, PorcentagemImposto = 0.175M });
        mesesImpostoRepository.AddMesImpostoAsync(new MesesImposto { QtdMeses = 60, PorcentagemImposto = 0.15M });

        return mesesImpostoRepository.GetAllMesesImpostoAsync().Result.Count > 0 &&
                tbCdiRepository.GetSingleTbCdiAsync().Result != null;
    }

}

