using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Membership
{
    public class Login
    {
        [DataType(DataType.Text)]
        [Display(Name = "Username", ResourceType = typeof(Resources.Security))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Security))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Security))]
        public bool RememberMe { get; set; }
    }
}
