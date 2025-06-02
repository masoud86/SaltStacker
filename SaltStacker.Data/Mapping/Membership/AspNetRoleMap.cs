using SaltStacker.Domain.Models.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaltStacker.Data.Mapping.Membership
{
    public class AspNetRoleMap : IEntityTypeConfiguration<AspNetRole>
    {
        public void Configure(EntityTypeBuilder<AspNetRole> builder)
        {
            builder.Property(p => p.IsSystem).IsRequired();
            builder.Property(p => p.CreateDateTime)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}
