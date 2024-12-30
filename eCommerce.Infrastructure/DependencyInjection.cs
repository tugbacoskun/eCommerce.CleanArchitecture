using eCommerce.Application.Common.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Infrastructure.Data;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMongoDb(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbContext>();

        services.AddScoped<IMongoRepository<Catalog>>(provider =>
        {
            var dbContext = provider.GetRequiredService<MongoDbContext>();
            return new MongoRepository<Catalog>(dbContext.Catalogs.Database, "Catalogs");
        });

        services.AddScoped<IMongoRepository<Product>>(provider =>
        {
            var dbContext = provider.GetRequiredService<MongoDbContext>();
            return new MongoRepository<Product>(dbContext.Products.Database, "Products");
        });

        services.AddScoped<IMongoRepository<CatalogProduct>>(provider =>
        {
            var dbContext = provider.GetRequiredService<MongoDbContext>();
            return new MongoRepository<CatalogProduct>(dbContext.CatalogProducts.Database, "CatalogProducts");
        });

        return services;
    }
}