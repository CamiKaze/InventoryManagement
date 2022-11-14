using InventoryManagement.Domain.Services;
using InventoryManagement.Domain.Models.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Domain;

public static class DependencyInjeciton
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();

        return services;
    }
}