namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetAllActiveTripsSpecification : Specification<Trip>
{
    public AsNoTrackingGetAllActiveTripsSpecification() : base(j => j.IsActive)
    {
        StopTracking();
    }
}
