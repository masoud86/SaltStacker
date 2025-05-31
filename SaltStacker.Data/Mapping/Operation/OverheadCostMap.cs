using SaltStacker.Data.Helper;
using SaltStacker.Domain.Models.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaltStacker.Data.Mapping.Operation
{
    public class OverheadCostMap : IEntityTypeConfiguration<OverheadCost>
    {
        public void Configure(EntityTypeBuilder<OverheadCost> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.DefaultValue).IsRequired(false).HasColumnType("decimal(18,2)");

            builder.ToTable("OverheadCosts", Scheme.Operation);
        }
    }
}
