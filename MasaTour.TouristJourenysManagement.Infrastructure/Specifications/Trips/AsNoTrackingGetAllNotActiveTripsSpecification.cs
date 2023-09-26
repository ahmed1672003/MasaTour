namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetAllNotActiveTripsSpecification : Specification<Trip>
{
    public AsNoTrackingGetAllNotActiveTripsSpecification() : base(j => !j.IsActive)
    {
        StopTracking();
    }
}
