﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SaltStacker.Application.Custom;
using SaltStacker.Application.Interfaces;
using SaltStacker.Application.Services;
using SaltStacker.Data.Repository;
using SaltStacker.Domain.Interfaces;
using SaltStacker.Domain.Models.Membership;

namespace SaltStacker.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            service.AddScoped<IUserClaimsPrincipalFactory<AspNetUser>, CustomUserClaimsPrincipalFactory>();

            //Aplication Layer
            service.AddScoped<IMembershipService, MembershipService>();
            service.AddScoped<IWebRequestService, WebRequestService>();
            service.AddScoped<IApplicationService, ApplicationService>();
            service.AddScoped<ICacheService, CacheService>();
            service.AddScoped<IAccountService, AccountService>();
            service.AddScoped<INutritionService, NutritionService>();
            service.AddScoped<IOperationService, OperationService>();
            service.AddScoped<IUploadService, UploadService>();
            service.AddScoped<ITokenService, TokenService>();

            //Infrastructure Data Layer
            service.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            service.AddScoped<IApplicationRepository, ApplicationRepository>();
            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<INutritionRepository, NutritionRepository>();
            service.AddScoped<IOperationRepository, OperationRepository>();
        }
    }
}
