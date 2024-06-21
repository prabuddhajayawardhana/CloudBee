using Catalog.Domain.Configurations;
using Catalog.Domain.Interfaces;
using Catalog.Infrastructure.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Catalog.Infrastructure.Repositories;
internal class Repository<T> : IRepository<T> where T : class
{
    private readonly IMongoCollection<T> _mongoCollection;

    public Repository(IMongoCollectionFactory collectionFactory)
    {
        _mongoCollection = collectionFactory.GetCollection<T>();
    }

    public async Task<List<T>> GetAsync() =>
            await _mongoCollection.Find(_ => true).ToListAsync();

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate) =>
        await _mongoCollection.Find(predicate).FirstOrDefaultAsync();

    public async Task CreateAsync(T newEntity) =>
        await _mongoCollection.InsertOneAsync(newEntity);
    public async Task CreateAsync(List<T> newEntity) =>
        await _mongoCollection.InsertManyAsync(newEntity);

    public async Task UpdateAsync(Expression<Func<T, bool>> predicate, T updatedEntity)
    {
        var result = await _mongoCollection.ReplaceOneAsync(predicate, updatedEntity);
        if (result.MatchedCount == 0)
        {
            throw new KeyNotFoundException("Entity not found");
        }
    }

    public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
    {
        var result = await _mongoCollection.DeleteOneAsync(predicate);
        if (result.DeletedCount == 0)
        {
            throw new KeyNotFoundException("Entity not found");
        }
    }
}