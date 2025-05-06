using Microsoft.Extensions.DependencyInjection;
using CDB.Persistence;

namespace CDB.Application.RegisterService;

public static class MediatorContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}

