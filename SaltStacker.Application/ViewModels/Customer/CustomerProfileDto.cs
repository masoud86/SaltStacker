using SaltStacker.Application.ViewModels.Membership;

namespace SaltStacker.Application.ViewModels.Customer
{
    public class CustomerProfileDto
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }

    public class CustomerProfileApi
    {
        public string? Name { get; set; }

        public string? EmailAddress { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
