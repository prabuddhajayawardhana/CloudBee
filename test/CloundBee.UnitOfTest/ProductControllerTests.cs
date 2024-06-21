using Catalog.Api.Controllers;
using Catalog.Application.Services;
using Catalog.Domain.Entities;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CloundBee.UnitOfTest.Model;
using Catalog.Domain.DTO;

namespace CloundBee.UnitOfTest
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly CatalogController _controller;

        public ProductControllerTests()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new CatalogController(_mockProductService.Object);
        }

        [Fact]
        public async Task GetProduct_ReturnsOkResult_WithProductData()
        {
            // Arrange
            var productData = new List<Product>
            {
                new Product { Id = "1", Name = "Product1", Description = "Description1", Category = "Category1", Image = "Image1", Price = 99.99M }
            };
            _mockProductService.Setup(service => service.GetAllProductsAsync()).ReturnsAsync(productData);

            // Act
            var result = await _controller.GetProduct();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnData = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(productData.Count, returnData.Count);
        }

        [Fact]
        public async Task CreateProduct_ReturnsOkResult_WhenProductDataIsValid()
        {
            // Arrange
            var productData = new List<ProductDto>
            {
                new ProductDto
                {
                    Name = "2023 Original Apple iPhone 15 Pro",
                    Description = "Storage : 256GB 8GB RAM, 512GB 8GB RAM, 1TB 8GB RAM ;\r\n\r\nColor : Black Titanium, White Titanium, Blue Titanium, Natural Titanium ;\r\n\r\nBattery : 3274 mAh, PD2.0, 15W wireless ;\r\n\r\nRear Camera : 48MP + 12MP + 12MP , Triple Cameras",
                    Category = "IPhone",
                    Image = "sample-image-url",
                    Price = 99.99M
                }
            };

            _mockProductService.Setup(service => service.CreateProductsAsync(It.IsAny<List<ProductDto>>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.CreateProduct(productData);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnData = okResult.Value?.GetType()?.GetProperty("Result")?.GetValue(okResult.Value, null);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("Success", returnData);
        }

        [Fact]
        public async Task CreateProduct_ReturnsBadRequest_WhenExceptionIsThrown()
        {
            // Arrange
            var productData = new List<ProductDto>
            {
                new ProductDto { Name = "Invalid Product", Description = "Invalid Description", Category = "Invalid Category", Image = "Invalid Image", Price = 0.0M }
            };

            _mockProductService.Setup(service => service.CreateProductsAsync(It.IsAny<List<ProductDto>>())).ThrowsAsync(new System.Exception("An error occurred"));

            // Act
            var result = await _controller.CreateProduct(productData);

            // Assert
            var badRequestResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
            Assert.Equal("An error occurred", badRequestResult.Value);
        }
    }
}
