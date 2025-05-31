using SaltStacker.Application.ViewModels.Base;

namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class Kitchens : Pagination
{
    public Kitchens() : base("CreateDateTime")
    {
        Columns = new Dictionary<string, string> {
            {"CreateDateTime", "Create Time"},
            {"Title", Resources.Global.Title}
        };
    }

    public List<KitchenDto>? Items { get; set; }
}