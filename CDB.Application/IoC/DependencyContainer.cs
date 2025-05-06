using CDB.Application.Interfaces;
using CDB.Application.Services;
using CDB.Domain.Interfaces;
using CDB.Persistence;
using Microsoft.Extensions.DependencyInjection;


namespace CDB.Application.IoC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<ICalculoCdbService, CalculoCdbService>();
               
        services.AddScoped<IMesesImpostoRepository, MesesImpostoRepositoryFake>();

        services.AddScoped<ITbCdiRepository, TbCdiRepositorFake>();
    }
}