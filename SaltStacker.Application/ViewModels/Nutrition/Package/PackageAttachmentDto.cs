using SaltStacker.Common.Enums;

namespace SaltStacker.Application.ViewModels.Nutrition.Package;

public class PackageAttachmentDto
{
    public int Id { get; set; }

    public required string FileName { get; set; }
    
    public bool IsMain { get; set; }

    public MediaType MediaType { get; set; }

    public int PackageId { get; set; }

    public virtual PackageDto? Package { get; set; }

    public DateTime UploadDateTime { get; set; }
}
