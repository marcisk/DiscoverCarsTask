using CarBooking_Mvc.Dto;

namespace CarBooking_Mvc.Services;

public interface IBookingService
{
    Task<IEnumerable<LocationDto>> GetLocations();

    Task<IEnumerable<OfferDto>> GetOffers(int locationId);

    Task<ReservationResponseDto> CreateReservation(ReservationRequestDto reservationRequest);
}
