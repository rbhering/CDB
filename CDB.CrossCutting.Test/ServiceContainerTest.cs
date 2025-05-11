using Microsoft.Extensions.DependencyInjection;
using CDB.CrossCutting.RegisterService;


namespace CDB.CrossCutting.Test;

public class ServiceContainerTest()
{    
    [Fact]
    public void Register_And_Populate_DataBase_Contex_tTest()
    {
        // Arrange and Act
        bool? resultado = ServiceContainer.RegisterAndPopulateDataBaseContext(new ServiceCollection());

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(true, resultado);
    }
}
