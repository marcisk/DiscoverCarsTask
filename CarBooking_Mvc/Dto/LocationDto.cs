using System.Text.Json;
using System.Text.Json.Serialization;

namespace CarBooking_Mvc.Dto;

public class LocationDto
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this).Replace(Environment.NewLine, "");
    }
}
