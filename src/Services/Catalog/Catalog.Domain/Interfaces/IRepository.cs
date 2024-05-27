using System.Linq.Expressions;

namespace Catalog.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAsync();
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task CreateAsync(T newProduct);
    Task UpdateAsync(Expression<Func<T, bool>> predicate, T updatedProduct);
    Task RemoveAsync(Expression<Func<T, bool>> predicate);
}
