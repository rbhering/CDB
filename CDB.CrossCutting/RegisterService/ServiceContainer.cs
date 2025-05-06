using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CDB.Persistence.Context;

namespace CDB.CrossCutting.RegisterService;

public static class ServiceContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddDbContext<CdbContext>(opt => opt.UseInMemoryDatabase("CdbDatabase"));
    }
}

