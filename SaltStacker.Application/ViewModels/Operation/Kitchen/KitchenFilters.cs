using SaltStacker.Application.ViewModels.Base;

namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class KitchenFilters : Pagination
{
    public KitchenFilters() : base("CreateDateTime")
    {
    }

    public bool ShowAll { get; set; }
}
