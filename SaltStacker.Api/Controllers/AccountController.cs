﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaltStacker.Application.Interfaces;
using SaltStacker.Application.ViewModels.Api;
using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Account;
using SaltStacker.Application.ViewModels.Membership;
using SaltStacker.Domain.Models.Membership;
using System.Security.Claims;
using System.Web;

namespace SaltStacker.Api.Controllers;

/// <summary>
/// Manage user accounts and authentication
/// </summary>
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<AspNetUser> _userManager;
    private readonly SignInManager<AspNetUser> _signInManager;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="userManager">User Manager</param>
    /// <param name="signInManager">Sign in Manager</param>
    /// <param name="accountService">Account Services</param>
    /// <param name="tokenService">Token Services</param>
    public AccountController(UserManager<AspNetUser> userManager,
        SignInManager<AspNetUser> signInManager, IAccountService accountService,
        ITokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _accountService = accountService;
        _tokenService = tokenService;
    }

    /// <summary>
    /// Register a new user
    /// </summary>
    /// <remarks>
    /// Email address must be unique / Password policies are not applied yet
    /// </remarks>
    /// <param name="model">Register Model</param>
    /// <returns>Register status and JWT tokens</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad Request</response>
    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<RegisterResponseApi>> Register([FromBody] RegisterAccount model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid client request");
        }

        var result = new RegisterResponseApi();

        var register = await _accountService.RegisterAccountAsync(model);

        result.Succeeded = register.Succeeded;
        result.ErrorMessage = register.ErrorMessage;

        if (result.Succeeded)
        {
            var claims = new List<Claim>
            {
                new Claim("type", "Account"),
                new Claim("name", register.Username)
            };

            result.AccountInformation = await _accountService.GetAccountInformationAsync(register.Username);
            result.AccessToken = _tokenService.GenerateAccessToken(claims);
            result.RefreshToken = _tokenService.GenerateRefreshToken();
            await _tokenService.UpdateRefreshTokenAsync(register.Username, result.RefreshToken);
        }

        return new OkObjectResult(result);
    }

    /// <summary>
    /// Login with email and password using JWT token
    /// </summary>
    /// <param name="model">Login Model</param>
    /// <returns>JWT tokens</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad request</response>
    /// <response code="401">Wrong data</response>
    /// <response code="403">Not authorized to access</response>
    [HttpPost]
    [Route("[action]")]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResult>> Login([FromBody] AccountLogin model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid client request");
        }

        var user = await _userManager.FindByEmailAsync(model.Username);
        if (user == null)
        {
            user = await _accountService.FindUserByPhoneNumber(model.Username);
            if (user == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Login faild. Invalid username or password.");
            }
        }

        if (await _userManager.IsLockedOutAsync(user))
        {
            await _userManager.AccessFailedAsync(user);
            return Forbid(Resources.Error.AccountLocked);
        }

        var signIn = await _signInManager.CheckPasswordSignInAsync(user, model.Password, true);

        if (signIn.Succeeded)
        {
            await _userManager.UpdateAsync(user);

            await _userManager.ResetAccessFailedCountAsync(user);

            var claims = new List<Claim>
            {
                new Claim("type", "Account"),
                new Claim("name", user.UserName)
            };

            var result = new LoginResult
            {
                AccessToken = _tokenService.GenerateAccessToken(claims),
                RefreshToken = _tokenService.GenerateRefreshToken(),
                AccountInformation = await _accountService.GetAccountInformationAsync(user.UserName)
            };

            await _tokenService.UpdateRefreshTokenAsync(user.UserName, result.RefreshToken);

            return new OkObjectResult(result);
        }

        return StatusCode(StatusCodes.Status403Forbidden, "Login faild. Invalid username or password.");
    }

    /// <summary>
    /// Refresh JWT access token
    /// </summary>
    /// <param name="model">JWT token model</param>
    /// <returns>JWT tokens</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="400">Bad request</response>
    /// <response code="401">Invalid token</response>
    [HttpPost]
    [Route("[action]")]
    [AllowAnonymous]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult<JwtToken>> Refresh([FromBody] JwtToken model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid client request");
        }

        var principal = _tokenService.GetPrincipalFromExpiredToken(model.AccessToken);
        var username = principal.Claims.FirstOrDefault(p => p.Type == "name")?.Value;

        if (username == null)
        {
            return Unauthorized("Invalid token");
        }

        var user = await _userManager.FindByNameAsync(username);

        //if (user == null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
        if (user == null || user.RefreshToken != model.RefreshToken)
        {
            return Unauthorized("Invalid token");
        }

        var result = new JwtToken
        {
            AccessToken = _tokenService.GenerateAccessToken(principal.Claims),
            RefreshToken = user.RefreshToken
        };
        await _tokenService.UpdateRefreshTokenAsync(user.UserName, result.RefreshToken);

        return new OkObjectResult(result);
    }

    /// <summary>
    /// Invoke account token
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="200">Successful operation</response>
    /// <response code="401">Invalid token</response>
    [HttpPost]
    [Route("[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult> Logoff()
    {
        var username = User.Claims.First(p => p.Type == "name").Value;
        await _tokenService.UpdateRefreshTokenAsync(username, string.Empty);

        return new NoContentResult();
    }

    /// <summary>
    /// Get logged in account information
    /// </summary>
    /// <returns>Account Information</returns>
    /// <response code="200">Operation status</response>
    /// <response code="400">Bad request</response>
    [HttpPost]
    [Route("[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult<AccountInformation>> Info()
    {
        var username = User.Claims.First(p => p.Type == "name").Value;
        var user = await _accountService.GetAccountInformationAsync(username);

        if (user == null)
        {
            return BadRequest("Not Found!");
        }

        return new OkObjectResult(user);
    }

    /// <summary>
    /// Get account profile
    /// </summary>
    /// <returns>Account Profile</returns>
    /// <response code="200">Operation status</response>
    /// <response code="400">Bad request</response>
    [HttpGet]
    [Route("[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult<AccountProfileApi>> GetProfile()
    {
        var username = User.Claims.First(p => p.Type == "name").Value;
        var user = await _accountService.GetAccountInformationAsync(username);

        if (user == null)
        {
            return BadRequest("Not Found!");
        }

        return new OkObjectResult(await _accountService.GetAccountProfileByUsernameAsync(username));
    }

    /// <summary>
    /// Update account profile
    /// </summary>
    /// <param name="model">Address Model</param>
    /// <returns>Service Result</returns>
    /// <response code="200">Operation status</response>
    /// <response code="400">Bad request</response>
    [HttpPost]
    [Route("[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult<ServiceResult>> UpdateProfile(AccountProfileApi model)
    {
        var username = User.Claims.First(p => p.Type == "name").Value;
        var user = await _accountService.GetAccountInformationAsync(username);

        if (user == null)
        {
            return BadRequest("Not Found!");
        }

        var result = await _accountService.UpdateAccountProfileAsync(model, username);

        if (result.Succeeded)
        {
            return new OkObjectResult(result);
        }

        return BadRequest(result.Errors[0].Description);
    }

    /// <summary>
    /// Change Account Password
    /// </summary>
    /// <param name="model">Change Password Model</param>
    /// <returns>Identity Result</returns>
    [HttpPost]
    [Route("[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<ActionResult<IdentityResult>> ChangePassword(ChangePasswordApi model)
    {
        var username = User.Claims.First(p => p.Type == "name").Value;
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return BadRequest("Not Found!");
        }

        return new OkObjectResult(await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword));
    }

    /// <summary>
    /// Send password reset email
    /// </summary>
    /// <param name="email">Email Address</param>
    /// <returns>Service Result</returns>
    //[HttpPost]
    //[Route("[action]")]
    //public async Task<ActionResult<ServiceResult>> SendResetPasswordEmail(string email)
    //{
    //    var user = await _userManager.FindByEmailAsync(email.Trim().ToLower());

    //    if (user == null)
    //    {
    //        return new ServiceResult(false, new List<ServiceError>
    //        {
    //            new ServiceError
    //            {
    //                Description = "We couldn't find this email address!"
    //            }
    //        });
    //    }

    //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);

    //    if (_configuration.GetSection("Email:ResetPassword").Get<bool>())
    //    {
    //        await _emailService.SendEmailByGmailApiAsync(new[] { user.Email },
    //            "Password Reset", TemplateHelper.GenerateEmailBody("Email/Membership/ResetPassword", new
    //            {
    //                Account = user.Name,
    //                Username = user.UserName,
    //                Token = HttpUtility.UrlEncode(token).Replace("%", "_")
    //            }, _configuration.GetSection("DevelopmentMode").Get<bool>()));
    //    }

    //    return new OkObjectResult(new ServiceResult(true));
    //}

    /// <summary>
    /// Verify password token
    /// </summary>
    /// <param name="model">Password Token</param>
    /// <returns>Is Valid</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<ServiceResult>> VerifyUserToken(CheckResetPasswordApi model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);

        if (user == null)
        {
            return BadRequest("Not Found!");
        }
        var token = HttpUtility.UrlDecode(model.Token.Replace("_", "%"));
        var isValid = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token);

        if (!isValid)
        {
            return new UnauthorizedObjectResult(new ServiceResult(isValid, new List<ServiceError>
            {
                new ServiceError
                {
                    Code = "NotValid",
                    Description = "Token not valid",
                    Level = ErrorLevel.Blocker
                }
            }));
        }

        return new OkObjectResult(new ServiceResult(true));
    }

    /// <summary>
    /// Reset Password
    /// </summary>
    /// <param name="model">Reset Password Model</param>
    /// <returns>Identity Result</returns>
    [HttpPost]
    [Route("[action]")]
    public async Task<ActionResult<IdentityResult>> ResetPassword(ResetPasswordApi model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);

        if (user == null)
        {
            return BadRequest("Not Found!");
        }

        return new OkObjectResult(await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(model.Token.Replace("_", "%")), model.NewPassword));
    }
}
