using AutoMapper;
using NexCart.Products.DTO;
using NexCart.Products.Entities;


namespace NexCart.Products.Mappers
{
    public class ProductToProductResponseMappingProfile : Profile
    {
        public ProductToProductResponseMappingProfile()
        {
            CreateMap<Product, ProductResponse>().ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.QuantityInStock, opt => opt.MapFrom(src => src.QuantityInStock))
                .ForMember(dest => dest.ProductID, opt => opt.MapFrom(src => src.ProductID));
        }
    }
}
