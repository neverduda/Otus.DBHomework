namespace Domain.Entities
{
    public class Product: IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int Price { get; set; }

        public string? Desription { get; set; }

        public List<Advertisement> Advertisements { get; set; } = new();

    }
}