using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Nutrition;

namespace SaltStacker.Application.ViewModels.Api
{
    public class MenuFilters
    {
        public List<DietApi>? Diets { get; set; }

        public List<TagApi>? Tags { get; set; }

        public List<Day>? CookingDays { get; set; }
    }
}
