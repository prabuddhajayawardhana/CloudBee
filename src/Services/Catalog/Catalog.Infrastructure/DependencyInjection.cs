using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Catalog.Domain.Configurations;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Catalog.Domain.Interfaces;
using Catalog.Domain;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Options;

namespace Catalog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        // Configure MongoDB settings
        services.Configure<MongoDbSettings>(configuration.GetSection(nameof(MongoDbSettings)));

        // Register MongoDB settings as a singleton
        services.AddSingleton<IMongoDbSettings>(sp =>
            sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

        // Register MongoCollectionFactory as a singleton
        services.AddSingleton<IMongoCollectionFactory, MongoCollectionFactory>();

        // Register ProductRepository
        services.AddScoped<IProductRepository, ProductRepository>();

        // Register ICloudBeeServiceProvider
        services.AddScoped<ICloudBeeServiceProvider, CloudBeeServiceProvider>();

        return services;
    }
}