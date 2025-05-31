using SaltStacker.Data.Helper;
using SaltStacker.Domain.Models.Operation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SaltStacker.Data.Mapping.Operation
{
    public class KitchenRecipeMap : IEntityTypeConfiguration<KitchenRecipe>
    {
        public void Configure(EntityTypeBuilder<KitchenRecipe> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.KitchenId).IsRequired();
            builder.Property(p => p.RecipeId).IsRequired();
            builder.Property(p => p.CreateDateTime).HasColumnType("datetime")
                .HasDefaultValueSql("GETUTCDATE()").ValueGeneratedOnAdd().IsRequired();

            builder.ToTable("KitchenRecipes", Scheme.Operation);
        }
    }
}
