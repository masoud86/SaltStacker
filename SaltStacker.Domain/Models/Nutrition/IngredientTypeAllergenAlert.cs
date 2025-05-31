using SaltStacker.Common.Enums;

namespace SaltStacker.Domain.Models.Nutrition;

public class IngredientTypeAllergenAlert
{
    public int Id { get; set; }

    public int IngredientTypeId { get; set; }

    public virtual IngredientType? IngredientType { get; set; }

    public AllergenAlert AllergenAlert { get; set; }
}
