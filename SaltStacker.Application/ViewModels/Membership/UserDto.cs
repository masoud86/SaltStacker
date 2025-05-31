using Humanizer;
using SaltStacker.Application.ViewModels.Operation.Kitchen;
using SaltStacker.Common.Enums;
using SaltStacker.Common.Helper;
using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Membership;

public class UserDto
{
    public string Id { get; set; }

    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Display(Name = "Username", ResourceType = typeof(Resources.Security))]
    public string Username { get; set; }

    [Display(Name = "Role", ResourceType = typeof(Resources.Security))]
    public string Role { get; set; }

    [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Global))]
    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    [Display(Name = "Email", ResourceType = typeof(Resources.Global))]
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }

    public bool IsBlocked { get; set; }

    [Display(Name = "RegisterTime", ResourceType = typeof(Resources.Global))]
    public DateTime CreateDateTime { get; set; }
    public DateTime CreateDateTimeLocal => CreateDateTime.ConvertFromUtc();
    public string CreateDateTimeHumanized => DateTime.UtcNow.Add(-(DateTime.UtcNow - CreateDateTime)).Humanize();

    [Display(Name = "RegisterTime", ResourceType = typeof(Resources.Global))]
    public string CreateDate => CreateDateTime != DateTime.MinValue ? CreateDateTime.ToShortDateString() : "";

    public bool IsAdmin { get; set; }

    public RoleDto? RoleModel { get; set; }
}
