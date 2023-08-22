namespace Domain.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;


        public string? LastName { get; set; }


        public string PhoneNumber { get; set; } = null!;


        public List<Advertisement> BuyerAdvertisements { get; set; } = new();

        public List<Advertisement> SellerAdvertisements { get; set; } = new();

    }
}
