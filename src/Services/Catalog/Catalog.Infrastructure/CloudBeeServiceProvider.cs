using Catalog.Domain;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;

namespace Catalog.Infrastructure;

internal class CloudBeeServiceProvider(IProductRepository productRepository) : ICloudBeeServiceProvider
{
    public IProductRepository Products => productRepository;
}
