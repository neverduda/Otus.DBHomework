using AutoMapper;
using Domain.Entities;
using Services.Contracts;
using Services.Interfaces;
using Services.Repositories.Interfases;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public void ShowAllItems()
        {
            var users = userRepository.GetAllItems();

            var userDtos = mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);           

            Console.WriteLine();
            Console.WriteLine($"Таблица Users:");
            foreach (var item in userDtos)
            {
                Console.WriteLine($"{item.Id} | {item.FirstName} | {item.LastName} | {item.PhoneNumber}");
            }
            Console.WriteLine();
        }
        public void AddUser(UserDto userDto)
        {
            var user = mapper.Map<UserDto, User>(userDto);
            userRepository.AddUser(user);
        }
    }
}