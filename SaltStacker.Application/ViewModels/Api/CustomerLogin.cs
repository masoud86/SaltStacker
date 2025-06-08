using SaltStacker.Application.ViewModels.Account;
using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Api;
public class AccountLogin
{
    [DataType(DataType.Text)]
    [Display(Name = "Username", ResourceType = typeof(Resources.Security))]
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
    public string Username { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password", ResourceType = typeof(Resources.Security))]
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
    public string Password { get; set; }
}

public class LoginResult : JwtToken
{
    public AccountInformation? AccountInformation { get; set; }
}