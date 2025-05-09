//using Microsoft.AspNetCore.Builder;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
//using System.Diagnostics.CodeAnalysis;


//public  class Program1
//{
//    [ExcludeFromCodeCoverage]
//    private static void Main(string[] args)
//    {
//        WebApplication app = Bootstrap(args);
//        app.Run();
        
//    }

//    public static WebApplication Bootstrap(string[] args)
//    {
//        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//        // Your code here  

//        WebApplication app = builder.Build();

//        // Your other code here  

//        return app;
//    }
//}

//public static class MyUnitTests
//{
//    [Fact]
//    public static void TestSomething()
//    {
//        Microsoft.VisualStudio.TestPlatform.TestHost.Program progrm; = new Microsoft.VisualStudio.TestPlatform.TestHost.Program();

//        string[] args = Array.Empty<string>();

//        //WebApplication app = 
//        var tt = progrm.Equals(args);

//        Assert.NotNull(app);
//    }
//}
