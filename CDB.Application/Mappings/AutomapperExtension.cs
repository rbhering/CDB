

using Microsoft.Extensions.DependencyInjection;

namespace CDB.Application.Mappings;

public static class AutomapperExtension
{
    public static IServiceCollection AddMappings(IServiceCollection services, Type assemblyContainingMappers)
    {
        services.AddAutoMapper(expression =>
        {
            expression.AllowNullCollections = true;
        }, 
        assemblyContainingMappers);

        return services;
    }
}
