using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.RezervationDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezervationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public RezervationsController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetRezervation()
        {
            var rezervation = _context.Reservations.ToList();
            return Ok(_mapper.Map<List<RezervationDto>>(rezervation));
        }
        [HttpGet("{id}")]
        public IActionResult GetRezervationById(int id)
        {
            var rezervation = _context.Reservations.Find(id);
            return Ok(_mapper.Map<List<RezervationDto>>(rezervation));
        }
        [HttpPost]
        public IActionResult CreateRezervation(CreateRezervationDto rezervationDto)
        {
            var rezervation = _mapper.Map<Reservation>(rezervationDto);
            _context.Reservations.Add(rezervation);
            _context.SaveChanges();
            return Ok(rezervation.ReservationId);
        }
        [HttpPut]
        public IActionResult PutRezervation(UpdateRezervationDto rezervation)
        {
            var updateRezervation = _mapper.Map<Reservation>(rezervation);
            _context.Reservations.Update(updateRezervation);
            _context.SaveChanges();
            return Ok(updateRezervation.ReservationId);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRezervation(int rezervationId)
        {
            var rezervation = _context.Reservations.Find(rezervationId);
            _context.Reservations.Remove(rezervation);
            _context.SaveChanges();
            return Ok(rezervation.ReservationId);
        }
    }
}