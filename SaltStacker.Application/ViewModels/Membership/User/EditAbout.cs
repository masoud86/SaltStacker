using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Membership.User;

public class EditAbout
{
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
    public required string Id { get; set; }

    public string? About { get; set; }
}
