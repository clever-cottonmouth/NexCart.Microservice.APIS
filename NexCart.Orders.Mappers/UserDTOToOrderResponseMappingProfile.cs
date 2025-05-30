using AutoMapper;
using NexCart.Orders.DTO;

namespace NexCart.Orders.Mappers
{
    public class UserDTOToOrderResponseMappingProfile : Profile
    {
        public UserDTOToOrderResponseMappingProfile()
        {
            CreateMap<UserDTO, OrderResponse>()
              .ForMember(dest => dest.UserPersonName, opt => opt.MapFrom(src => src.PersonName))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
