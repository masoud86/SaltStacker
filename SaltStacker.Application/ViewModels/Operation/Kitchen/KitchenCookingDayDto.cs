using SaltStacker.Common.Helper;

namespace SaltStacker.Application.ViewModels.Operation.Kitchen;

public class KitchenCookingDayDto
{
    public int Id { get; set; }

    public int KitchenId { get; set; }
    public KitchenDto? Kitchen { get; set; }

    public DayOfWeek CookingDay { get; set; }

    public string CookingDayTitle => CookingDay.ToString();

    public DateTime? CookingDate { get; set; }

    public DayOfWeek? DeliveryDay { get; set; }

    public string DeliveryDayTitle => DeliveryDay.HasValue ? DeliveryDay.Value.ToString() : "";

    public DateTime? DeliveryDate { get; set; }

    public string? DeliveryPeriod { get; set; }

    public DayOfWeek? PickupDay { get; set; }

    public string PickupDayTitle => PickupDay.HasValue ? PickupDay.Value.ToString() : "";

    public DateTime? PickupDate { get; set; }

    public string? PickupPeriod { get; set; }

    public int CutOff { get; set; }

    public string CutOffHumanized => CookingDay.AddDayOfWeek(-1 * CutOff);

    public required string CoverableDays { get; set; }

    public List<string>? CoverableDaysList => CoverableDays.Split(',').Select(p => ((DayOfWeek)Convert.ToInt32(p)).GetShortDayName()).ToList();

    public DateTime? CutOffDate { get; set; }

    public int ItemCount { get; set; }
}
