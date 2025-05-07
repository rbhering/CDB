using CDB.Application.RegisterService;
using CDB.CrossCutting.RegisterService;
using CDB.Persistence.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
IoCContainer.RegisterServices(builder.Services);
MediatorContainer.RegisterServices(builder.Services);

ServiceContainer.RegisterServices(builder.Services);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.  
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
