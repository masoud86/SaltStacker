using SaltStacker.Domain.Models.Setting;

namespace SaltStacker.Data.Seed
{
    public partial class Seeder
    {
        public void ApplicationSetting()
        {
            _modelBuilder.Entity<ApplicationSetting>().HasData(
                new ApplicationSetting
                {
                    Key = "RoleValidationKey",
                    Value = "6804a190-255a-4ea1-9960-374de2334d9e"
                },
                new ApplicationSetting
                {
                    Key = "DefaultTimeZone",
                    Value = "Iran Standard Time"
                }
            );

            _modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Title = "Canada",
                    IsActive = true
                }
            );

            _modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    Id = 1,
                    Title = "BC - British Columbia",
                    IsActive = true,
                    CountryId = 1
                }
            );

            _modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Title = "Greater Vancouver",
                    IsActive = true,
                    ProvinceId = 1
                }
            );

            _modelBuilder.Entity<Zone>().HasData(
                new Zone
                {
                    Id = 1,
                    Title = "All",
                    IsActive = true,
                    CityId = 1,
                }
            );
        }
    }
}
