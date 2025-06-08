using SaltStacker.Domain.Models.Membership;
using System.Linq.Expressions;

namespace SaltStacker.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<int> GetAccountsCountAsync(Expression<Func<AspNetUser, bool>> predicate = null);

        Task<List<AspNetUser>> GetAccountsAsync(int start, int pageSize, string sortBy, string direction,
            Expression<Func<AspNetUser, bool>> predicate = null);

        Task<AspNetUser> FindUserByPhoneNumber(string phoneNumber);

        Task<AspNetUser> FindAccountByEmailAsync(string emailAddress);

        Task<bool> CreateAccountAsync(AspNetUser user);
    }
}
