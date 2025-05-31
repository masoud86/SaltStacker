using SaltStacker.Application.ViewModels.Base;
using SaltStacker.Common.Helper;
using System.ComponentModel.DataAnnotations;

namespace SaltStacker.Application.ViewModels.Nutrition
{
    public class IngredientTypeUnits : Pagination
    {
        public IngredientTypeUnits() : base("EditDateTime")
        {
            Columns = new Dictionary<string, string> {
                {"EditDateTime", Resources.Global.LastModifiedAt}
            };
        }
        public int IngredientTypeId { get; set; }

        public IngredientTypeDto IngredientType { get; set; }

        public List<IngredientTypeUnitDto> Items { get; set; }
    }

    public class IngredientTypeUnitFilters : Pagination
    {
        public IngredientTypeUnitFilters() : base("EditDateTime")
        {
        }
        public int IngredientTypeId { get; set; }
    }

    public class IngredientTypeUnitDto : NutritionFactsDto
    {
        public int Id { get; set; }

        public int IngredientTypeId { get; set; }
        public IngredientTypeDto? IngredientType { get; set; }

        public int UnitId { get; set; }
        public UnitDto? Unit { get; set; }
        public List<UnitDto>? Units { get; set; }


        public double? ConversionFactor { get; set; }

        #region Pricing
        public string PriceOperator { get; set; }

        public double PriceFactor { get; set; }

        public bool IsPercent { get; set; }
        #endregion Pricing

        #region Unit Convertion
        [Display(Name = "Operator")]
        public string AmountOperator { get; set; }

        [Display(Name = "Factor")]
        public double? AmountFactor { get; set; }
        #endregion Unit Convertion

        public DateTime EditDateTime { get; set; }
        public string EditDateTimeLocal => EditDateTime.ConvertFromUtcString();
    }
}
