using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummmy.Api.Dtos.ContactDto
{
    public class CreateContactDto
    {
        public string? MappLocation { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? OpemingHours { get; set; }
    }
}