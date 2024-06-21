using Catalog.Domain;
using Catalog.Domain.DTO;
using Catalog.Domain.Entities;
using MongoDB.Bson;

namespace Catalog.Application.Services;

internal sealed class ProductService(ICloudBeeServiceProvider beeServiceProvider) : IProductService
{
    private readonly ICloudBeeServiceProvider _beeServiceProvider = beeServiceProvider;

    public async Task CreateProductsAsync(List<ProductDto> products)
    {
        if (products is not null)
        {
            var productList = products.Select(c => new Product
            {
                Name = c.Name,
                Category = c.Category,
                Description = c.Description,
                Image = c.Image,
                Price = c.Price,
            }).ToList();

            await _beeServiceProvider.Products.CreateAsync(productList);
        }
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        return await _beeServiceProvider.Products.GetAsync();
    }
}
