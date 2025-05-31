using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Membership;
using SaltStacker.Application.ViewModels.Membership.File;
using SaltStacker.Application.ViewModels.Membership.User;
using SaltStacker.Domain.Models.Membership;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SaltStacker.Application.Interfaces
{
    public interface IMembershipService
    {
        Task<SignInResult> LoginAsync(Login model);

        Task<List<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();

        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string returnUrl);

        Task<ExternalLoginInfo> GetExternalLoginInfoAsync();

        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);

        Task<AspNetUser> FindUserByIdAsync(string userId);
        
        Task<AspNetUser> FindUserByEmailAsync(string email);

        Task<AspNetUser> FindUserByNameAsync(string username);

        Task<IdentityResult> CreateUserAsync(CreateUser model);

        Task<Tuple<IdentityResult, string>> CreateUserAsync(UserDto model);

        Task<EditUser> GetUserForEditAsync(string userId);

        Task<IdentityResult> UpdateUserAsync(EditUser model);

        Task<IdentityResult> ConfirmEmailAsync(AspNetUser model, string token);

        Task<IdentityResult> ConfirmPhoneNumberAsync(string username);

        Task<bool> IsEmailFree(string email);

        Task<bool> IsUsernameFree(string username);

        Task<string> GenerateEmailConfirmationLinkAsync(CreateUser model, string url);

        bool IsSignedIn(ClaimsPrincipal model);

        Task<bool> IsBlockedAsync(string userId);

        Task CreateThirdPartyUserAsync(string email, ExternalLoginInfo externalLoginInfo);

        void SignOut();

        Task<Users> GetUsersAsync(UserFilters filter);

        Task<Roles> GetRolesAsync(RoleFilters filter);

        Task<List<RoleDto>> GetSelectableRolesAsync();

        Task<IdentityResult> CreateRoleAsync(CreateRole model);

        Task<AspNetRole> FindRoleByIdAsync(string id);

        Task<AspNetRole> FindRoleByNameAsync(string name);

        Task<IdentityResult> AddUserToRoleAsync(string username, string role);

        Task<IdentityResult> DeleteRoleAsync(DeleteRole model);

        Task<IdentityResult> UpdateRoleAsync(EditRole model);

        Task<string> GetRoleByUserIdAsync(string userId);

        Task<EditRole> GetRoleForEditAsync(string id);

        Task<DeleteRole> GetRoleForDeleteAsync(string id);

        Task<UserDto> GetUserInformationAsync(string id);

        Task RefreshSignInAsync(AspNetUser user);

        Task ManageRoleClaimsAsync(string roleId, List<Permission> permissions);

        Task<List<Permission>> CurrentClaimsAsync(string roleId, List<Permission> permissions);

        Task<bool> IsLockedOutAsync(AspNetUser user);

        Task<IdentityResult> ResetAccessFailedCountAsync(AspNetUser user);

        Task SignInWithClaimsAsync(AspNetUser user);

        Task<IdentityResult> AccessFailedAsync(AspNetUser user);

        Task<IdentityResult> LoginWithMobile(AspNetUser user);

        Task<IdentityResult> ChangeUserAccessAsync(UserDto user, bool access);

        Task<int> NumberOfAccountsAsync();

        Task<IdentityResult> ChangePasswordAsync(ChangePassword model);

        Task<IdentityResult> ResetPasswordAsync(ResetPassword model);

        Task<List<UserDto>> GetPersonalChefAsync();

        Task<IdentityResult> SetDefaultKitchenAsync(string userId, int kitchenId);

        Task<ServiceResult> SwitchRoleAsync(SwitchRole model);
    }
}
