using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummmy.Api.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
         public int ServiceId { get; set; }
        public string? Title { get; set; }
        public string? IconUrl { get; set; }
        public string? Description { get; set; }
    }
}