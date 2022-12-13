using System.ComponentModel.DataAnnotations;

namespace CarBooking_Mvc.Models.PostModels;

public class SubmitBookingOfferPostModel
{
    public string Offer { get; set; }
    public string Location { get; set; }

    [Required(ErrorMessage = "Field 'Name' is mandatory")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Field 'Surname' is mandatory")]
    public string Surname { get; set; }
}
