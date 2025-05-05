using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Domain.Interfaces.Repositories;
using CDB.Infra.Data.Fake;
using Microsoft.Extensions.DependencyInjection;


namespace CDB.Application.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICalculoCdbService, CalculoCdbService>();
               
        services.AddScoped<IMesesImpostoRepository, MesesImpostoRepositoryFake>();

        services.AddScoped<ITbCdiRepository, TbCdiRepositorFake>();
    }
}