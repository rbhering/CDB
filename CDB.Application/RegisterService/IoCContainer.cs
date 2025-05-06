using Microsoft.Extensions.DependencyInjection;
using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Domain.Interfaces;
using CDB.Persistence.Repositories;

namespace CDB.Application.RegisterService;

public static class IoCContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICalculoCdbService, CalculoCdbService>();

        services.AddScoped<IMesesImpostoRepository, MesesImpostoRepository>();

        services.AddScoped<ITbCdiRepository, TbCdiRepository>();
    }
}
