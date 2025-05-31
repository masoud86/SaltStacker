using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Common.Enums
{
    public enum MediaType
    {
        [Display(Name = "Image")]
        Image = 1,

        [Display(Name = "Document")]
        Document = 2
    }
}
