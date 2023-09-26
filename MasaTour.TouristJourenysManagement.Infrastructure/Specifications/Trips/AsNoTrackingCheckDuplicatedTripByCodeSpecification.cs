namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingCheckDuplicatedTripByCodeSpecification : Specification<Trip>
{
    public AsNoTrackingCheckDuplicatedTripByCodeSpecification(string tripId, string code)
        : base(t => t.Code.Equals(code) && !t.Id.Equals(tripId))
    {
        StopTracking();
    }
}
