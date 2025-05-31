using SaltStacker.Application.ViewModels.Account;
using SaltStacker.Domain.Models.Membership;
using LinqKit;

namespace SaltStacker.Application.Filters
{
    public static class AccountFilter
    {
        public static ExpressionStarter<AspNetUser> ToExpression(AccountFilters filter)
        {
            var predicate = PredicateBuilder.New<AspNetUser>(p => !p.IsAdmin);

            if (!string.IsNullOrEmpty(filter.Query))
            {
                predicate.And(p =>
                    p.Name.ToLower().Contains(filter.Query) ||
                    p.Email.ToLower().Contains(filter.Query) ||
                    p.PhoneNumber.ToLower().Contains(filter.Query));
            }

            return predicate;
        }
    }
}
