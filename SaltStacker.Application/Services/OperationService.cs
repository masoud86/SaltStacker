using AutoMapper;
using SaltStacker.Application.Filters;
using SaltStacker.Application.Helpers;
using SaltStacker.Application.Interfaces;
using SaltStacker.Application.ViewModels.Operation;
using SaltStacker.Application.ViewModels.Operation.Kitchen;
using SaltStacker.Domain.Interfaces;
using SaltStacker.Domain.Models.Operation;

namespace SaltStacker.Application.Services
{
    public partial class OperationService : IOperationService
    {
        private readonly IMapper _iMapper;
        private readonly IOperationRepository _operationRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly INutritionService _nutritionService;
        private readonly INutritionRepository _nutritionRepository;
        private readonly IApplicationRepository _applicationRepository;

        public OperationService(IOperationRepository operationRepository,
            IAccountRepository accountRepository,
            INutritionService nutritionService, INutritionRepository nutritionRepository,
            IApplicationRepository applicationRepository)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());

            _iMapper = config.CreateMapper();
            _operationRepository = operationRepository;
            _accountRepository = accountRepository;
            _nutritionService = nutritionService;
            _nutritionRepository = nutritionRepository;
            _applicationRepository = applicationRepository;
        }

        #region Overhead Cost
        public async Task<List<OverheadCostDto>> GetOverheadCostsAsync(OverheadCostFilters filter)
        {
            var predicate = OperationFilter.ToExpression(filter.OverheadCategory);

            var model = await _operationRepository.GetOverheadCostsAsync(filter.Start, filter.PageSize, filter.Sort, filter.Direction, predicate);

            return _iMapper.Map<List<OverheadCost>, List<OverheadCostDto>>(model);
        }

        public async Task<OverheadCosts> GetOverheadCostsModelAsync(OverheadCostFilters filter)
        {
            var predicate = OperationFilter.ToExpression(filter);

            var recordTotal = await _operationRepository.GetOverheadCostsCountAsync();

            var recordsFilters = await _operationRepository.GetOverheadCostsCountAsync(predicate);

            return new OverheadCosts
            {
                Items = await GetOverheadCostsAsync(filter),
                TotalCount = recordTotal,
                FilteredCount = recordsFilters,
                Page = filter.Page,
                PageSize = filter.PageSize
            };
        }
        #endregion Overhead Cost

        public async Task<List<KitchenRecipeDto>> GetRecipesByKitchenAsync(int kitchenId)
        {
            var kitchenRecipes = await _operationRepository.GetRecipesByKitchenAsync(kitchenId);
            return _iMapper.Map<List<KitchenRecipeDto>>(kitchenRecipes);
        }

        public async Task<bool> AddRecipeToKitchenAsync(int kitchenId, int recipeId)
        {
            return await _operationRepository.AddRecipeToKitchenAsync(kitchenId, recipeId);
        }

        public async Task<bool> RemoveRecipeFromKitchenAsync(int kitchenId, int recipeId)
        {
            return await _operationRepository.RemoveRecipeFromKitchenAsync(kitchenId, recipeId);
        }
    }
}