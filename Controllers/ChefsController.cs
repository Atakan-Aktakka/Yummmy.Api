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
    public class ChefsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChefsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetChefs()
        {
            var chefs = _context.Chefs.ToList();
            return Ok(chefs);
        }
        [HttpGet("id")]
        public IActionResult GetChefById(int id)
        {
            var chef = _context.Chefs.Find(id);
            return Ok(chef);
        }
        [HttpPost]
        public IActionResult CreateChef([FromBody] Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok(chef.ChefId);
        }
        [HttpPut]
        public IActionResult ChefUpdate(int chefId, Chef chef)
        {
            var chef1 = _context.Chefs.Find(chefId);
            chef1.Name = chef.Name;
            _context.SaveChanges();
            return Ok(chef1);
        }
        [HttpDelete]
        public IActionResult DeleteChef(int chefId)
        {
            var chef = _context.Chefs.Find(chefId);
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok(chef.ChefId);
        }
    }
}