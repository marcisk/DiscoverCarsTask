using CarBooking_Mvc.Models.ViewModels;
using CarBooking_Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarBooking_Mvc.Controllers;

public class HomeController : Controller
{   

    [HttpGet]
    public IActionResult Index() => RedirectToAction("Step1", "Booking");    
}