using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum RecipeSize
    {
        [Display(Name = "Default")]
        Default = 1,

        [Display(Name = "Family")]
        Family = 2
    }
}
