using SaltStacker.Application.ViewModels.Nutrition;

namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class RecipeCookingDayDto
{
    public int Id { get; set; }

    public int RecipeId { get; set; }

    public int KitchenCookingDayId { get; set; }

    public RecipeDto? Recipe { get; set; }

    public KitchenCookingDayDto? KitchenCookingDay { get; set; }

    public DateTime CreateDateTime { get; set; }
}
