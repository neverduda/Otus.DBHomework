using Microsoft.Extensions.Hosting;
using Services.Contracts;
using Services.Interfaces;

namespace ConsoleApp1
{
    public class ConsoleApplicationHostedService : IHostedService
    {
        private IUserService userService;
        private IProductService productService;
        private IAdvertisementService advertisementService;


        public ConsoleApplicationHostedService(IUserService userService, IProductService productService, IAdvertisementService advertisementService)
        {
            this.userService = userService;
            this.productService = productService;
            this.advertisementService = advertisementService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введите 1, если хотите вывести содержимое всех таблиц, или 2, если хотите добавить Пользователя в таблицу Users, или 3, если хотите выйти из приложения.");

                var command = Console.ReadLine();
                if (command == "1")
                {
                    userService.ShowAllItems();
                    productService.ShowAllItems();
                    advertisementService.ShowAllItems();
                }
                else if (command == "2")
                {
                    try
                    {
                        Console.WriteLine("Введите FirstName:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Введите LastName:");
                        var lastName = Console.ReadLine();
                        Console.WriteLine("Введите PhoneNumber:");
                        var phoneNumber = Console.ReadLine();

                        var userDto = new UserDto
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumber = phoneNumber
                        };

                        userService.AddUser(userDto);
                        Console.WriteLine("User успешно добавлен.");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Вы ввели некорректные данные. Попробуйте ещё раз.");
                    }
                }
                else if (command == "3")
                {
                    Environment.Exit(-1);
                }
                else
                {
                    Console.WriteLine("Вы выбрали некорректную команду.");
                }
            }
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
