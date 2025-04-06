using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category.CategoryId);
        }
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok( category.CategoryId);
        }
        [HttpGet("id")]
        public IActionResult GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            return Ok(category);
        }
        [HttpPut]
        public IActionResult CategoryUpdate(int categoryId, Category category)
        {
            var cat = _context.Categories.Find(categoryId);
            cat.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return Ok(cat);
        }
    }
}