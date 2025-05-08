using AutoFixture;
using CDB.Application.Commands.MesesImposto;
using CDB.Application.Commands.TbCdi;
using CDB.Application.Dtos;
using CDB.Application.PopulateDataBaseInMemory;
using CDB.Application.Queries.MesesImposto;
using CDB.Application.Queries.TbCdi;
using CDB.Domain.Entities;
using CDB.Domain.Interfaces;
using CDB.Persistence.Context;
using CDB.Persistence.Repositories;
using CDB.Server.Controllers;
using FakeItEasy;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;

namespace CDB.Application.Tests;


public sealed class CalculoCdbServiceTest
{
    private readonly IMediator _mediator;
    private readonly CdbController sut;
    private readonly Mock<IMediator> mediatorMoq;

    //[Fact]
    //public async Task ShouldReturnNotFound_WhenGoatIdDoesNotExist()
    //{
    //    // Arrange
    //    var services = new ServiceCollection();
    //    var serviceProvider = services
    //        .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TbCdiQuery).Assembly))
    //        .BuildServiceProvider();

    //    var mediator = serviceProvider.GetRequiredService<IMediator>();

    //    var query = new TbCdiQuery();

    //    // Act
    //    var response = await mediator.Send(query);

    //    // Assert
    //    Assert.Equal(typeof(CDB.Application.Dtos.CdbResponseDto), response.GetType());
    //}

    public CalculoCdbServiceTest()
    {
        
        var services = new ServiceCollection();
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(CdbRequestDto).Assembly)
        );

        services.AddDbContext<CdbContext>(options => {
            options.UseInMemoryDatabase("CdbDatabase");
        });

        var a = services.AddScoped<IMediator, Mediator>();

    }

    //public class MyHandler : IRequestHandler<Unit>
    //{
    //    public MyHandler(IDoSomething doSomething)
    //    {
    //        _doSomething = doSomething;
    //    }

    //    public Task Handle(MyRequest req, CancellationToken cancellationToken)
    //    {
    //        _doSomething.Do();

    //        return Unit.Value;
    //    }
    //}

    //[Fact]
    //public void GetHandHeldByIMEI_ShouldReturn_HandHeldWrapperDataView()
    //{
    //    //Arrange
    //    var fixture = new Fixture();
    //    var imei = "imeiNo";
    //    var handHeldWrapperDataViewMoq = fixture.Create<MesesImpostoQuery>();
    //    mediatorMoq.Setup(x => x.Send(new MesesImpostoQuery())).Returns(handHeldWrapperDataViewMoq);

    //    //Act
    //    ??

    //    //Assert
    //      ??
    //}

    //[Fact]
    //public async void UpdateCustomerCommand_CustomerDataUpdatedOnDatabase()
    //{
    //    //Arrange
    //    var mediator = new Mock<IMediator>();

    //    MesesImpostoQuery query = new MesesImpostoQuery();
    //    MesesImpostoQueryHandler handler = new MesesImpostoQueryHandler(mediator.Object);

    //    //Act
    //    Unit x = await handler.Handle(query, new System.Threading.CancellationToken());

    //    //Assert
    //    //Do the assertion

    //    //something like:
    //    mediator.(x => x.Publish(It.IsAny<CustomersChanged>()));
    //}

    //[Fact]
    //public async Task CalculoCdbService_CalcularCdb_Deve_Retornar_Tipo_CdbResponseDto_Valor_Inicial_Positivo()
    //{

    //var options = new DbContextOptionsBuilder<CdbContext>()
    //    .UseInMemoryDatabase(databaseName: "banco")
    //    .Options;

    //// Insert seed data into the database using one instance of the context
    //using (var context = new CdbContext(options))
    //{
    //    context.MesesImposto.Add(new Domain.Entities.MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
    //    context.SaveChanges();
    //}


    //var _context = new CdbContext(options);

    //if (!_context.Database.CanConnect())
    //    _context.Database.EnsureCreated();

    //_context.MesesImposto.Add(new Domain.Entities.MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
    //var tt = _context.MesesImposto.ToList();

    //var ooo = new MesesImpostoRepository(_context).GetAllMesesImpostoAsync();

    //var _mediator = new Mock<IMediator>();

    ////_mediator.Setup(x => x.Send(It.IsAny<MesesImpostoQuery>()));  


    ////await PopulateDataBase.PopulateDatabaseInMemory(_mediator);

    //// Arrange  
    //var cdbRequestDto = new CdbRequestDto()
    //{
    //    QtdMeses = 12,
    //    ValorInicial = 1250
    //};

    //// Act  
    ////var retorno = await _mediator.Send(cdbRequestDto);

    //// Assert  
    ////Assert.Equal(typeof(CDB.Application.Dtos.CdbResponseDto), retorno.GetType());
    //}


    ////////////////////////////////////////////////////////////////////////////////////////
    /// ESTA CHEGANDO LÁ
    ////////////////////////////////////////////////////////////////////////////////////////
    //[Fact]
    //public async void YourCommandHandler_ShouldReturnExpectedResult()
    //{

    //    var options = new DbContextOptionsBuilder<CdbContext>()
    //        .UseInMemoryDatabase(databaseName: "CdbDatabase")
    //        .Options;

    //    // Insert seed data into the database using one instance of the context
    //    using (var context = new CdbContext(options))
    //    {
    //        context.MesesImposto.Add(new Domain.Entities.MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
    //        context.SaveChanges();
    //    }


    //    var _context = new CdbContext(options);

    //    if (!_context.Database.CanConnect())
    //        _context.Database.EnsureCreated();

    //    _context.MesesImposto.Add(new Domain.Entities.MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
    //    var tt = _context.MesesImposto.ToList();

    //    IMesesImpostoRepository mesesImpostosRepository = new MesesImpostoRepository(_context);

    //    // Arrange
    //    var services = new ServiceCollection();
    //    var serviceProvider = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(MesesImpostoQueryHandler).Assembly))
    //                                  .BuildServiceProvider();
    //    var mediator = serviceProvider.GetRequiredService<IMediator>();

    //    MesesImpostoQueryHandler handler = new MesesImpostoQueryHandler(mesesImpostosRepository);
    //    var ppp = await handler.Handle(new MesesImpostoQuery(), new System.Threading.CancellationToken());

    //    // Act
    //    var result = await handler.Handle(new MesesImpostoQuery(), new System.Threading.CancellationToken());

    //    // Assert
    //    Assert.Equal(new List<MesesImposto>(), result);
    //}

    //[Fact]
    //public async void YourCommandHandler_ShouldReturnExpectedResult_Tudo_Mockado()
    //{

    //    var options = new DbContextOptionsBuilder<CdbContext>()
    //        .UseInMemoryDatabase(databaseName: "CdbDatabase")
    //        .Options;

    //    // Insert seed data into the database using one instance of the context
    //    using (var context = new CdbContext(options))
    //    {
    //        context.MesesImposto.Add(new Domain.Entities.MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
    //        context.SaveChanges();
    //    }


    //    var _context = new CdbContext(options);

    //    if (!_context.Database.CanConnect())
    //        _context.Database.EnsureCreated();

    //    _context.MesesImposto.Add(new Domain.Entities.MesesImposto { QtdMeses = 6, PorcentagemImposto = 0.225M });
    //    var tt = _context.MesesImposto.ToList();

    //    IMesesImpostoRepository mesesImpostosRepository = new MesesImpostoRepository(_context);

    //    var services = new ServiceCollection();
    //    var serviceProvider = services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(MesesImpostoQueryHandler).Assembly))
    //                                  .BuildServiceProvider();
    //    var mediator = serviceProvider.GetRequiredService<IMediator>();

    //    MesesImpostoQueryHandler handler = new MesesImpostoQueryHandler(mesesImpostosRepository);
        
    //    var result = await handler.Handle(new MesesImpostoQuery(), new System.Threading.CancellationToken());

       
    //    //Assert.Equal(new List<MesesImposto>(), result);
    //}

    //[Fact]
    //public async Task ShouldReturnNotFound_WhenGoatIdDoesNotExist()
    //{
    //    var services = new ServiceCollection();
    //    var serviceProvider = services
    //        .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(MesesImpostoQueryHandler).Assembly))
    //        .AddScoped<IMesesImpostoRepository, MesesImpostoRepository>()
    //        .BuildServiceProvider();

    //    var mediator = serviceProvider.GetRequiredService<IMediator>();

    //    var query = new MesesImpostoQueryHandler(serviceProvider.GetRequiredService<IMesesImpostoRepository>());
    //    var response = await mediator.Send(query);

    //    var tt = 0;
    //    //response.IsSuccess.Should().BeTrue();
    //    //response.Value.Should().BeOfType<GetGoatResponse>();
    //    //var result = response.Value.As<GetGoatResponse>();
    //    //result.Id.Should.Be(goatId);


    //    //response.IsSuccess.Should().BeFalse();
    //    //response.Error.Should().BeOfType<NotFoundError>();
    //}
}
