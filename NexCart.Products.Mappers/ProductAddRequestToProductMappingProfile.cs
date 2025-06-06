﻿using AutoMapper;
using NexCart.Products.DTO;
using NexCart.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexCart.Products.Mappers
{
    public class ProductAddRequestToProductMappingProfile : Profile
    {
        public ProductAddRequestToProductMappingProfile()
        {
            CreateMap<ProductAddRequest, Product>().ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
                .ForMember(dest => dest.ProductID, opt => opt.Ignore());
        }
    }
}
