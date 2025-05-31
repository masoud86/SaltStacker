using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum ActivityLevel
    {
        [Display(Name = "Low")]
        Low = 1,

        [Display(Name = "Medium")]
        Medium = 2,

        [Display(Name = "High")]
        High = 3
    }
}
