//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

//public class PrograTest : IClassFixture<WebApplicationFactory<Program>>
//{
//    private readonly WebApplicationFactory<Program> _factory;

//    public PrograTest(WebApplicationFactory<Program> factory)
//    {
//        _factory = factory;
//    }

//    [Fact]
//    public void Get_EndpointsReturnSuccessAndCorrectContentType()
//    {
//        // Arrange
//        var client = _factory.CreateClient();

//        // Act
//        //var response = await client.GetAsync("");

//        // Assert
//        //response.EnsureSuccessStatusCode(); // Status Code 200-299
//        //Assert.Equal("text/html; charset=utf-8",
//        //    response.Content.Headers.ContentType.ToString());
//    }
//    protected override IWebHostBuilder CreateWebHostBuilder()
//    {
//        return Program.CreateWebHostBuilder(new string[] { });
//    }
//}
//public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
//{
    
//}
