namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
public class GetTrip_Mandatories_Images_Dto
{
    public GetTripDto Trip { get; set; }
    public IEnumerable<GetImageDto> TripImages { get; set; }
    public IEnumerable<GetMandatoryDto> TripMandatories { get; set; }
}
