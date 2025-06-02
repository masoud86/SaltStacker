using Microsoft.EntityFrameworkCore;
using SaltStacker.Data.Context;
using SaltStacker.Domain.Interfaces;
using SaltStacker.Domain.Models.Operation;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace SaltStacker.Data.Repository
{
    public class OperationRepository : IOperationRepository
    {
        private readonly AppDbContext _context;

        public OperationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetOverheadCostsCountAsync(Expression<Func<OverheadCost, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _context.OverheadCosts.CountAsync();
            }
            return await _context.OverheadCosts
                .CountAsync(predicate);
        }

        public async Task<List<OverheadCost>> GetOverheadCostsAsync(int start, int pageSize, string sortBy, string direction, Expression<Func<OverheadCost, bool>> predicate = null)
        {
            return await _context.OverheadCosts
                .Where(predicate)
                .OrderBy(sortBy + " " + direction)
                .Skip(start).Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
