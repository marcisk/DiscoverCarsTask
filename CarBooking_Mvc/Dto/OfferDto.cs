using System.Text.Json;

namespace CarBooking_Mvc.Dto;

public class OfferDto
{
    public string OfferUid { get; set; }

    public VehicleDto Vehicle { get; set; }

    public PriceDto Price { get; set; }

    public VendorDto Vendor { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this).Replace(Environment.NewLine, "");
    }
}
