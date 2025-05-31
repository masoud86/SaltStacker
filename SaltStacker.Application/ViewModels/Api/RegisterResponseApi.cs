using SaltStacker.Application.ViewModels.Customer;

namespace SaltStacker.Application.ViewModels.Api
{
    public class RegisterResponseApi : JwtToken
    {
        public bool Succeeded { get; set; }

        public string? ErrorMessage { get; set; }

        public CustomerInformation? CustomerInformation { get; set; }
    }
}
