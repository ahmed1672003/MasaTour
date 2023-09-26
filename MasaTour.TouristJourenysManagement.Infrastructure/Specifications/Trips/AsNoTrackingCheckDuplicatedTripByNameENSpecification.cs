namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingCheckDuplicatedTripByNameENSpecification : Specification<Trip>
{
    public AsNoTrackingCheckDuplicatedTripByNameENSpecification(string TripId, string nameEN)
        : base(Trip => Trip.NameEN.Equals(nameEN) && !Trip.Id.Equals(TripId))
    {
        StopTracking();
    }
}
