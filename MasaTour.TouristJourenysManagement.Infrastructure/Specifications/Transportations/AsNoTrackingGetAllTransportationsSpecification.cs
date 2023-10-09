namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Transportations;
public sealed class AsNoTrackingGetAllTransportationsSpecification : Specification<Transportation>
{
    public AsNoTrackingGetAllTransportationsSpecification()
    {
        StopTracking();
        IgnorQueryFilter();
    }
}
