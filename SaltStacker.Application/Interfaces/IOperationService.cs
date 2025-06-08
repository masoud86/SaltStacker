using SaltStacker.Application.ViewModels.Operation;

namespace SaltStacker.Application.Interfaces
{
    public interface IOperationService
    {
        Task<List<OverheadCostDto>> GetOverheadCostsAsync(OverheadCostFilters filter);

        Task<OverheadCosts> GetOverheadCostsModelAsync(OverheadCostFilters filter);
    }
}
