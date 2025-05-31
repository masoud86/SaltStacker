using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum RecipeType
    {
        [Display(Name = "Personal Chef")]
        PersonalChef = 1,

        [Display(Name = "MealPrep")]
        MealPrep = 2
    }
}
