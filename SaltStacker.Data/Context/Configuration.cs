using Microsoft.EntityFrameworkCore;
using SaltStacker.Data.Seed;

namespace SaltStacker.Data.Context;

public static class Configuration
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var seeder = new Seeder(modelBuilder);

        seeder.Identity(
            new List<UserSeed>
            {
                new UserSeed
                {
                    Id = seeder.DefaultAdminId,
                    Name = "Masoud Abedi",
                    Email = "admin@saltstacker.com",
                    EmailConfirmed = true,
                    Password = "hUsdI23&$",
                    RoleId = seeder.AdminRoleId
                }
            },
            new List<RoleSeed>
            {
                new RoleSeed
                {
                    Id = seeder.AdminRoleId,
                    Name = "Administrator",
                    DisplayName = "Administrator",
                    Description = "",
                    IsLocked = true
                },
                new RoleSeed
                {
                    Id = seeder.UserRoleId,
                    Name = "Account",
                    DisplayName = "Account",
                    Description = "",
                    IsLocked = true
                }
            }
        );

        seeder.ApplicationSetting();

        seeder.Nutrition();
    }
}
