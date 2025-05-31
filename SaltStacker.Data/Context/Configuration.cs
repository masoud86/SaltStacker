using SaltStacker.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace SaltStacker.Data.Context
{
    public static class Configuration
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //var seeder = new Seeder(modelBuilder);

            //seeder.Identity(
            //    new List<UserSeed>
            //    {
            //        new UserSeed
            //        {
            //            Id = seeder.DefaultAdminId,
            //            Name = "Masoud Abedi",
            //            PhoneNumber = "+13527115723",
            //            PhoneNumberConfirmed = true,
            //            Email = "admin@saltstacker.com",
            //            EmailConfirmed = true,
            //            Password = "hUsdI23&$",
            //            RoleId = seeder.AdminRoleId
            //        }
            //    },
            //    new List<RoleSeed>
            //    {
            //        new RoleSeed
            //        {
            //            Id = seeder.AdminRoleId,
            //            Name = "Administrator",
            //            DisplayName = "Administrator",
            //            Description = "",
            //            IsLocked = true
            //        },
            //        new RoleSeed
            //        {
            //            Id = seeder.UserRoleId,
            //            Name = "Customer",
            //            DisplayName = "Customer",
            //            Description = "",
            //            IsLocked = true
            //        },
            //        new RoleSeed
            //        {
            //            Id = seeder.PartnerRoleId,
            //            Name = "Partner",
            //            DisplayName = "Partner",
            //            Description = "",
            //            IsLocked = true
            //        },
            //        new RoleSeed
            //        {
            //            Id = seeder.PersonalChefRoleId,
            //            Name = "PersonalChef",
            //            DisplayName = "Personal Chef",
            //            Description = "",
            //            IsLocked = true
            //        }
            //    }
            //);

            //seeder.ApplicationSetting();

            //seeder.Nutrition();
        }
    }
}
