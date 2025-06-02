using Microsoft.AspNetCore.Identity;

namespace SaltStacker.Domain.Models.Membership
{
    public class AspNetRole : IdentityRole
    {
        public bool IsSystem { get; set; }

        public DateTime CreateDateTime { get; set; }
    }
}
