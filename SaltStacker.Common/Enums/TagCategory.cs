using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum TagCategory
    {
        [Display(Name = "Nutrition")]
        Nutrition = 1,

        [Display(Name = "Marketing")]
        Marketing = 2,

        [Display(Name = "Meal Type")]
        MealType = 3
    }
}
