using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.MessageDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public MessagesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetMessages()
        {
             var messages = _context.Messages.ToList();
            return Ok(_mapper.Map<List<MessageDto>>(messages));
        }
        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var message = _context.Messages.Find(id);
            return Ok(_mapper.Map<List<MessageDto>>(message));
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto messageDto)
        {
            var message = _mapper.Map<Message>(messageDto);
            _context.Messages.Add(message);
            _context.SaveChanges();
            return Ok(message.MessageId);
        }
        [HttpPut]
        public IActionResult PutMessage(UpdateMessageDto message)
        {
            var updateMessage = _mapper.Map<Message>(message);
            _context.Messages.Update(updateMessage);
            _context.SaveChanges();
            return Ok(updateMessage.MessageId);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int messageId)
        {
            var message = _context.Messages.Find(messageId);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return Ok(message.MessageId);
        }
    }
}