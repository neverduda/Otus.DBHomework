namespace Domain.Entities
{
    public class Advertisement : IEntity<int>
    {
        public int Id { get; set; }


        public int SellerId { get; set; }

        public User? Seller { get; set; }


        public int? BuyerId { get; set; }

        public User? Buyer { get; set; }

        public int ProductId { get; set; }

        public Product? Product { get; set; }


        public DateTime? PublicationDate { get; set; }

        public int Status { get; set; }
    }
}
