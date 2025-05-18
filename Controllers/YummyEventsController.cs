using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.YummyEventDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class YummyEventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public YummyEventsController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEvents()
        {
            var events = _context.YummyEvents.ToList();
            return Ok(_mapper.Map<List<YummyEventDto>>(events));
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(int id)
        {
            var eventItem = _context.YummyEvents.Find(id);
            return Ok(_mapper.Map<YummyEventDto>(eventItem));
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] CreateYummyEventDto eventDto)
        {
            var newEvent = _mapper.Map<YummyEvent>(eventDto);
            _context.YummyEvents.Add(newEvent);
            _context.SaveChanges();
            return Ok(newEvent.EventId);
        }

        [HttpPut]
        public IActionResult UpdateEvent([FromBody] UpdateYummyEventDto eventDto)
        {
            var existingEvent = _mapper.Map<YummyEvent>(eventDto);
            _context.YummyEvents.Update(existingEvent);
            _context.SaveChanges();
            return Ok(existingEvent.EventId);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int eventId)
        {
            var eventToDelete = _context.YummyEvents.Find(eventId);
            _context.YummyEvents.Remove(eventToDelete);
            _context.SaveChanges();
            return Ok(eventToDelete.EventId);
        }
    }
}
