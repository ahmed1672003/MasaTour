namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsTrackingGetDeletedTripByIdSpecification : Specification<Trip>
{
    public AsTrackingGetDeletedTripByIdSpecification(string id) : base(t => t.Id.Equals(id))
    {
        IgnorQueryFilter();
    }
}
