using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.ProductDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;

        public ProductsController(AppDbContext context, IMapper mapper, IValidator<Product> validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.Include(x => x.Category).ToList();
            return Ok(_mapper.Map<List<ProductDto>>(products));
        }
        [HttpPost]
        public IActionResult PostProducts(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok(product.ProductId);
            }

        }
        [HttpPut]
        public IActionResult PutProduct(UpdateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok(product.ProductId);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok(product.ProductId);
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return Ok(_mapper.Map<List<ProductDto>>(product));
        }
    }
}