using System.ComponentModel.DataAnnotations;

namespace CarBooking_Mvc.Models.PostModels;

public class Step3PostModel
{    
    public string OfferUid { get; set; }

    public string Location { get; set; }

    public IEnumerable<string> OfferData { get; set; }
}
