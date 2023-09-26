namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Trips;
public sealed class AsNoTrackingGetAllTripsSpecification : Specification<Trip>
{
    public AsNoTrackingGetAllTripsSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
