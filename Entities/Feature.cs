using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yummmy.Api.Entities
{
    public class Feature
    {
        public int FeatureId { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public string? Description { get; set; }
        public string? VideoUrl { get; set; }
        public string? ImageUrl { get; set; }
    }
}