using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Common.Helper;
using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Customer
{
    public class Customers : Pagination
    {
        public Customers() : base("Name")
        {
            Columns = new Dictionary<string, string> {
                {"Name", "Name"}
            };
        }

        public List<CustomerDto> Items { get; set; }
    }

    public class CustomerFilters : Pagination
    {
        public CustomerFilters() : base("Name")
        {
        }
    }

    public class CustomerDto
    {
        public string Id { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
        [StringLength(100, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(Resources.Error))]
        [RegularExpression(PatternHelper.DangerousCharacters, ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
        public string Name { get; set; }


        [Phone(ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
        [Display(Name = "Mobile", ResourceType = typeof(Resources.Global))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
        [RegularExpression(PatternHelper.PhoneNumberPattern, ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }


        [EmailAddress(ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
        [Display(Name = "Email", ResourceType = typeof(Resources.Global))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool IsBlocked { get; set; }

        [Display(Name = "RegisterTime", ResourceType = typeof(Resources.Global))]
        public DateTime CreateDateTime { get; set; }
        public DateTime CreateDateTimeLocal => CreateDateTime.ConvertFromUtc();
    }
}
