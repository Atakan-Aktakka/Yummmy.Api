using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.ServiceDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ServicesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetServices()
        {
            var Services = _context.Services.ToList();
            return Ok(_mapper.Map<List<ServiceDto>>(Services));
        }
        [HttpGet("{id}")]
        public IActionResult GetServiceById(int id)
        {
            var Service = _context.Services.Find(id);
            return Ok(_mapper.Map<List<ServiceDto>>(Service));
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDto ServiceDto)
        {
            var Service = _mapper.Map<Service>(ServiceDto);
            _context.Services.Add(Service);
            _context.SaveChanges();
            return Ok(Service.ServiceId);
        }
        [HttpPut]
        public IActionResult PutService(UpdateServiceDto Service)
        {
            var updateService = _mapper.Map<Service>(Service);
            _context.Services.Update(updateService);
            _context.SaveChanges();
            return Ok(updateService.ServiceId);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteService(int ServiceId)
        {
            var Service = _context.Services.Find(ServiceId);
            _context.Services.Remove(Service);
            _context.SaveChanges();
            return Ok(Service.ServiceId);
        }
    }
}