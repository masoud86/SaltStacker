using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Membership
{
    public class LoginAccountVerify
    {
        [Display(Name = "Code")]
        [Required(ErrorMessage = "{0} is mandatory")]
        public string TotpCode { get; set; }
    }
}
