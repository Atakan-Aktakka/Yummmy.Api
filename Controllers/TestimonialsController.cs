using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.TestimonialDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public TestimonialsController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetTestimonials()
        {
            var Testimonials = _context.Testimonials.ToList();
            return Ok(_mapper.Map<List<TestimonialDto>>(Testimonials));
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var Testimonial = _context.Testimonials.Find(id);
            return Ok(_mapper.Map<List<TestimonialDto>>(Testimonial));
        }
        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto TestimonialDto)
        {
            var Testimonial = _mapper.Map<Testimonial>(TestimonialDto);
            _context.Testimonials.Add(Testimonial);
            _context.SaveChanges();
            return Ok(Testimonial.TestimonialId);
        }
        [HttpPut]
        public IActionResult PutTestimonial(UpdateTestimonialDto Testimonial)
        {
            var updateTestimonial = _mapper.Map<Testimonial>(Testimonial);
            _context.Testimonials.Update(updateTestimonial);
            _context.SaveChanges();
            return Ok(updateTestimonial.TestimonialId);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int TestimonialId)
        {
            var Testimonial = _context.Testimonials.Find(TestimonialId);
            _context.Testimonials.Remove(Testimonial);
            _context.SaveChanges();
            return Ok(Testimonial.TestimonialId);
        }
    }
}