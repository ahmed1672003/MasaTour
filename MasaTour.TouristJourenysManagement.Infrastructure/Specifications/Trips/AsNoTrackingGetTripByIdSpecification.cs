namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetTripByIdSpecification : Specification<Trip>
{
    public AsNoTrackingGetTripByIdSpecification(string id) : base(Trip => Trip.Id.Equals(id))
    {
        StopTracking();
    }
}
