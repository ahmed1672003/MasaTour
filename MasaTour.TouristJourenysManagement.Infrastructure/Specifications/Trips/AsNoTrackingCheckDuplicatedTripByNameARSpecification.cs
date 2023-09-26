namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingCheckDuplicatedTripByNameARSpecification : Specification<Trip>
{
    public AsNoTrackingCheckDuplicatedTripByNameARSpecification(string TripId, string nameAR)
        : base(Trip => Trip.NameAR.Equals(nameAR) && !Trip.Id.Equals(TripId))
    {
        StopTracking();

    }
}
