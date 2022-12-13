using CarBooking_Mvc.Dto;

namespace CarBooking_Mvc.Models.ViewModels;

public class Step2ViewModel
{
    public LocationDto Location { get; set; }

    public IEnumerable<OfferDto> Offers { get; set; }
}
