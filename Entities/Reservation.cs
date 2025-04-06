using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummmy.Api.Entities
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int CountPeople { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? ReservationTime { get; set; }
        public string? Message { get; set; }
        public string? Status { get; set; }
    }
}