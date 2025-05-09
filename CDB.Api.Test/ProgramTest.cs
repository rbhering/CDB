//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using Microsoft.AspNetCore.Mvc.Testing;
//using CDB.Application.Dtos;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.Extensions.DependencyInjection;
//using CDB.Domain.Interfaces;
//using CDB.Persistence.Repositories;

//namespace CDB.Api.Test;

//public class ProgramTest
//{
//    [Fact]
//    public async Task Program_Should_Start_Application_Correctly()
//    {
//        // Arrange  
//        var application = new WebApplicationFactory<Program>();

//        // Act  
//        try
//        {
//            var client = application.CreateClient();

//            var response = await client.GetAsync("/");
//        }
//        catch (Exception ex)
//        {
//            var tt = ex;
//            throw;
//        }
     
//        //var response = await client.PostAsync("/cdb", ()new CdbRequestDto() { QtdMeses = 10, ValorInicial = 1000});

//        // Assert  
//        //Assert.True(response.IsSuccessStatusCode);
//    }

//    [Fact]
//    public async Task Get_QuoteService_ProvidesQuoteInPage()
//    {
//        var facory = new WebApplicationFactory<Program>();

//        // Arrange
//        var client = facory.WithWebHostBuilder(builder =>
//        {
//            builder.ConfigureTestServices(services =>
//            {
//                services.AddScoped<IMesesImpostoRepository, MesesImpostoRepository>();
//            });
//        }).CreateClient();

//        //Act
//        var defaultPage = await client.GetAsync("/");

//        // Assert
//        //Assert.Equal("Something's interfering with time, Mr. Scarman, " +
//        //    "and time is my business.", quoteElement.Attributes["value"].Value);
//    }
//}
