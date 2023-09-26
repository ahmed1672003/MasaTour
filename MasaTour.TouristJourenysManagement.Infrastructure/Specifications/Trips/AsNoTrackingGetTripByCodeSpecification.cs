namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripByCodeSpecification : Specification<Trip>
{
    public AsNoTrackingGetTripByCodeSpecification(string code)
        : base(t => t.Code.Equals(code))
    {
        StopTracking();
    }
}
