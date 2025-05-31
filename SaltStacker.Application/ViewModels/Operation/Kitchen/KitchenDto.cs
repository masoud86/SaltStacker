using Humanizer;
using SaltStacker.Application.ViewModels.Settings;
using SaltStacker.Common.Enums;
using SaltStacker.Common.Helper;
using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class KitchenDto
{
    public int Id { get; set; }

    [DataType(DataType.Text)]
    [Display(Name = "Title", ResourceType = typeof(Resources.Global))]
    [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Resources.Error))]
    [StringLength(200, ErrorMessageResourceName = "StringLengthMax", ErrorMessageResourceType = typeof(Resources.Error))]
    [RegularExpression(PatternHelper.DangerousCharacters, ErrorMessageResourceName = "RegularExpression", ErrorMessageResourceType = typeof(Resources.Error))]
    public string Title { get; set; }

    public string? Subtitle { get; set; }

    public PartnerStatus Status { get; set; }

    public string? StatusColor
    {
        get
        {
            return (Status) switch
            {
                PartnerStatus.Active => "success",
                PartnerStatus.Inactive => "danger",
                PartnerStatus.ComingSoon => "warning",
                _ => "danger"
            };
        }
    }

    public int ZoneId { get; set; }
    public ZoneDto? Zone { get; set; }

    public string? Logo { get; set; }

    public string? Location { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public string? PostalCode { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime OrderWeekStartDate { get; set; }

    public DateTime NextOrderWeekChangeTime { get; set; }

    public string OrderingWeek => $"{OrderWeekStartDate:MMM, dd} - {OrderWeekStartDate.AddDays(6):MMM, dd}";

    public string NextWeekStart => NextOrderWeekChangeTime.ToString("MMM, dd - HH:mm");

    public int? RecipeTaxProfileId { get; set; }

    public DateTime CreateDateTime { get; set; }
    public string CreateDateTimeLocal => CreateDateTime.ConvertFromUtcString();
    public string CreateDateTimeHumanized => DateTime.UtcNow.Add(-(DateTime.UtcNow - CreateDateTime)).Humanize();
}
