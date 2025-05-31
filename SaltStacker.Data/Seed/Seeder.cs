using Microsoft.EntityFrameworkCore;

namespace SaltStacker.Data.Seed
{
    public partial class Seeder
    {
        protected readonly ModelBuilder _modelBuilder;

        public Seeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public DateTime DateTimeNow => DateTime.UtcNow;

        public string DefaultAdminId => "011b406e-94e4-480f-b0e3-d7ac50db372c";

        public string AdminRoleId => "72c2c695-2efd-4fcf-b083-dcb1f47fa314";

        public string DefaultUserId => "db488502-19bb-4940-aae9-3686c07ef79f";

        public string UserRoleId => "634fce1a-f3e0-4512-86ab-628adb4999f1";
    }
}
