using SaltStacker.Common.Helper;

namespace SaltStacker.Application.ViewModels.Membership
{
    public class RoleDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public bool IsSystem { get; set; }

        public DateTime CreateDateTime { get; set; }
        public string CreateDateTimeLocal => CreateDateTime.ConvertFromUtcString();
    }
}
