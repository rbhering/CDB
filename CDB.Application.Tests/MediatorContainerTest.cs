using CDB.Application.RegisterService;
using Microsoft.Extensions.DependencyInjection;

namespace CDB.Application.Tests;

public class MediatorContainerTest()
{
    [Fact]
    public void RegisterServices()
    {
        var services = new ServiceCollection();
        MediatorContainer.RegisterServices(services);

        Assert.Equal(true,services.Count > 0);
    }
}
