using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Membership
{
    public class EditRole : CreateRole
    {
        [Display(Name = "Id", ResourceType = typeof(Resources.Global))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
        public string Id { get; set; }
    }
}
