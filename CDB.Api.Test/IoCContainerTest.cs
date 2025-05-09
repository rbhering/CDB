using Microsoft.Extensions.DependencyInjection;

namespace CDB.Api.Test;

public class IoCContainerTest
{
    [Fact]
    public void IoCContainer()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        Application.RegisterService.IoCContainer.RegisterServices(services);
        

        // Assert
        Assert.NotNull(services);
        Assert.Equal(3, services.Count);
    }
}
