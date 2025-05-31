using Microsoft.AspNetCore.Identity;
using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Account;
using SaltStacker.Domain.Models.Membership;

namespace SaltStacker.Application.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccountAsync(AccountDto model);

        Task<List<AccountDto>> GetAccountsAsync(AccountFilters filter);

        Task<Accounts> GetAccountsModelAsync(AccountFilters filter);

        Task<AccountDto> GetAccountAsync(string id);

        Task<IdentityResult> UpdateAccountAsync(AccountDto model);
        
        Task<AccountProfileApi> GetAccountProfileByUsernameAsync(string username);

        Task<ServiceResult> UpdateAccountProfileAsync(AccountProfileApi model, string username);

        Task<int> CountAccountsAsync(AccountFilters filter);

        Task<AspNetUser> FindUserByPhoneNumber(string phoneNumber);

        Task<RegisterResult> RegisterAccountAsync(RegisterAccount model); 
        
        Task<AccountInformation?> GetAccountInformationAsync(string username);
    }
}
