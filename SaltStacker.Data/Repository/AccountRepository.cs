using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaltStacker.Data.Context;
using SaltStacker.Domain.Interfaces;
using SaltStacker.Domain.Models.Membership;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace SaltStacker.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetAccountsCountAsync(Expression<Func<AspNetUser, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return await _context.AspNetUsers.CountAsync();
            }
            return await _context.AspNetUsers
                .CountAsync(predicate);
        }

        public async Task<List<AspNetUser>> GetAccountsAsync(int start, int pageSize, string sortBy, string direction, Expression<Func<AspNetUser, bool>> predicate = null)
        {
            return await _context.AspNetUsers
                .Where(predicate)
                .OrderBy(sortBy + " " + direction)
                .Skip(start).Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<AspNetUser> FindUserByPhoneNumber(string phoneNumber)
        {
            return await _context.AspNetUsers
                .FirstOrDefaultAsync(p => p.PhoneNumber == phoneNumber);
        }

        public async Task<AspNetUser> FindAccountByEmailAsync(string emailAddress)
        {
            return await _context.AspNetUsers
                .FirstOrDefaultAsync(p => p.NormalizedEmail == emailAddress);
        }

        public async Task<bool> CreateAccountAsync(AspNetUser user)
        {
            var done = false;
            var strategy = _context.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () =>
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    var role = await _context.AspNetRoles.FirstOrDefaultAsync(p => p.Name == "Account");
                    if (role != null)
                    {
                        await _context.AspNetUsers.AddAsync(user);
                        await _context.AspNetUserRoles.AddAsync(new IdentityUserRole<string>
                        {
                            UserId = user.Id,
                            RoleId = role.Id
                        });

                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();
                        done = true;
                    }
                }
                catch
                {
                    await transaction.RollbackAsync();
                }
            });
            return done;
        }
    }
}
