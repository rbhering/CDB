using CDB.Application.Dtos;
using CDB.Application.RegisterService;
using CDB.Application.Validators;
using CDB.CrossCutting.RegisterService;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

ServiceContainer.RegisterAndPopulateDataBaseContext(builder.Services);
IoCContainer.RegisterServices(builder.Services);
MediatorContainer.RegisterServices(builder.Services);


builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CdbRequestDtoValidator>();
builder.Services.AddTransient<IValidator<CdbRequestDto>, CdbRequestDtoValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
