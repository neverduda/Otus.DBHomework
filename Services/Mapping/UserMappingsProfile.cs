using AutoMapper;
using Domain.Entities;
using Services.Contracts;

namespace Services.Mapping
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.BuyerAdvertisements, map => map.Ignore())
                .ForMember(d => d.SellerAdvertisements, map => map.Ignore());
        }
    }
}
