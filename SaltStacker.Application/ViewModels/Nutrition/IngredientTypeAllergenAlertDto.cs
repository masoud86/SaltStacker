using SaltStacker.Common.Enums;

namespace SaltStacker.Application.ViewModels.Nutrition;

public class IngredientTypeAllergenAlertDto
{
    public int Id { get; set; }

    public int IngredientTypeId { get; set; }

    public IngredientTypeDto? IngredientType { get; set; }

    public AllergenAlert AllergenAlert { get; set; }
}
