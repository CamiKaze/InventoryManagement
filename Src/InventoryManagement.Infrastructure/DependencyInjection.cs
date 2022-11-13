using InventoryManagement.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Infrastructure.Data;
using InventoryManagement.Domain.Models.Abstract;

namespace InventoryManagement.Infrastructure;

public static class DependencyInjeciton
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("ConnectionString")));
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}