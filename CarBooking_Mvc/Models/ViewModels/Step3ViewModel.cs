using CarBooking_Mvc.Dto;
using System.ComponentModel.DataAnnotations;

namespace CarBooking_Mvc.Models.ViewModels;

public class Step3ViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Surname { get; set; }

    public LocationDto Location { get; set; }
    public OfferDto Offer { get; set; }
}
