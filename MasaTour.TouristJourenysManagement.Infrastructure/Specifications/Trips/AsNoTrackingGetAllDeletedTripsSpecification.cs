namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetAllDeletedTripsSpecification : Specification<Trip>
{
    public AsNoTrackingGetAllDeletedTripsSpecification() : base(j => j.IsDeleted)
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
