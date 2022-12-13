using CarBooking_Mvc.Dto;
using CarBooking_Mvc.Models.PostModels;
using CarBooking_Mvc.Models.ViewModels;
using CarBooking_Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CarBooking_Mvc.Controllers;

public class BookingController : Controller
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet]
    public async Task<IActionResult> Step1()
    {
        var viewModel = new Step1ViewModel
        {
            Locations = await _bookingService.GetLocations()
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Step2(Step2PostModel postModel)
    {
        var request = Request;
        var locations = postModel.LocationData.Select(x => JsonSerializer.Deserialize<LocationDto>(x));
        var location = locations.Where(x => x.Id == postModel.LocationId).First();
        var viewModel = new Step2ViewModel
        {
            Location = location,
            Offers = await _bookingService.GetOffers(location.Id)
        };

        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Step3(Step3PostModel postModel)
    {
        var request = Request;
        var location = JsonSerializer.Deserialize<LocationDto>(postModel.Location);
        var offers = postModel.OfferData.Select(x => JsonSerializer.Deserialize<OfferDto>(x));
        var offer = offers.Where(x => x.OfferUid == postModel.OfferUid).First();
        var viewModel = new Step3ViewModel
        {
            Location = location,
            Offer = offer
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitBookingOffer(SubmitBookingOfferPostModel postModel)
    {
        if (!ModelState.IsValid)
        {
            var viewModel = new Step3ViewModel
            {
                Location = JsonSerializer.Deserialize<LocationDto>(postModel.Location),
                Offer = JsonSerializer.Deserialize<OfferDto>(postModel.Offer),
                Name = postModel.Name,
                Surname = postModel.Surname,
            };

            return View("Step3", viewModel);
        }

        var reservationParams = new ReservationRequestDto
        {
            OfferUid = JsonSerializer.Deserialize<OfferDto>(postModel.Offer).OfferUid,
            Customer = new CustomerDto
            {
                Name = postModel.Name,
                Surname = postModel.Surname,
            }
        };

        var reservation = await _bookingService.CreateReservation(reservationParams);
        return RedirectToAction("SubmitedBookingOffer", "Booking", new
        {
            id = reservation.ConfirmationNumber
        });
    }

    [HttpGet]
    public IActionResult SubmitedBookingOffer(string id)
    {
        var viewModel = new SubmitedBookingOfferViewModel
        {
            ReservationNumber = id
        };

        return View(viewModel);
    }
}
