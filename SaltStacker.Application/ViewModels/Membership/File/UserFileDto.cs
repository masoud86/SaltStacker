using SaltStacker.Common.Helper;
using Humanizer;

namespace SaltStacker.Application.ViewModels.Membership.File;

public class UserFileDto
{
    public int Id { get; set; }

    public required string FileName { get; set; }

    public string Url => $"/Uploads/Customer/{UserId}/{FileName}";

    public required string UserId { get; set; }

    public UserDto? User { get; set; }

    public string? Label { get; set; }

    public string? Description { get; set; }

    public bool IsVisible { get; set; }

    public decimal? Size { get; set; }

    public string? SizeLabel
    {
        get
        {
            var unit = "bytes";
            decimal readableSize = 0;
            if (Size != null)
            {
                unit = "KB";
                readableSize = Size.Value / 1024;
                if (readableSize > 1023)
                {
                    unit = "MB";
                    readableSize = readableSize / 1024;
                }
            }
            return $"{Math.Round(readableSize, unit == "MB" ? 2 : 0)} {unit}";
        }
    }

    public string? Type { get; set; }

    public DateTime UploadDateTime { get; set; }

    public string UploadDateTimeLocal => UploadDateTime.ConvertFromUtcString();

    public string UploadDateTimeHumanized => UploadDateTime == DateTime.MinValue
            ? "" : DateTime.UtcNow.Add(-(DateTime.UtcNow - UploadDateTime)).Humanize();
}
