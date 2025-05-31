using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Application.ViewModels.Operation;
using SaltStacker.Common.Helper;
using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Nutrition
{
    public class RecipeOverheadCosts : Pagination
    {
        public RecipeOverheadCosts() : base("EditDateTime")
        {
            Columns = new Dictionary<string, string> {
                {"EditDateTime", "Last Modified"}
            };
        }
        public int RecipeId { get; set; }

        public RecipeDto Recipe { get; set; }

        public List<RecipeOverheadCostDto> Items { get; set; }
    }

    public class RecipeOverheadCostFilters : Pagination
    {
        public RecipeOverheadCostFilters() : base("EditDateTime")
        {
        }
        
        public int? RecipeId { get; set; }
    }

    public class RecipeOverheadCostDto
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        [Display(Name = "OverheadCost", ResourceType = typeof(Resources.Global))]
        public int OverheadCostId { get; set; }

        public List<OverheadCostDto>? OverheadCosts { get; set; }
        public string? OverheadCostTitle { get; set; }

        public decimal Amount { get; set; }


        public DateTime EditDateTime { get; set; }
        public string EditDateTimeLocal => EditDateTime.ConvertFromUtcString();
    }
}
