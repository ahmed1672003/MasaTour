namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetDeletedTripByIdSpecification : Specification<Trip>
{
    public AsNoTrackingGetDeletedTripByIdSpecification(string id) : base(Trip => Trip.Id.Equals(id) && Trip.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
