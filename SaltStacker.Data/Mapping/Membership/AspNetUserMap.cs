using SaltStacker.Domain.Models.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaltStacker.Data.Mapping.Membership;

public class AspNetUserMap : IEntityTypeConfiguration<AspNetUser>
{
    public void Configure(EntityTypeBuilder<AspNetUser> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired(false);
        builder.Property(p => p.RefreshToken).HasMaxLength(int.MaxValue).IsRequired(false);
        builder.Property(p => p.RefreshTokenExpiryTime).IsRequired(false);
        builder.Property(p => p.IsBlocked).IsRequired();
        builder.Property(p => p.IsSystem).IsRequired().HasDefaultValue(false);
        builder.Property(p => p.CreateDateTime)
            .HasColumnType("datetime")
            .HasDefaultValueSql("GETUTCDATE()")
            .ValueGeneratedOnAdd()
            .IsRequired();
    }
}
