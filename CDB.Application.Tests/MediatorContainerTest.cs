using CDB.Application.RegisterService;
using Microsoft.Extensions.DependencyInjection;

namespace CDB.Application.Tests;

public class MediatorContainerTest()
{
    [Fact]
    public void RegisterServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        MediatorContainer.RegisterServices(services);

        // Assert
        Assert.True(services.Count > 0);
    }
}
