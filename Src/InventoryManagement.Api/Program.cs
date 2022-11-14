using InventoryManagement.Domain;
using InventoryManagement.Infrastructure;

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);
{
    // This is the dependency for AppSettings.
    builder.Services
    .AddDomain()
    .AddInfrastructure(configuration)
    .AddSwaggerGen()
    .AddEndpointsApiExplorer();

    builder.Services.AddControllers();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
