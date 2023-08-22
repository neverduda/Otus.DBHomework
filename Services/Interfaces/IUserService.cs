using Services.Contracts;

namespace Services.Interfaces
{
    public interface IUserService : IService
    {
        void AddUser(UserDto user);
    }
}