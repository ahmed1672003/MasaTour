namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripById_Images_Specification : Specification<Trip>
{
    public AsNoTrackingGetTripById_Images_Specification(string tripId) :
        base(t => t.Id.Equals(tripId))
    {
        StopTracking();
        AddIncludesString($"{nameof(Trip.TripImageMappers)}.{nameof(TripImageMapper.Image)}");

    }
}
