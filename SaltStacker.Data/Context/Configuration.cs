using Microsoft.EntityFrameworkCore;
using SaltStacker.Data.Seed;

namespace SaltStacker.Data.Context;

public static class Configuration
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var seeder = new Seeder(modelBuilder);

        seeder.Identity(
            [
                new UserSeed
                {
                    Id = seeder.DefaultAdminId,
                    Name = "Admin",
                    Password = "Admin@123",
                    RoleId = seeder.AdminRoleId
                }
            ],
            [
                new RoleSeed
                {
                    Id = seeder.AdminRoleId,
                    Name = "Administrator",
                    IsSystem = true
                },
                new RoleSeed
                {
                    Id = seeder.UserRoleId,
                    Name = "User",
                    IsSystem = true
                }
            ]
        );

        seeder.ApplicationSetting();

        seeder.Nutrition();
    }
}
