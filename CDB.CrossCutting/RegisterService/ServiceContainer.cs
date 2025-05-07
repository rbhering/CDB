using CDB.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CDB.CrossCutting.RegisterService;

public static class ServiceContainer
{
    public static void RegisterDataBaseContext(IServiceCollection services)
    {
        services.AddDbContext<CdbContext>(options => {
            options.UseInMemoryDatabase("CdbDatabase");
        });
    }

}

