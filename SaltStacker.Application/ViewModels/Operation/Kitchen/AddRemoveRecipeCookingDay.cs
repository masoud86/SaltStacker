namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class AddRemoveRecipeCookingDay
{
    public int RecipeId { get; set; }

    public int KitchenCookingDayId { get; set; }

    public bool IsRemove { get; set; }
}
