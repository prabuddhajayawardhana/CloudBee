using Catalog.Domain.Configurations;
using Catalog.Domain.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

internal sealed class MongoCollectionFactory : IMongoCollectionFactory
{
    private readonly IMongoDatabase _mongoDatabase;

    public MongoCollectionFactory(IMongoDbSettings mongoDbSettings)
    {
        var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
        _mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.DatabaseName);
    }

    public IMongoCollection<T> GetCollection<T>()
    {
        return _mongoDatabase.GetCollection<T>(typeof(T).Name);
    }
}
