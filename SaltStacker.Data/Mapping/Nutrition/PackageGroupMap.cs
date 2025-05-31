using SaltStacker.Data.Helper;
using SaltStacker.Domain.Models.Nutrition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaltStacker.Data.Mapping.Nutrition;

public class PackageGroupMap : IEntityTypeConfiguration<PackageGroup>
{
    public void Configure(EntityTypeBuilder<PackageGroup> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(p => p.Title).HasMaxLength(200).IsRequired();
        builder.Property(p => p.CreateDateTime).HasColumnType("datetime")
            .HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd().IsRequired();

        builder.ToTable("PackageGroups", Scheme.Nutrition);
    }
}
