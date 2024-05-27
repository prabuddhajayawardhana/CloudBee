using Catalog.Domain;
using Catalog.Domain.Entities;
using MongoDB.Bson;

namespace Catalog.Application.Services;

internal sealed class ProductService(ICloudBeeServiceProvider beeServiceProvider) : IProductService
{
    private readonly ICloudBeeServiceProvider _beeServiceProvider = beeServiceProvider;

    public async Task CreateProductsAsync()
    {
        var productData = new Product
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = "Sample Product",
            Description = "This is a sample product description.",
            Category = "Sample Category",
            Image = "sample-image-url",
            Price = 99.99M
        };

        await _beeServiceProvider.Products.CreateAsync(productData);
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _beeServiceProvider.Products.GetAsync();
    }
}
