using SaltStacker.Common.Enums;
using SaltStacker.Domain.Models.Setting;

namespace SaltStacker.Domain.Models.Operation;

public class Kitchen
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string? Subtitle { get; set; }

    public int ZoneId { get; set; }
    public virtual Zone? Zone { get; set; }

    public string? Location { get; set; }

    public double? Longitude { get; set; }

    public double? Latitude { get; set; }

    public string? PostalCode { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTime CreateDateTime { get; set; }
}
