using SaltStacker.Domain.Models.Membership;
using Microsoft.AspNetCore.Identity;

namespace SaltStacker.Data.Seed
{
    #region Models
    public class RoleSeed
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool IsLocked { get; set; }
    }

    public class UserSeed
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }
    #endregion Models

    public partial class Seeder
    {
        public void Identity(List<UserSeed> users, List<RoleSeed> roles)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var usersList = new List<AspNetUser>();
            var rolesList = new List<AspNetRole>();
            var userRoleList = new List<IdentityUserRole<string>>();
            var roleClaims = new List<IdentityRoleClaim<string>>();

            foreach (var user in users)
            {
                usersList.Add(new AspNetUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    UserName = user.Email.Split('@')[0],
                    NormalizedUserName = user.Email.Split('@')[0].Trim().ToUpper(),
                    Email = user.Email,
                    NormalizedEmail = user.Email.Trim().ToUpper(),
                    EmailConfirmed = user.EmailConfirmed,
                    PhoneNumber = user.PhoneNumber,
                    PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    PasswordHash = hasher.HashPassword(null, user.Password),
                    IsAdmin = true
                });

                userRoleList.Add(new IdentityUserRole<string>
                {
                    RoleId = user.RoleId,
                    UserId = user.Id
                });
            }

            foreach (var role in roles)
            {
                rolesList.Add(new AspNetRole
                {
                    Id = role.Id,
                    Name = role.Name,
                    NormalizedName = role.Name.Trim().ToUpper(),
                    DisplayName = role.DisplayName,
                    Description = role.Description,
                    IsLocked = role.IsLocked
                });

                if (role.Name == "Administrator")
                {
                    roleClaims.AddRange(new List<IdentityRoleClaim<string>>
                    {
                        new IdentityRoleClaim<string> { Id = 1, RoleId = role.Id, ClaimType = "" }
                    });
                }
            }

            _modelBuilder.Entity<AspNetUser>().HasData(usersList);
            _modelBuilder.Entity<AspNetRole>().HasData(rolesList);
            _modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoleList);
        }
    }
}
