using SaltStacker.Domain.Models.Operation;
using System.Linq.Expressions;

namespace SaltStacker.Domain.Interfaces
{
    public interface IOperationRepository
    {
        Task<int> GetOverheadCostsCountAsync(Expression<Func<OverheadCost, bool>> predicate = null);

        Task<List<OverheadCost>> GetOverheadCostsAsync(int start, int pageSize, string sortBy, string direction,
            Expression<Func<OverheadCost, bool>> predicate = null);
    }
}
