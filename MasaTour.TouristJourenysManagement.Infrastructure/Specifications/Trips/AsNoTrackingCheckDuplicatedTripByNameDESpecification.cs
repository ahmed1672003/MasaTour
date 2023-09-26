namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingCheckDuplicatedTripByNameDESpecification : Specification<Trip>
{
    public AsNoTrackingCheckDuplicatedTripByNameDESpecification(string TripId, string nameDE)
        : base(Trip => Trip.NameDE.Equals(nameDE) && !Trip.Id.Equals(TripId))
    {
        StopTracking();
    }
}
