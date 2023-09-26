namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Mappers;
public class TripProfile : Profile
{
    public TripProfile()
    {
        Map();
    }
    void Map()
    {
        CreateMap<AddTripDto, Trip>();
        CreateMap<GetTripDto, Trip>();
    }
}
