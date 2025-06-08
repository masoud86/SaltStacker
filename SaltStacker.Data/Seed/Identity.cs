using Microsoft.AspNetCore.Identity;
using SaltStacker.Domain.Models.Membership;

namespace SaltStacker.Data.Seed;

#region Models
public class RoleSeed
{
    public required string Id { get; set; }
    
    public required string Name { get; set; }

    public bool IsSystem { get; set; }
}

public class UserSeed
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
    public required string RoleId { get; set; }
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
                //PasswordHash = hasher.HashPassword(null, user.Password),
                ConcurrencyStamp = "4c159afc-539f-4d73-b997-d23eea86b75c",
                PasswordHash = "AQAAAAIAAYagAAAAEI0CynVzbtPbQD3eAMJft/5fjCYJbXaectUfMaDSh85aoH6XqLGQsyhEUMH6xP76Ng==",
                SecurityStamp = "081c6cd0-07fb-457f-9e8e-92cea0fd4cae",
                IsSystem = true
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
                IsSystem = role.IsSystem
            });

            if (role.Name == "Administrator")
            {
                roleClaims.AddRange(
                [
                    new IdentityRoleClaim<string> { Id = 1, RoleId = role.Id, ClaimType = "" }
                ]);
            }
        }

        _modelBuilder.Entity<AspNetUser>().HasData(usersList);
        _modelBuilder.Entity<AspNetRole>().HasData(rolesList);
        _modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoleList);
    }
}
