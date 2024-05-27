using Catalog.Domain.Configurations;
using Catalog.Domain.Entities;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

internal class ProductRepository(IMongoCollectionFactory mongoCollectionFactory) : Repository<Product>(mongoCollectionFactory), IProductRepository
{
}
