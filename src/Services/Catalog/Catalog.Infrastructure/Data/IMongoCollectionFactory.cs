using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public interface IMongoCollectionFactory
{
    IMongoCollection<T> GetCollection<T>();
}