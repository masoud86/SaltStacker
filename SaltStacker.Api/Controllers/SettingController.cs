using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaltStacker.Application.Interfaces;
using SaltStacker.Domain.Models.Membership;

namespace SaltStacker.Api.Controllers;

/// <summary>
/// Everything about application settings
/// </summary>
[ApiController]
[Route("[controller]")]
public class SettingController : ControllerBase
{
    private readonly IApplicationService _applicationService;
    private readonly IOperationService _operationService;
    private readonly UserManager<AspNetUser> _userManager;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="applicationService">Application Service</param>
    /// <param name="operationService">Operation Service</param>
    /// <param name="userManager">User Manager</param>
    /// <param name="logService">Log Service</param>
    public SettingController(IApplicationService applicationService, IOperationService operationService,
        UserManager<AspNetUser> userManager)
    {
        _applicationService = applicationService;
        _operationService = operationService;
        _userManager = userManager;
    }

    /// <summary>
    /// Get account app current version
    /// </summary>
    /// <returns>Current Version</returns>
    [HttpGet]
    [Route("[action]")]
    public ActionResult<string> GetCurrentVersion()
    {
        return new OkObjectResult(_applicationService.GetSetting("AccountAppVersion"));
    }

    /// <summary>
    /// Temporary API to set account app current version
    /// </summary>
    /// <param name="version">Current Version</param>
    /// <returns>Ok Response</returns>
    [HttpGet]
    [Route("[action]")]
    public ActionResult SetCurrentVersion(string version)
    {
        _applicationService.SetSettings("AccountAppVersion", version);
        _applicationService.UpdateCache();
        return Ok();
    }
}
