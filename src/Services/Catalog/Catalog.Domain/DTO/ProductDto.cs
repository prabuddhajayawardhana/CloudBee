﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.DTO
{
    public record ProductDto
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
    }
}
