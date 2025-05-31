using SaltStacker.Application.ViewModels.Nutrition;

namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class KitchenRecipeDto
{
    public int Id { get; set; }

    public int KitchenId { get; set; }

    public int RecipeId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public KitchenDto? Kitchen { get; set; }

    public RecipeDto? Recipe { get; set; }
}
