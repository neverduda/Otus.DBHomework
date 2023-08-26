using Domain.Entities;
using Services.Interfaces;
using Services.Repositories.Interfases;

namespace Services.Implementations
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public void ShowAllItems()
        {
            var products = productRepository.GetAllItems();
            Console.WriteLine();
            Console.WriteLine($"Таблица Product:");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Price} | {item.Desription}");
            }
            Console.WriteLine();
        }

    }
}