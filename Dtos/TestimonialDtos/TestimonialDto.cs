using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummmy.Api.Dtos.TestimonialDtos
{
    public class TestimonialDto
    {
        public int TestimonialId { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? Comment { get; set; }
    }
}