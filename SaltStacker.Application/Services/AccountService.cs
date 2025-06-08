using AutoMapper;
using SaltStacker.Application.Filters;
using SaltStacker.Application.Helpers;
using SaltStacker.Application.Interfaces;
using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Account;
using SaltStacker.Application.ViewModels.Membership;
using SaltStacker.Application.ViewModels.Membership.User;
using SaltStacker.Common.Helper;
using SaltStacker.Domain.Interfaces;
using SaltStacker.Domain.Models.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace SaltStacker.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMembershipService _membershipService;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _iMapper;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly SignInManager<AspNetUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(IMembershipService membershipService, IAccountRepository accountRepository,
            UserManager<AspNetUser> userManager,
            SignInManager<AspNetUser> signInManager,
            IConfiguration configuration)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            _iMapper = config.CreateMapper();
            _membershipService = membershipService;
            _accountRepository = accountRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> CreateAccountAsync(AccountDto model)
        {
            var user = _iMapper.Map<UserDto>(model);
            var createUser = await _membershipService.CreateUserAsync(user);
            if (createUser.Item1.Succeeded)
            {
                var assignRole = await _membershipService.AddUserToRoleAsync(user.Username, "Account");
            }
            return IdentityResult.Failed(new IdentityError { Description = Resources.Error.DatabaseInsert });

        }

        public async Task<List<AccountDto>> GetAccountsAsync(AccountFilters filter)
        {
            var predicate = AccountFilter.ToExpression(filter);

            var model = await _accountRepository.GetAccountsAsync(filter.Start, filter.PageSize, filter.Sort, filter.Direction, predicate);

            return _iMapper.Map<List<AspNetUser>, List<AccountDto>>(model);
        }

        public async Task<Accounts> GetAccountsModelAsync(AccountFilters filter)
        {
            var predicate = AccountFilter.ToExpression(filter);

            var recordTotal = await _accountRepository.GetAccountsCountAsync();

            var recordsFilters = await _accountRepository.GetAccountsCountAsync(predicate);

            return new Accounts
            {
                Items = await GetAccountsAsync(filter),
                TotalCount = recordTotal,
                FilteredCount = recordsFilters,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }

        public async Task<AccountDto> GetAccountAsync(string id)
        {
            var user = await _membershipService.FindUserByIdAsync(id);
            var account = _iMapper.Map<AccountDto>(user);
            return account;
        }

        public async Task<IdentityResult> UpdateAccountAsync(AccountDto model)
        {
            return await _membershipService.UpdateUserAsync(_iMapper.Map<EditUser>(model));
        }

        public async Task<AccountProfileApi> GetAccountProfileByUsernameAsync(string username)
        {
            var user = await _membershipService.FindUserByNameAsync(username);
            var accountProfile = _iMapper.Map<AccountProfileApi>(user);
            return accountProfile;
        }

        public async Task<ServiceResult> UpdateAccountProfileAsync(AccountProfileApi model, string username)
        {
            var user = await _membershipService.FindUserByNameAsync(username);

            var updateUser = new EditUser
            {
                Id = user.Id,
                Name = model.Name,
                Email = model.EmailAddress,
                PhoneNumber = model.PhoneNumber
            };

            await _membershipService.UpdateUserAsync(updateUser);

            return new ServiceResult(true);
        }

        public async Task<int> CountAccountsAsync(AccountFilters filter)
        {
            var predicate = AccountFilter.ToExpression(filter);
            return await _accountRepository.GetAccountsCountAsync(predicate);
        }

        public async Task<AspNetUser> FindUserByPhoneNumber(string phoneNumber)
        {
            return await _accountRepository.FindUserByPhoneNumber(phoneNumber);
        }

        public async Task<RegisterResult> RegisterAccountAsync(RegisterAccount model)
        {
            var currentUser = await _accountRepository.FindAccountByEmailAsync(model.Email.Trim().ToUpper());
            if (currentUser != null)
            {
                return new RegisterResult { Succeeded = false, ErrorMessage = "Already exists!" };
            }

            if (!string.IsNullOrEmpty(model.Referral))
            {
                var referral = await _userManager.FindByNameAsync(model.Referral);
                if (referral == null)
                {
                    return new RegisterResult { Succeeded = false, ErrorMessage = "Wrong referral code" };
                }
            }

            var email = model.Email.Trim().ToLower();
            var userName = UserHelper.UsernameGenerator(model.Name, model.Email);
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new AspNetUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = model.Name,
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                PhoneNumber = model.PhoneNumber,
                PasswordHash = hasher.HashPassword(null, model.Password)
            };

            var register = await _accountRepository.CreateAccountAsync(user);

            if (register)
            {
                return new RegisterResult { Succeeded = true, Username = userName };
            }

            return new RegisterResult { Succeeded = false, ErrorMessage = "Unkown Error" };
        }

        public async Task<AccountInformation?> GetAccountInformationAsync(string username)
        {
            var user = await _membershipService.FindUserByNameAsync(username);
            if (user == null)
            {
                return null;
            }

            return _iMapper.Map<AccountInformation>(user);
        }
    }
}
