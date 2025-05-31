using SaltStacker.Application.ViewModels.Operation;
using SaltStacker.Application.ViewModels.Operation.Kitchen;
using SaltStacker.Common.Enums;
using SaltStacker.Domain.Models.Operation;
using LinqKit;

namespace SaltStacker.Application.Filters;

public static class OperationFilter
{
    public static ExpressionStarter<OverheadCost> ToExpression(OverheadCostFilters filter)
    {
        var predicate = PredicateBuilder.New<OverheadCost>(_ => true);

        if (!string.IsNullOrEmpty(filter.Query))
        {
            predicate.And(p => p.Title.ToLower().Contains(filter.Query));
        }

        return predicate;
    }

    public static ExpressionStarter<OverheadCost> ToExpression(OverheadCategory category)
    {
        var predicate = PredicateBuilder.New<OverheadCost>(_ => true);
        if (category != OverheadCategory.All)
        {
            predicate.And(p => p.Category == category);
        }
        return predicate;
    }

    public static ExpressionStarter<Kitchen> ToExpression(KitchenFilters filter)
    {
        var predicate = PredicateBuilder.New<Kitchen>(_ => true);

        if (!string.IsNullOrEmpty(filter.Query))
        {
            predicate.And(p =>
                p.Title.Contains(filter.Query, StringComparison.CurrentCultureIgnoreCase));
        }

        return predicate;
    }
}
