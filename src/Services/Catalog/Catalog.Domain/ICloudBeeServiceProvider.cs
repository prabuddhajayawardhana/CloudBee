using Catalog.Domain.Interfaces;

namespace Catalog.Domain;

public interface ICloudBeeServiceProvider
{
    IProductRepository Products { get; }
}
