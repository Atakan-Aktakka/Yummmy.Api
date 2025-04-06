using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.ContactDto;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            var values = _context.Contacts;
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDto contact)  
        {
            Contact newContact = new Contact()
            {
                MappLocation = contact.MappLocation,
                Address = contact.Address,
                Phone = contact.Phone,
                Email = contact.Email,
                OpemingHours = contact.OpemingHours
            };
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
            return Ok(newContact.ContactId);
        }
        [HttpDelete]
        public IActionResult DeleteContact(int contactId)
        {
            var contact = _context.Contacts.Find(contactId);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok(contact.ContactId);
        }
        [HttpPut]
        public IActionResult UpdateContact( UpdateContactDto contact)
        {
            var updatedContact = _context.Contacts.Find(contact.ContactId);
            updatedContact.MappLocation = contact.MappLocation;
            updatedContact.Address = contact.Address;
            updatedContact.Phone = contact.Phone;
            updatedContact.Email = contact.Email;
            updatedContact.OpemingHours = contact.OpemingHours;
            _context.SaveChanges();
            return Ok(updatedContact.ContactId);
        }
        [HttpGet("id")]
        public IActionResult GetContactById(int id)
        {
            var contact = _context.Contacts.Find(id);
            return Ok(contact);
        }
    }
}