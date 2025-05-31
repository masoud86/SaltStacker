using SaltStacker.Application.ViewModels.Account;

namespace SaltStacker.Application.ViewModels.Api
{
    public class RegisterResponseApi : JwtToken
    {
        public bool Succeeded { get; set; }

        public string? ErrorMessage { get; set; }

        public AccountInformation? AccountInformation { get; set; }
    }
}
