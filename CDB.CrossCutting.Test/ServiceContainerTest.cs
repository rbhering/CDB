using Microsoft.Extensions.DependencyInjection;
using CDB.CrossCutting.RegisterService;


namespace CDB.CrossCutting.Test;

public class ServiceContainerTest()
{    
    [Fact]
    public void RegisterAndPopulateDataBaseContextTest()
    {
        // Arrange and Act
        bool? resultado = ServiceContainer.RegisterAndPopulateDataBaseContext(new ServiceCollection());

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(true, resultado);
    }
}
