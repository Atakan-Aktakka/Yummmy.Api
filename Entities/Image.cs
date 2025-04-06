using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummmy.Api.Entities
{
    public class Image
    {
        public int ImageId { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
    }
}