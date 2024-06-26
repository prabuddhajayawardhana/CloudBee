﻿using Catalog.Domain.DTO;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task CreateProductsAsync(List<ProductDto> products);
    }
}
