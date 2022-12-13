using CarBooking_Mvc.Dto;

namespace CarBooking_Mvc.Models.ViewModels;

public class Step1ViewModel
{
    public IEnumerable<LocationDto> Locations { get; set; }
}
