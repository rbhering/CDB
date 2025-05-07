using Microsoft.Extensions.DependencyInjection;

namespace CDB.Application.RegisterService;

public static class MediatorContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
    }
}

