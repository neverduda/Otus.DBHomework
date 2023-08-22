using Domain.Entities;
using Infrastructure.Repositories;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AdvertisementService : IAdvertisementService
    {
        private IRepository<Advertisement> advertisementRepository;
        public AdvertisementService(IRepository<Advertisement> advertisementRepository)
        {
            this.advertisementRepository = advertisementRepository;
        }

        public void ShowAllItems()
        {
            var advertisements = advertisementRepository.GetAllItems();

            Console.WriteLine();
            Console.WriteLine($"Таблица Advertisement:");
            Console.WriteLine($"Id | Buyer.FirstName | Buyer.LastName | Buyer.PhoneNumber " +
                   $"| Seller.FirstName | Seller.LastName | Seller.PhoneNumber" +
                   $"| Product.Name | Product.Price | Product.Desription" +
                   $"  | PublicationDate | Status");
            Console.WriteLine();
            foreach (var item in advertisements)
            {
                Console.WriteLine($"{item.Id} | {item.Buyer?.FirstName} | {item.Buyer?.LastName} | {item.Buyer?.PhoneNumber} " +
                    $"| {item.Seller?.FirstName} | {item.Seller?.LastName} | {item.Seller?.PhoneNumber}" +
                    $"| {item.Product?.Name} | {item.Product?.Price} | {item.Product?.Desription}" +
                    $"  |  {item.PublicationDate} | {item.Status}");
            }
            Console.WriteLine();
        }

    }
}