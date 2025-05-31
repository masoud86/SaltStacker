using SaltStacker.Application.ViewModels.Base;

namespace SaltStacker.Application.ViewModels.Nutrition.Package;

public class Packages : Pagination
{
    public Packages() : base("`")
    {
        Columns = new Dictionary<string, string> {
            {"CreateDateTime", Resources.Global.CreateTime},
            {"Title", Resources.Global.Title}
        };
    }

    public List<PackageDto>? Items { get; set; }
}