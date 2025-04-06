using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yummmy.Api.Context;
using Yummmy.Api.Dtos.FeatureDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public FeaturesController(IMapper mapper, AppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetFeatures()
        {
            var features = _context.Features.ToList();
            return Ok(_mapper.Map<List<FeatureDto>>(features));
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto featureDto)
        {
            var feature = _mapper.Map<Feature>(featureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok(feature.FeatureId);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int featureId)
        {
            var feature = _context.Features.Find(featureId);
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok(feature.FeatureId);
        }
        [HttpPut]
        public IActionResult PutFeature(UpdateFeatureDto feature)
        {
            var updateFeature = _mapper.Map<Feature>(feature);
            _context.Features.Update(updateFeature);
            _context.SaveChanges();
            return Ok(updateFeature.FeatureId);
        }
        [HttpGet("{id}")]
        public IActionResult GetFeatureById(int id)
        {
            var feature = _context.Features.Find(id);
            return Ok(_mapper.Map<List<FeatureDto>>(feature));
        }
    }
}