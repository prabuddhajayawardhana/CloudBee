using Catalog.Application.Services;
using Catalog.Domain.DTO;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Net.Mime;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController(IProductService _productService) : ControllerBase
    {
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProduct()
        {
            var data = await _productService.GetAllProductsAsync();

            return Ok(data);
        }

        [HttpGet]
        [Route("GetProductString")]
        public IActionResult GetProductString()
        {
            return Ok("Hello");
        }

        [HttpPost]
        [Route("CreateProduct")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(List<ProductDto> productData)
        {
            try
            {
                await _productService.CreateProductsAsync(productData);
                return Ok(new { Result = "Success" });
            }
            catch (Exception ex)
            {
                return StatusCode(400,ex.Message);
            }
        }
    }
}
