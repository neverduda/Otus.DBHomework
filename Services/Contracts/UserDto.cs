namespace Services.Contracts
{
    public class UserDto
    {
        public int? Id { get; set; }

        public string FirstName { get; set; } = null!;


        public string? LastName { get; set; }


        public string PhoneNumber { get; set; } = null!;

    }
}
