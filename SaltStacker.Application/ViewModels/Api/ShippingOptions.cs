namespace SaltStacker.Application.ViewModels.Api;

public class ShippingOptions
{
    public int AllowedNumberOfShips { get; set; }

    public DeliveryOptions? DeliveryOptions { get; set; }
    
    public PickupOptions? PickupOptions { get; set; }
}

public class DeliveryOptions
{
    public List<ShipDay>? ShipDays { get; set; }
}

public class PickupOptions
{
    public List<Location>? Locations { get; set; }
}

public class ShipDay
{
    public DateTime Day { get; set; }

    public List<Period> Periods { get; set; }
}

public class Period
{
    public int Id { get; set; }

    public string Title { get; set; }
}

public class Location
{
    public string Title { get; set; }

    public string Address { get; set; }

    public List<ShipDay>? ShipDays { get; set; }
}
