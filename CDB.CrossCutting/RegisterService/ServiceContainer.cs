using CDB.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CDB.CrossCutting.RegisterService;

public static class ServiceContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddDbContext<CdbContext>(options => {
            options.UseInMemoryDatabase("CdbDatabase");
        });

    }
}

