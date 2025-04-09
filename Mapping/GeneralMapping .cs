using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Yummmy.Api.Dtos.CategoryDtos;
using Yummmy.Api.Dtos.FeatureDtos;
using Yummmy.Api.Dtos.MessageDtos;
using Yummmy.Api.Dtos.ProductDtos;
using Yummmy.Api.Dtos.RezervationDtos;
using Yummmy.Api.Dtos.ServiceDtos;
using Yummmy.Api.Dtos.TestimonialDtos;
using Yummmy.Api.Entities;

namespace Yummmy.Api.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Reservation, CreateRezervationDto>().ReverseMap();
            CreateMap<Reservation, UpdateRezervationDto>().ReverseMap();
            CreateMap<Reservation, RezervationDto>().ReverseMap();

            CreateMap<Service, CreateServiceDto>().ReverseMap();
            CreateMap<Service, UpdateServiceDto>().ReverseMap();
            CreateMap<Service, ServiceDto>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, TestimonialDto>().ReverseMap();
        }
    }

}