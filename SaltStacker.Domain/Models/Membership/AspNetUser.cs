using Microsoft.AspNetCore.Identity;

namespace SaltStacker.Domain.Models.Membership
{
    public class AspNetUser : IdentityUser
    {
        public string? Name { get; set; }

        public bool IsBlocked { get; set; }

        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        public DateTime CreateDateTime { get; set; }

        public bool IsSystem { get; set; }
    }
}
