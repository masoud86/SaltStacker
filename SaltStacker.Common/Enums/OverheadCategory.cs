using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum OverheadCategory
    {
        [Display(Name = "All")]
        All = 0,

        [Display(Name = "Recipe")]
        Recipe = 1
    }
}
