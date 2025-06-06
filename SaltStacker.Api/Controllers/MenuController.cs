﻿using SaltStacker.Application.Interfaces;
using SaltStacker.Application.ViewModels.Api;
using SaltStacker.Application.ViewModels.Nutrition;
using SaltStacker.Application.ViewModels.Nutrition.Package;
using SaltStacker.Domain.Models.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SaltStacker.Api.Controllers
{
    /// <summary>
    /// Everything about menu
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly INutritionService _nutritionService;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;

        public MenuController(INutritionService nutritionService, UserManager<AspNetUser> userManager,
            IConfiguration configuration, ITokenService tokenService)
        {
            _nutritionService = nutritionService;
            _userManager = userManager;
            _configuration = configuration;
            _tokenService = tokenService;
        }

        /// <summary>
        /// All available filter in menu
        /// </summary>
        /// <remarks>
        /// Diets / Tags / Prep Days
        /// </remarks>
        /// <returns>Menu filter options</returns>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<MenuFilters>> Filters()
        {
            var diets = await _nutritionService.GetDietsApiAsync(new DietFilters { PageSize = 20, Sort = "Order", Direction = "Asc" });
            var tags = await _nutritionService.GetTagsApiAsync(new TagFilters { PageSize = 50, Sort = "Order", Direction = "Asc" });

            if (User != null)
            {
                var claim = User.Claims.FirstOrDefault(p => p.Type == "name");
                if (claim != null)
                {
                    var username = claim.Value;
                    var user = await _userManager.FindByNameAsync(username);
                    var personalDiet = new DietApi
                    {
                        Permalink = "personal",
                        Title = user?.Name,
                        Icon = "personal-diet.svg",
                        IconUrl = $"{_configuration.GetSection("PublicUrl").Get<string>()}/diet/personal-diet.svg",
                        Color = "#903E97",
                        Description = "",
                        EmptyDescription = "How come you don't have your healthy personal chef? Let us make your meals tailored to your health goals, lifestyle & palate."
                    };
                    diets.Insert(0, personalDiet);
                }
            }

            return new OkObjectResult(new MenuFilters
            {
                Diets = diets,
                Tags = tags,
                CookingDays = new List<Application.ViewModels.Base.Day>()
            });
        }

        /// <summary>
        /// All menu items
        /// </summary>
        /// <remarks>
        /// Paging with default page size of 10
        /// </remarks>
        /// <param name="query">Seach term</param>
        /// <param name="diet">Filter by diet</param>
        /// <param name="tags">Filter by tags (comma separated)</param>
        /// <param name="prepDays">Filter by prep days (comma separated)</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="sort">Sort column</param>
        /// <param name="direction">Sort direction</param>
        /// <returns>List of items</returns>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<MenuItems>> Items(string? query, string? diet, string? tags, string? prepDays, int page = 1, int pageSize = 10, string? sort = "Title", string? direction = "Asc")
        {
            var ownerId = "";
            if (diet != null && diet == "personal" && User != null)
            {
                Request.Headers.TryGetValue("Authorization", out var authorizationHeader);

                if (!string.IsNullOrEmpty(authorizationHeader))
                {
                    if (_tokenService.IsExpiredToken(authorizationHeader.ToString().Replace("Bearer ", string.Empty)))
                    {
                        return Unauthorized("Invalid token");
                    }
                }

                var claim = User.Claims.FirstOrDefault(p => p.Type == "name");
                if (claim != null)
                {
                    var username = claim.Value;
                    var user = await _userManager.FindByNameAsync(username);
                    ownerId = user?.Id;
                }
            }
            return new OkObjectResult(await _nutritionService.GetMenuItemsAsync(new MenuItemFilters
            {
                Page = page,
                PageSize = pageSize,
                Sort = !string.IsNullOrEmpty(sort) && sort != "null" ? sort : "",
                Direction = !string.IsNullOrEmpty(direction) && direction != "null" ? direction : "",
                Diet = !string.IsNullOrEmpty(diet) && diet != "null" ? diet : null,
                Tags = !string.IsNullOrEmpty(tags) ? tags.Split(',') : null,
                PrepDays = !string.IsNullOrEmpty(prepDays) && prepDays != "null" ? prepDays.Split(',').Select(int.Parse).Select(p => (DayOfWeek)p).ToList() : null,
                Query = !string.IsNullOrEmpty(query) && query != "null" ? query : "",
                OwnerId = !string.IsNullOrEmpty(ownerId) ? ownerId : null
            }));
        }

        /// <summary>
        /// Item details
        /// </summary>
        /// <param name="code">Item code</param>
        /// <returns>Item details</returns>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<ItemDetails>> ItemDetails(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest();
            }
            var details = await _nutritionService.GetRecipeDetailsApi(code);
            if (details == null || details.Id == 0)
            {
                return new NotFoundObjectResult(details);
            }
            return new OkObjectResult(details);
        }

        /// <summary>
        /// Item details
        /// </summary>
        /// <param name="code">Item code</param>
        /// <returns>Item details</returns>
        /// <response code="200">Successful operation</response>
        /// <response code="400">Bad Request</response>
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<PackageDetails>> PackageDetails(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest();
            }
            var details = await _nutritionService.GetPackageAsync(code);
            if (details == null)
            {
                return new NotFoundObjectResult(details);
            }
            return new OkObjectResult(details);
        }

        /// <summary>
        /// Calculate recipe variables
        /// </summary>
        /// <remarks>
        /// Total price and total nutrition facts can be changed based on ingrdients and their amounts
        /// </remarks>
        /// <param name="code">Recipe Code</param>
        /// <param name="changes">Recipe Changes</param>
        /// <returns>Recipe variables model</returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<RecipeVariables>> CalculateRecipe(string code, RecipeChanges changes)
        {
            return new OkObjectResult(await _nutritionService.CalculateRecipeAsync(code, changes, true));
        }

        /// <summary>
        /// Recipe Changes History
        /// </summary>
        /// <param name="code">Recipe Code</param>
        /// <returns>History of Changes</returns>
        [HttpGet]
        [Route("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<List<RecipeHistory>>> RecipeHistory(string code)
        {
            var username = User.Claims.First(p => p.Type == "name").Value;
            var user = await _userManager.FindByNameAsync(username);
            return new OkObjectResult(await _nutritionService.GetRecipeHistoriesAsync(code, user.Id));
        }
    }
}
