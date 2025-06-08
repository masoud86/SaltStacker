using System.Security.Claims;

namespace SaltStacker.Common.Helper
{
    public static class CurrentUser
    {
        private static IEnumerable<Claim> CurrentUserClaim(ClaimsPrincipal user)
        {
            return ((ClaimsIdentity) user?.Identity)?.Claims;
        }

        private static string GetValue(ClaimsPrincipal user, string type)
        {
            var claims = CurrentUserClaim(user);
            return claims?.FirstOrDefault(m => m.Type == type)?.Value;
        }

        public static string Id(this ClaimsPrincipal user)
        {
            return GetValue(user, ClaimTypes.NameIdentifier);
        }

        public static string Mobile(this ClaimsPrincipal user)
        {
            return GetValue(user, ClaimTypes.MobilePhone);
        }

        public static string Username(this ClaimsPrincipal user)
        {
            return GetValue(user, ClaimTypes.Name);
        }

        public static string Role(this ClaimsPrincipal user)
        {
            return GetValue(user, ClaimTypes.Role);
        }
        
        public static string RoleDisplayName(this ClaimsPrincipal user)
        {
            return GetValue(user, "RoleDisplayName");
        }

        public static string Name(this ClaimsPrincipal user)
        {
            return GetValue(user, ClaimTypes.Name);
        }

        public static bool HasPermission(this ClaimsPrincipal user, string permission)
        {
            return user.Role().ToLower() == "administrator" || user.HasClaim(permission.ToUpper(), true.ToString());
        }
    }
}
