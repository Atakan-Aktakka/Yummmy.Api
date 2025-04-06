using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Yummmy.Api.Dtos.FeatureDtos;
using Yummmy.Api.Dtos.MessageDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Mapping
{
    public class GeberalMapping:Profile
    {
        public GeberalMapping()
        {
            CreateMap<Feature, CreateFeatureDto>();
            CreateMap<Feature, UpdateFeatureDto>();

            CreateMap<Message, CreateMessageDto>();
            CreateMap<Message, UpdateMessageDto>();
        }
    }

}