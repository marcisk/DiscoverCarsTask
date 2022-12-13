using CarBooking_Mvc.Dto;

namespace CarBooking_Mvc.Services;

public class BookingService : IBookingService
{
    private readonly HttpClient _httpClient;
    private readonly string _bookingApiBaseUrl;

    public BookingService(IConfiguration configuration)
    {
        _bookingApiBaseUrl = configuration["BookingApiUrl"];
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(_bookingApiBaseUrl);
    }

    public async Task<ReservationResponseDto> CreateReservation(ReservationRequestDto reservationRequest) =>
        await (await _httpClient.PostAsJsonAsync("/api/v1/Reservations/CreateReservation", reservationRequest)).Content.ReadFromJsonAsync<ReservationResponseDto>();


    public async Task<IEnumerable<LocationDto>> GetLocations() => await _httpClient.GetFromJsonAsync<IEnumerable<LocationDto>>("/api/v1/Locations/Locations");

    public async Task<IEnumerable<OfferDto>> GetOffers(int locationId)
    {
        var requestParams = new
        {
            locationId
        };

        var response = await _httpClient.PostAsJsonAsync("/api/v1/Availability/GetOffers", requestParams);
        return await response.Content.ReadFromJsonAsync<IEnumerable<OfferDto>>();
    }


}