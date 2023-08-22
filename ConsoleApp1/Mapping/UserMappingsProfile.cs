using AutoMapper;
using ConsoleApp1.Models;
using Services.Contracts;

namespace ConsoleApp1.Mapping
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<UserDto, UserModel>();
        }
    }
}
