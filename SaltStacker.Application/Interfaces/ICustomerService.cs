using Microsoft.AspNetCore.Identity;
using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Customer;
using SaltStacker.Domain.Models.Membership;

namespace SaltStacker.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<IdentityResult> CreateCustomerAsync(CustomerDto model);

        Task<List<CustomerDto>> GetCustomersAsync(CustomerFilters filter);

        Task<Customers> GetCustomersModelAsync(CustomerFilters filter);

        Task<CustomerDto> GetCustomerAsync(string id);

        Task<IdentityResult> UpdateCustomerAsync(CustomerDto model);
        
        Task<CustomerProfileApi> GetCustomerProfileByUsernameAsync(string username);

        Task<ServiceResult> UpdateCustomerProfileAsync(CustomerProfileApi model, string username);

        Task<int> CountCustomersAsync(CustomerFilters filter);

        Task<AspNetUser> FindUserByPhoneNumber(string phoneNumber);

        Task<RegisterResult> RegisterCustomerAsync(RegisterCustomer model); 
        
        Task<CustomerInformation?> GetCustomerInformationAsync(string username);
    }
}
