using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yummmy.Api.Dtos.CategoryDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Dtos.ProductDtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public CategoryDto? category { get; set; }
    }
}