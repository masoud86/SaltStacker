using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum LogicalOperator
    {
        [Display(Name = "And")]
        And = 1,

        [Display(Name = "Or")]
        Or = 2
    }
}
